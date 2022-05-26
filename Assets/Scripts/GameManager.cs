using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]private List<GameObject> prefabs = new List<GameObject>();
    
    public List<GameObject> Prefabs
    {
        get => prefabs;
    }

    private string nameOfShape;
    public  string NameOfShape
    {
        get => nameOfShape;
        set
        {
            nameOfShape = value;
        }
    }
    private List<GameObject> generatedPrefabs = new List<GameObject>();
    public List<GameObject> GeneratedPrefabs
    {
        get => generatedPrefabs;
        set
        {
            generatedPrefabs = value;
        }
    }
    private List<float> pointsOfGeneratedPrefabs = new List<float>();
    public List<float> PointsOfPrefabs
    {
        get => pointsOfGeneratedPrefabs;
        set
        {
            pointsOfGeneratedPrefabs = value;
        }
    }



    public delegate void GotShapeName(string name);
    public GotShapeName gotShapeName;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        GetPrefabsFromResources();
    }

    void GetPrefabsFromResources()
    {
        foreach (var item in Resources.LoadAll<GameObject>("Shapes"))
        {
            prefabs.Add(item);
        }
    }
}
