using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class DDOL : MonoBehaviour
{
    //public TableSetup tableSetup = new TableSetup();
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
        //Debug.Log("DDOL " + gameObject.name);
       
    }
}
