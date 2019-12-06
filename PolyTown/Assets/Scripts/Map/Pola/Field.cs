using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{    
    public Field(){
        
    }
    public void onClick(){
        Debug.Log("Kliknięto pole :" + this.name);
    }

}