using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public enum MoveType
    {
        moveTowardsPoint,
        rotatePlatform
    }
    public MoveType moveType = MoveType.moveTowardsPoint;
    public MovementPath path;
    //object speed
    public float speed;
    public GameObject player;
    public float distanceToPoint;
    private IEnumerator<Transform> pointInPath;
    bool playerOnPlat;
    void Start()
    {
        playerOnPlat = false;
        speed = 2.0f;
        //how close to point has it to be to be considered at point
        distanceToPoint = 0.1f;
        pointInPath = path.GetNextPoint();
        //get the next point to move to
        pointInPath.MoveNext();

        if (pointInPath == null)
        {

            Debug.Log("Path needs points");
            return;
        }
        //set the platform position to the first point
        transform.position = pointInPath.Current.position;
    }
    void Update()
    {
        //if there no path then then exit
        if(pointInPath == null)
        {
            return;
        }
        //The movement type is a move towards then call move towards function
        if (moveType == MoveType.moveTowardsPoint)
        { 
            MoveTowards();
        }
        if (moveType == MoveType.rotatePlatform)
        {
            PlatformRotation();
        }

    }
    public void PlatformRotation()
    {

    }
    public void MoveTowards()
    {
        //check if the movement type is a movetowards
        if (moveType == MoveType.moveTowardsPoint)
        {
            //using the move towards function then move to next point in path
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position
                , Time.deltaTime * speed);
        }
        //check if the platform is close to the point and if so move to the next
        float distaneSq = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distaneSq < distanceToPoint * distanceToPoint)
        {
            pointInPath.MoveNext();
        }
    }
    public bool getPlayerOnPlatform()
    {
        return playerOnPlat;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.green;
            playerOnPlat = true;
            other.transform.SetParent(transform);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.red;
            playerOnPlat = false;
            other.transform.SetParent(null);
            
        }
    }
}
