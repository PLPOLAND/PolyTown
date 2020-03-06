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
            if ((pos.z + moveSpeed * Time.deltaTime) < 180)
            pos.z += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            if((pos.z - moveSpeed * Time.deltaTime) > -208 )
                pos.z -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            if ((pos.x - moveSpeed * Time.deltaTime) > -180)
                pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            if ((pos.x + moveSpeed * Time.deltaTime) < 180)
                pos.x += moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
