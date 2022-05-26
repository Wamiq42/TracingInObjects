using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shapes
{
    private string objectName = "Circle";
    private float space = 0.3f;

    private Circle()
    {
        base.SetShapeName(objectName);
        base.SetSpacing(space);
    }
}
