using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    
    public float prawdopodobienstwo = 0f;
    public bool build = true;
    public static int maxAmount = 0;
    public Fields fieldType;

    public Field(){
        fieldType = Fields.NONE;
    }
    public void clicked(){
        Debug.Log("Kliknięto pole :" + this.name);
        Debug.Log("Typ:" + fieldType);
    }

    static public bool canBePalaced(){
        if (maxAmount>0)
            return true;
        else 
            return false;
    }

    public void playced(){
        if (canBePalaced())
            maxAmount-=1;
        else
            Debug.LogWarning("Out Of limit! - " + this.name);
    }

}

public enum Fields
{
    NONE,
    LAKA,
    LAS, 
    GORY,
    WODA
}