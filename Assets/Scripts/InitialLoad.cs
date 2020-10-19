using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoad : MonoBehaviour
{
   // DDOL is used by multiple objects, so this part of the code needed to be seperated
    void Start()
    {
         SceneManager.LoadScene("MainRoom_FirstFloor");
    }
}
