using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricDiamond : Shapes
{
    private string objectName = "IsometricDiamond";
    private float space = 2.0f;
    private IsometricDiamond()
    {
        base.SetShapeName(objectName);
        base.SetSpacing(space);
    }
}
