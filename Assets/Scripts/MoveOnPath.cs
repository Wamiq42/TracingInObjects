using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MoveOnPath : MonoBehaviour
{
   // [SerializeField] private Transform[] routes;
   // private int routeToGo;
   // private float tParam;
   // private Vector2 playerPosition;
   //// private float speedModifier; 
   // Vector2 p0;
   // Vector2 p1;
   // Vector2 p2;
   // Vector2 p3;


    public List<PathCreator> pathCreator;
   
    float distanceTravel;

    //workedSolution
    private bool isDragging = false;
    private bool onObject = false;
    float dst = 0;
    Vector3 lastPosition;
    List<float> placedObjectPoint = new List<float>();
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spacing;
    [SerializeField] private List<GameObject> generatedPrefabs = new List<GameObject>();
    [SerializeField] private int indexOfPathCreator = 0;
    //private Rigidbody2D playerRigidbody2D;


    private void Start()
    {

        //playerRigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = pathCreator[indexOfPathCreator].path.GetPointAtDistance(0);
        lastPosition = transform.position;
        //InstantiateGameObjectOnPath();

    }
    private void Update()
    {
        if (isDragging && onObject && GameManager.instance.GeneratedPrefabs.Count!= 0)
        {
            //MovementOnPath();
            Movement();
            ObjectReveal();
        }
    }
    private void OnMouseEnter()
    {
        onObject = true;
    }

    void OnMouseExit()
    {
        onObject = false;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
  
    void Movement()
    {
        //3rd workedSolution
        Vector2 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Vector3 nearestWorldPositionOnPath = pathCreator[indexOfPathCreator].path.GetPointAtDistance(pathCreator[indexOfPathCreator].path.GetClosestDistanceAlongPath(worldPosition),EndOfPathInstruction.Stop);
       // Debug.Log("Get Point at this Time" + pathCreator.path.GetPointAtTime(Time.time));

        //Debug.Log("nearestWorldPositionOnPath" + nearestWorldPositionOnPath);
        //Debug.Log("Get neareast Point " + pathCreator.path.GetClosestPointOnPath(worldPosition));
        //Debug.Log("Get neareast Point " + pathCreator.path.GetClosestPointOnPath(nearestWorldPositionOnPath));

        //Debug.Log(pathCreator.path.length);


        //transform.rotation = pathCreator.path.GetRotation(0);



        /*****Movement With Transform*******/
        transform.position = nearestWorldPositionOnPath;
        lastPosition = transform.position;

        //playerRigidbody2D.MovePosition(nearestWorldPositionOnPath);










        //distanceTravel += speed + Time.deltaTime;
        //transform.position = pathCreator.path.GetPointAtDistance(distanceTravel);
        //Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        //distanceTravel = pathCreator.path.GetClosestDistanceAlongPath(position);
        // distanceTravel += speed + Time.deltaTime;

        //position.x = Mathf.Clamp(position.x, pathCreator.path.bounds.min.x, pathCreator.path.bounds.max.x);
        //position.y = Mathf.Clamp(position.y, pathCreator.path.bounds.min.y, pathCreator.path.bounds.max.y);


        //transform.Translate(position * Time.deltaTime);
    }
    void ObjectReveal()
    {
        
        //distanceTravel = pathCreator.path.GetPointAtDistance()
        //distanceTravel = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        //Debug.Log("Distance in Travel (float) :" + distanceTravel);
        decimal distanceInDecimal = (decimal)pathCreator[indexOfPathCreator].path.GetClosestDistanceAlongPath(transform.position);
        distanceInDecimal = decimal.Round(distanceInDecimal, 1);
        Debug.Log("Distance in Decimal :" + distanceInDecimal);
        for (int i = 0; i < GameManager.instance.PointsOfPrefabs.Count; i++)
        {
            Debug.Log("Loop Active");
            if (distanceInDecimal == (decimal.Round((decimal)GameManager.instance.PointsOfPrefabs[i],1)))
            {
                Debug.Log("Accessed IF");
                GameManager.instance.GeneratedPrefabs[i].SetActive(true);
            }
        }
    }



    void InstantiateGameObjectOnPath()
    {
        

        while (dst < pathCreator[indexOfPathCreator].path.length)
        {
            Vector3 point = pathCreator[indexOfPathCreator].path.GetPointAtDistance(dst);
           
            placedObjectPoint.Add(dst);
            Debug.Log(dst);
            //Quaternion rot = pathCreator.path.GetRotationAtDistance(dst);
            GameObject temp = Instantiate(prefab, point, Quaternion.identity, pathCreator[indexOfPathCreator].gameObject.transform);
            generatedPrefabs.Add(temp);
            temp.SetActive(false);

            dst += spacing;
        }
    }








    //void MovementOnPath()
    //{


    //    //tParam += Time.deltaTime * speedModifier;
    //    //tParam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    playerPosition = Mathf.Pow(1 - tParam, 3) * p0 
    //        + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1
    //        + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 
    //        + Mathf.Pow(tParam, 3) * p3;

    //    transform.position = playerPosition;
    //}
    private void OnMouseDown()
    {
        //p0 = routes[routeToGo].GetChild(0).position;
        //p1 = routes[routeToGo].GetChild(1).position;
        //p2 = routes[routeToGo].GetChild(2).position;
        //p3 = routes[routeToGo].GetChild(3).position;
        isDragging = true;
        onObject = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        onObject = false;
        //transform.position = playerPosition;
        //tParam = 0f;
        //routeToGo += 1;
        //if (routeToGo > routes.Length - 1)
        //{
        //    routeToGo = 0;
        //}
    }
}
