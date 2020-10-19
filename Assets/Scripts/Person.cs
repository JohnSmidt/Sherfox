using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Person : MonoBehaviour
{
  GameObject game;
  Dialogue dialogue;
  PersonManager personManager;
  [SerializeField]
  private Role role;
  public Role Role
  {
    get { return role; }
    set { role = value; }
  }
  private Modifier modifier { get; set; }
  private Personality personality { get; set; }
  
  public string Name{get {return this.name;}} 
  [SerializeField]
  private string prettyName;
  public string PrettyName{get {return prettyName;}}

  [SerializeField]
  [TextArea]
  private string description;
  public string Description{get {return description;}}
 
  // Members
  [SerializeField]
  private Dictionary<string, string> script;
  public Dictionary<string, string> Script{
    get { return script; }
    set { script = value; }
  }

  void Awake()
  {
    game = GameObject.Find("_app");
    dialogue = game.GetComponent<Dialogue>();
    personManager = game.GetComponent<PersonManager>();
    script = personManager.getScript(this.PrettyName);
  }

  public string askQuestion(string key)
  {
    dialogue.setupQuestionAnswerDialogue(key, script[key], prettyName);
    Debug.Log(script[key]);
    return "testing";
  }
}

////////////////
//Lighting striking the building
//Requirements to get into certain rooms
//    (use an event script to randomize requirements)
//Attributes of the thief
////////////////
