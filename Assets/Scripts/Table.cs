using UnityEngine;
using System.Collections;
using System.Collections.Generic;

////////
//
// This will store all of the gameobjects used in the game
//
////////


//IMPORTANT: Each 'level' in the house will make things more difficult to get into the door.
// i.e. Finding a key, finding a flashlight, searching for a passcode, performing other tasks to see
// what each room contains

[System.Serializable]
public class Table : MonoBehaviour
{
  private List<Room> truth = new List<Room>();
  public List<Room> Truth {get{return duplicateList(truth);}}
  [SerializeField]
  private List<GameObject> people = new List<GameObject>();

  public List<GameObject> People {get{return duplicateList(people);}}

  // The only way I can think of doing this. Storing string values that will be used
  // to call each scene.
  private List<string> rooms = new List<string> {"Attic", "Balcony", "Basement", "Bedroom",
                    "DiningRoom", "Garage", "Kitchen", "Library",
                    "LivingRoom", "Pantry", "Study", "TrophyRoom"};
  public List<string> Rooms {get{return duplicateList(rooms);}}
  [SerializeField]
  private List<GameObject> items = new List<GameObject>();
  public List<GameObject> Items {get{return duplicateList(items);}}

  public void Awake() {

    truth = makeTruthTable();
  }

  private List<Room> makeTruthTable()
  {
    List<Room> truth = new List<Room>();
    List<string> tempRooms = Rooms;
    List<GameObject> tempPeople = People;
    List<GameObject> tempItems = Items;
    for(int i = 0; i < 12; i++)
    {
      //Debug.Log(i);
      Room room = new Room(getRandomItemFromList(tempRooms),
                           getRandomItemFromList(tempPeople),
                           getRandomItemFromList(tempItems),
                           getRandomItemFromList(tempItems));
     
      truth.Add(room);
    }
    return truth;
  }

  public void showTruth(List<Room> list)
  {
    for(int i = 0; i < list.Count; i++)
    {
      Debug.Log(list[i].Name);
      Debug.Log(list[i].Person);
      Debug.Log(list[i].Item1);
      Debug.Log(list[i].Item2);
      Debug.Log("-----------");
    }
  }

  public T getRandomItemFromList<T>(List<T> list)
  {
    int r = Random.Range(0, list.Count);
    //Debug.Log(list.Count);
    T item = list[r];
    list.RemoveAt(r);
    return item;
  }

  // When table needs to be deeply cloned
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
}
