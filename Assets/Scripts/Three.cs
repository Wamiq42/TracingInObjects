using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Three : Numbers
{
    private int num = 3;
    [SerializeField] private List<PathCreator> paths;

    Three()
    {
        base.number = num;
        base.pathsInDigits = paths;
    }
   
}
