using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float moveSpeed = 20f;
     // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if(Input.GetKey("w")){
            pos.z += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
