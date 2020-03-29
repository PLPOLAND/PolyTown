﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{    
    public Material baseMaterial;
    public Material haighlightMaterialCanBuild;
    public Material haighlightMaterialCannotBuild;
    public Vector2Int pos;
    protected bool doHighlight = false;
    public Field(){
        
    }
    public void onClick(){
        // Debug.Log("Kliknięto pole :" + this.name);
        Debug.Log("Kliknięto pole z cordami: " + pos);
        var spawner = GameObject.Find("SpawnerBudynkow").GetComponent("Spawner") as Spawner;
        spawner.spawn(pos);
        
    }
    public void highLight(){
        doHighlight = true;
    }
    private void Update() {
        if (doHighlight)
        {
            if((GameObject.Find("Map").GetComponent("Map") as Map).mapa[pos.x,pos.y].canBuild)
                this.GetComponent<Renderer>().material = haighlightMaterialCanBuild;
            else
                this.GetComponent<Renderer>().material = haighlightMaterialCannotBuild;
            doHighlight = false;
        }
        else{
            this.GetComponent<Renderer>().material = baseMaterial;
        }
    }
}