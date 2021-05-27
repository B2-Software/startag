using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000f) )
                {
                    target.position  = hit.point;
                }

            }
    }
}
