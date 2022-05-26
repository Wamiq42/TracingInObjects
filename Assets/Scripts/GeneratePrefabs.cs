using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GeneratePrefabs : MonoBehaviour
{
    private List<PathCreator> pathCreator;
    private GameObject shapePrefab;

    private List<float> placedObjectPoint = new List<float>();
    private List<GameObject> generatedPrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.gotShapeName += InstantiateGameObjectOnPath;
        pathCreator = GameManager.instance.NumberToGenerate.GetComponent<Numbers>().Paths;

    }
    private void OnDisable()
    {
        EventManager.instance.gotShapeName -= InstantiateGameObjectOnPath;
    }

    void FindtheObjectToUseInList(string name)
    {
        foreach (var item in GameManager.instance.ShapePrefabs)
        {
            if (name == item.GetComponent<Shapes>().ShapeName)
            {
                shapePrefab = item;
            }
        }
    }


    void InstantiateGameObjectOnPath(string name)
    {
        FindtheObjectToUseInList(name);


        for (int i = 0; i < pathCreator.Count; i++)
        {
            float dst = 0;
            while (dst < pathCreator[i].path.length)
            {
                Vector3 point = pathCreator[i].path.GetPointAtDistance(dst);

                placedObjectPoint.Add(dst);
                Debug.Log(dst);
                //Quaternion rot = pathCreator.path.GetRotationAtDistance(dst);
                GameObject temp = Instantiate(shapePrefab, point, Quaternion.identity, gameObject.transform);
                generatedPrefabs.Add(temp);
                temp.SetActive(false);

                dst += shapePrefab.GetComponent<Shapes>().Spacing;
            }

        }

        GameManager.instance.GeneratedShapePrefabs = generatedPrefabs;
        GameManager.instance.PointsOfPrefabs = placedObjectPoint;
    }

}
