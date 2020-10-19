using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item :MonoBehaviour
{
    public string Name{get {return this.name;}} 
    [SerializeField]
    private string prettyName;
    public string PrettyName{get {return prettyName;}}

    [SerializeField]
    [TextArea]
    private string description;
    public string Description{get {return description;}}
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
