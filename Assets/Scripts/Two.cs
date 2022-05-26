using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Two : Numbers
{
    private int num = 2;
    [SerializeField] private List<PathCreator> paths;

    Two()
    {
        base.number = num;
        base.pathsInDigits = paths;
    }
}
