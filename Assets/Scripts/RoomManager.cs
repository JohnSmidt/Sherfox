using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomManager : MonoBehaviour
{
   Table table;
   List<Room> rooms;

   int roomID;

   public int RoomID{get{return roomID;} set{roomID = RoomID;}}
   void Start()
   {
      table = GetComponent<Table>();
      rooms = table.Truth;
      //Debug.Log(rooms[0]);
   }
   public void enterRoom(int roomID)
   {
      Debug.Log(rooms[roomID].Name);
      this.roomID = roomID;
      // TODO: Setup transition here
      SceneManager.LoadScene(rooms[roomID].Name);

      SceneManager.sceneLoaded += setupRoom;
      // Instantiate objects in room
      Debug.Log("This is still working");
   }

   public void setupRoom(Scene scene, LoadSceneMode mode)
   {
      Room room = rooms[roomID];
      Instantiate(room.Person, new Vector3(0,0,0), transform.rotation);
      Debug.Log("Instantiated Suspect " + room.Person);
      Instantiate(room.Item1, new Vector3(1,0,0), transform.rotation);

      Instantiate(room.Item2, new Vector3(2,0,0), transform.rotation);

   }

   // Should contain all spawning locations for each room


}
