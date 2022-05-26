using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Numbers : MonoBehaviour
{
    protected int number;
    protected List<PathCreator> pathsInDigits;

    public int Number
    {
        get => number;
        
    }
    public List<PathCreator> Paths
    {
        get => pathsInDigits;
    }
}
