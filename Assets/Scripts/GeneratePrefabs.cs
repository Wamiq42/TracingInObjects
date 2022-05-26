using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GeneratePrefabs : MonoBehaviour
{
    [SerializeField] private  PathCreator pathCreator;
    private GameObject prefab;
    
    private List<float> placedObjectPoint = new List<float>();
    private List<GameObject> generatedPrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gotShapeName += InstantiateGameObjectOnPath;
       
    }
    private void OnDisable()
    {
        GameManager.instance.gotShapeName -= InstantiateGameObjectOnPath;
    }

    void FindtheObjectToUseInList(string name)
    {
        foreach (var item in GameManager.instance.Prefabs)
        {
            if (name == item.GetComponent<Shapes>().ShapeName)
            {
                prefab = item;
            }
        }
    }


    void InstantiateGameObjectOnPath(string name)
    {
        FindtheObjectToUseInList(name);
        float dst = 0;

        while (dst < pathCreator.path.length)
        {
            Vector3 point = pathCreator.path.GetPointAtDistance(dst);

            placedObjectPoint.Add(dst);
            Debug.Log(dst);
            //Quaternion rot = pathCreator.path.GetRotationAtDistance(dst);
            GameObject temp = Instantiate(prefab, point, Quaternion.identity, pathCreator.gameObject.transform);
            generatedPrefabs.Add(temp);
            temp.SetActive(false);

            dst += prefab.GetComponent<Shapes>().Spacing;
        }
        GameManager.instance.GeneratedPrefabs = generatedPrefabs;
        GameManager.instance.PointsOfPrefabs = placedObjectPoint;
    }

}
