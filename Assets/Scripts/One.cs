using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class One : Numbers
{
    private int num = 1;
    [SerializeField] private List<PathCreator> paths;

    One()
    {
        base.number = num;
        base.pathsInDigits = paths;
    }
}
