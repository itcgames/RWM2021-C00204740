using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    //Controller for the platform
    public enum MoveType
    {
        moveTowardsPoint,
        rotatePlatform
    }
    Quaternion startRotation;
    bool beginRotation;
    public MoveType moveType = MoveType.moveTowardsPoint;
    public Paths path;
    //object speed
    public float speed;
    public float rotationSpeed;
    public GameObject player;
    public float distanceToPoint;
    private IEnumerator<Transform> pointInPath;
    bool playerOnPlat;
    void Start()
    {
        playerOnPlat = false;
        speed = 2.0f;
        rotationSpeed = 100.0f;
        //how close to point has it to be to be considered at point
        distanceToPoint = 0.1f;
        pointInPath = path.GetNextPoint();
        //get the next point to move to
        pointInPath.MoveNext();
        startRotation = transform.rotation;
        beginRotation = false;
        if (pointInPath == null)
        {
            Debug.Log("Path needs points");
            return;
        }
        //set the platform position to the first point
        //transform.position = pointInPath.Current.position;
    }
    public void setType()
    {
        moveType = MoveType.moveTowardsPoint;
    }
    public MoveType getType()
    {
        return moveType;
    }
    void Update()
    {
        //if there no path then then exit
        if (pointInPath == null)
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
    void PlatformRotation()
    {
       
        if (moveType == MoveType.rotatePlatform)
        {
            if (playerOnPlat == true)
            {
                beginRotation = true;
                Debug.Log("Rotation Start");
            }
            if (transform.rotation == startRotation && beginRotation == true && playerOnPlat == false)
            {
                transform.rotation = startRotation;
                beginRotation = false;
                Debug.Log("Rotation End");
            }
            if (beginRotation == true)
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
                Debug.Log("Rotation Happening");
            }
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.green;
            playerOnPlat = true;
            if (moveType == MoveType.moveTowardsPoint)
            {
                collision.transform.SetParent(transform);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.red;
            playerOnPlat = false;
            collision.transform.SetParent(null);

        }
    }
}
