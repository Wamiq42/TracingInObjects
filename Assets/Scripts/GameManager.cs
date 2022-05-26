using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]private List<GameObject> shapePrefabs = new List<GameObject>();
    private GameObject numberToGenerate;
    public GameObject NumberToGenerate
    {
        get => numberToGenerate;
    }
    public List<GameObject> ShapePrefabs
    {
        get => shapePrefabs;
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
    private List<GameObject> generatedShapePrefabs = new List<GameObject>();
    public List<GameObject> GeneratedShapePrefabs
    {
        get => generatedShapePrefabs;
        set
        {
            generatedShapePrefabs = value;
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

    private List<GameObject> numbersPrefabs = new List<GameObject>();
   


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
        GetShapesPrefabsFromResources();
        GetNumberPrefabsFromResources();
    }
    private void Start()
    {
        EventManager.instance.getNumber += GenerateTheSelectedNumber;
    }
    void GetNumberPrefabsFromResources()
    {
        foreach (var item in Resources.LoadAll<GameObject>("Numbers"))
        {
            numbersPrefabs.Add(item);
        }
    }
    void GetShapesPrefabsFromResources()
    {
        foreach (var item in Resources.LoadAll<GameObject>("Shapes"))
        {
            shapePrefabs.Add(item);
        }
    }

    void FindTheNumberToGenerate(int num)
    {
        foreach (var item in numbersPrefabs)
        {
            if (num == item.GetComponent<Numbers>().Number)
            {
                numberToGenerate = item;
            }
        }
    }
    
    void GenerateTheSelectedNumber(int num)
    {
        FindTheNumberToGenerate(num);

        Instantiate(numberToGenerate, transform.position, Quaternion.identity);
    }

}
