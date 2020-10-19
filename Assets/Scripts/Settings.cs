using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private uint numberOfGood;
    [SerializeField]
    private uint numberOfMisguided;




    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setNumberOfGoodPeople(uint number)
    {
        numberOfGood = number;
    }

    public void setNumberOfMisguidedPeople(uint number)
    {
        numberOfMisguided = number;
    }

    public uint getNumberOfGoodPeople()
    {
        return numberOfGood;
    }

    public uint getNumberOfMisguidedPeople()
    {
        return numberOfMisguided;
    }
}
