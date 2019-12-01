using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laka : Field {
    Laka() : base()
    {
        fieldType = Fields.LAKA;
        maxAmount = int.MaxValue;
        this.build = true;
        this.prawdopodobienstwo = 1f;
    }
    
    private void Start() {
        //Debug.Log(this.name + this.build);
    }

}