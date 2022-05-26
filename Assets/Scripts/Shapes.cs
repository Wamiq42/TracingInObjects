using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    private string shapeName;
    public string ShapeName
    {
        get => shapeName;
    }

    private float spacing;
    public float Spacing
    {
        get => spacing;
    }
    protected void SetShapeName(string name)
    {
        shapeName = name;
    }
    protected void SetSpacing(float space)
    {
        spacing = space;
    }
}
