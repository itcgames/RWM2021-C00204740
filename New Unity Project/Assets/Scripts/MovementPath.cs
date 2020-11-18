using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum Type
    {
        linearPath,
        loopedPath
    }
    //public variables
    public Type pathtype;
    public int moveDir;
    public int moveTo;
    public Transform[] pathArr;
    // Start is called before the first frame update
    void Start()
    {
        moveDir = 1;
        moveTo = 0;
    }
    public void OnDrawGizmos()
    {
        //if the length of the array is less than 2 
        if (pathArr.Length < 2)
        {
            //leave the draw function
            return;
        }
        //loop through the array and draw line between all array positions
        for (int i = 0; i < pathArr.Length; i++)
        {
            Gizmos.DrawLine(pathArr[i - 1].position, pathArr[i].position);
        }
    }
    public IEnumerator<Transform> GetNextPoint()
    {
        //if the arrry of paths is emty then breaks from coroutine
        if (pathArr.Length < 1)
        {
            yield break;
        }
        while (true)
        {
            yield return pathArr[moveTo];

            if (pathArr.Length == 1)
            {
                continue;
            }
            //if the type of path is linear
            if (pathtype == Type.linearPath)
            {
                //if at the beginning
                if (moveTo <= 0)
                {
                    //move forward
                    moveDir = 1;
                }
                //check if at the end
                else if (moveTo >= pathArr.Length - 1)
                {
                    //set to move back
                    moveDir = -1;
                }
            }
            //add direction to index to move to next point
            moveTo = moveTo + moveDir;
            
        }
    }
}
