using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PersonManager : MonoBehaviour 
{
  Table table;
  uint numberOfGoodPeople;
  uint numberOfMisguidedPeople;

  // Since Serialization cannot occur for dictionaries, an object needs to be made to
  // store the dictionaries.
  private Dictionary<string, Dictionary<string,string>> scripts;

  void Awake()
  {
    Settings settings = GetComponent<Settings>();
    table = GetComponent<Table>();
    List<GameObject> people = table.People;
    
    // get role number from settings
    numberOfGoodPeople = settings.getNumberOfGoodPeople();
    numberOfMisguidedPeople = settings.getNumberOfMisguidedPeople();

    setupRoles(numberOfGoodPeople, numberOfMisguidedPeople);
    setupSuspects();
    //Debug.Log(table.People[3].GetComponent<Person>().Script.Count);
   
   //Debug.Log(table.People[3].GetComponent<Person>().askQuestion("Balcony"));

  //  Dictionary<string, string>.KeyCollection keys = table.People[3].GetComponent<Person>().Script.Keys; 

  //   foreach (string key in keys)  
  //   {  
  //      Debug.Log(key);  
  //   }
  }

  void setupRoles(uint numberOfGoodPeople, uint numberOfMisguidedPeople)
  {
    List<GameObject> people = table.People;
    while(numberOfGoodPeople > 0)
    {
      //Debug.Log(people.Count);
      getRandomItemFromList(people).GetComponent<Person>().Role = Role.Good;
      numberOfGoodPeople--;
    }
    while(numberOfMisguidedPeople > 0)
    {
      getRandomItemFromList(people).GetComponent<Person>().Role = Role.Misguided;
      numberOfMisguidedPeople--;
    }
    // Should only be one left
    people[0].GetComponent<Person>().Role = Role.Thief;
  }

   public T getRandomItemFromList<T>(List<T> list)
  {
    int r = Random.Range(0, list.Count);
    //Debug.Log(list.Count);
    T item = list[r];
    list.RemoveAt(r);
    return item;
  }

   protected List<T> duplicateList<T>(List<T> original)
  {
    List<T> duped = new List<T>();

    // Copy each item in the list
    for(int i = 0; i < original.Count; i++)
    {
      duped.Add(original[i]);
    }
    return duped;
  }

  void setupSuspects()
  {
    List<GameObject>people = table.People;
    scripts = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, string> script = new Dictionary<string, string>();
    for(int i = 0; i < people.Count; i++)
    {
      // Check role, and make script accordingly
      switch(people[i].GetComponent<Person>().Role)
      {
        case Role.Thief:
          scripts.Add(people[i].GetComponent<Person>().PrettyName, setupScript(12, 0));
          break;
        case Role.Misguided:
          scripts.Add(people[i].GetComponent<Person>().PrettyName, setupScript(6, 6));
          break;
        case Role.Good:
          scripts.Add(people[i].GetComponent<Person>().PrettyName, setupScript(0, 12));
          break;
        default:
          // Just need this to fire. Nothing should enter here.
          Debug.Assert(1 == 2);
        break;
      }
    }
  }

// Uses TableSetup to form a script of lies and truths for each suspect
// JUST HAVE THEM MAKE A ROOM => ITEM CONNECTION
  Dictionary<string, string> setupScript(int numOfLies, int numOfTruths)
  {
    Dictionary<string, string> script = new Dictionary<string, string>();

    List<Room> truth = table.Truth;
    while(numOfLies > 0)
    {
      //Debug.Log(numOfLies);
      // get list of all items
      List<GameObject> items = table.Items;
      Room room = getRandomItemFromList(truth);
      string key = room.Name;
      string value = getRandomItemFromList(table.Items).GetComponent<Item>().PrettyName;
      script.Add(key, value);
      numOfLies--;
    }
    while(numOfTruths > 0)
    {
       //Debug.Log(numOfTruths);
      int itemToggle = Random.Range(0,2);
      Room room = getRandomItemFromList(truth);
      string key = room.Name;
      string value;
      if(itemToggle == 0)
      {
        value = room.Item1.GetComponent<Item>().PrettyName;
      }
      else
      {
        value = room.Item2.GetComponent<Item>().PrettyName;
      }
      script.Add(key, value);
      numOfTruths--;
    }
    return script;
  }

  public Dictionary<string,string> getScript(string key)
  {
    Dictionary<string,string> script = scripts[key];
    return script;
  }
}
