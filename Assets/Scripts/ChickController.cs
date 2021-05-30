using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    float rotSpeed = 5;
    float speed = 10;
    bool moving = false;
    public GameObject targetObj;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            setTargetPosition();
        }
        if(moving)
            Move();
    }

    void setTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;

            if (Vector3.Distance(targetPosition, transform.position) >=  3)
            {
                targetObj.transform.position = new Vector3(targetPosition.x, targetPosition.y + 0.1f, targetPosition.z);
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                playerRot = Quaternion.LookRotation(lookAtTarget);
                moving = true;
            }
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
            moving = false; 
    }
}