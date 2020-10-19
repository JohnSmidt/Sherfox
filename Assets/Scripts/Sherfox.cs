using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sherfox : MonoBehaviour
{
    [SerializeField]
    GameObject _app;
    RoomManager roomManager;
    bool canInteract = false;
    [SerializeField]
    List<Collider2D> interactionCollection;
    GameObject ActionObject;
    // Start is called before the first frame update
    void Awake()
    {
        _app = GameObject.Find("_app");
        roomManager = _app.GetComponent<RoomManager>();
        interactionCollection = new List<Collider2D>();
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {  
      if(Input.GetButtonDown("Interact") && canInteract)
      {
        switch(interactionCollection[0].gameObject.tag)
        {
          case "Door":
           // Debug.Log(interactionCollection[0].gameObject.GetComponent<Door>().Id);
            roomManager.enterRoom(interactionCollection[0].gameObject.GetComponent<Door>().Id);
          break;
          case "Suspect":
            interactionCollection[0].gameObject.GetComponent<Person>().askQuestion("Attic");
          break;
        }
      }
    }

    // Handle triggers for Sherfox
    void OnTriggerEnter2D(Collider2D col)
    {

        interactionCollection.Add(col);
        canInteract = true;
        // if(col.gameObject.tag == "Door")
        // {

        // }
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
        //Debug.Log("Triggered!");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        interactionCollection.Remove(col);
        canInteract = interactionCollection.Count < 1 ? false : true;
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
        //Debug.Log("Triggered!");
    }
}
