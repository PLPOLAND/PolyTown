using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{    
    public Vector2Int pos;
    public Field(){
        
    }
    public void onClick(){
        // Debug.Log("Kliknięto pole :" + this.name);
        Debug.Log("Kliknięto pole z cordami: " + pos);
        var spawner = GameObject.Find("SpawnerBudynkow").GetComponent("Spawner") as Spawner;
        spawner.spawn(pos);
        
    }

}