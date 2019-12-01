using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las : Field
{
    Las() : base()
    {
        fieldType = Fields.LAS;
        maxAmount = 500;
        this.build = false;
        this.prawdopodobienstwo = 0.3f;
    }
    private void Start()
    {
        //Debug.Log(this.name + this.build);
    }

}