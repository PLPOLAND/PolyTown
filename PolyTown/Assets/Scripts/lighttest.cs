using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighttest : MonoBehaviour
{
    public int scalar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.Rotate(new Vector3(scalar*Time.deltaTime,0,0));
    }
}
