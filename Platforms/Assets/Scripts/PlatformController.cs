using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoveType
{
    moveTowardsPoint,
    rotatePlatform
}
public class PlatformController : MonoBehaviour
{
    //Controller for the platform
    Quaternion startRotation;
    bool beginRotation;
    public MoveType moveType = MoveType.moveTowardsPoint;
    int movementType = 0;
    public Paths path;
    //object speed
    public float speed;
    public float rotationSpeed;
    public float distanceToPoint;
    private IEnumerator<Transform> pointInPath;
    bool playerOnPlat;
    void Start()
    {
        setUp();
        //set the platform position to the first point
        //transform.position = pointInPath.Current.position;
    }
    public void setUp()
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
    }
    public void setTypeMove()
    {
        moveType = MoveType.moveTowardsPoint;
    }
    public void setTypeRotation()
    {
        moveType = MoveType.rotatePlatform;
    }
    public int getType()
    {
        return movementType;
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
            movementType = 1;
            MoveToward();
           
        }
        if (moveType == MoveType.rotatePlatform)
        {
            movementType = 2;
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
    public void MoveToward()
    {
        //using the move towards function then move to next point in path
        transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position
            , Time.deltaTime * speed);
        
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
