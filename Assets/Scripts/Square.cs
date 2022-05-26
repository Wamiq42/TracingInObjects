using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Shapes
{
    private string objectName = "Square";
    private float space = 1.4f;
    private Square()
    {
        base.SetShapeName(objectName);
        base.SetSpacing(space);
    }
  
}
