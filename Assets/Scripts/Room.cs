using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Room cannot be instantiated, so MonoBehavior is not needed
public class Room
{
    private string name;
    private GameObject person;
    private GameObject item1;
    private GameObject item2;
    public string Name { get{return name;} }
    public GameObject Person { get{return person;} }
    public GameObject Item1 { get{return item1;} }
    public GameObject Item2 { get{return item2;} }
    public Room(string name, GameObject person, GameObject item1, GameObject item2)
    {
        this.name = name;
        this.person = person;
        this.item1 = item1;
        this.item2 = item2;
    }
}
