using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
  public float scrollSpeed;

  public float topBarrier;
  public float botBarrier;
  public float leftBarrier;
  public float rightBarrier;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.mousePosition.y >= Screen.height * topBarrier)
    {
      transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
    }

    if (Input.mousePosition.y <= Screen.height * botBarrier)
    {
      transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
    }

    if (Input.mousePosition.x >= Screen.width * rightBarrier)
    {
      transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
    }

    if (Input.mousePosition.x <= Screen.width * leftBarrier)
    {
      transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
    }
  }
}
