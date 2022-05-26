using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public delegate void GotShapeName(string name);
    public GotShapeName gotShapeName;

    public delegate void GetNumber(int num);
    public GetNumber getNumber;
}
