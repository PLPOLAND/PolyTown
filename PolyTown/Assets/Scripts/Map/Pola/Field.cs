using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{    
    public Material baseMaterial;
    public Material haighlightMaterialCanBuild;
    public Material haighlightMaterialCannotBuild;
    public Vector2Int pos;
    protected bool doHighlight = false;
    private int updates = 0;
    private Renderer objRenderer;
    public Field(){
        
    }
    public void onClick(){
        Debug.Log("Kliknięto pole z cordami: " + pos);
        var spawner = GameObject.Find("SpawnerBudynkow").GetComponent("Spawner") as Spawner;
        spawner.spawn(pos);
        
    }
    public void highLight(){
        doHighlight = true;
    }
    private void Start() {
        objRenderer = this.GetComponent<Renderer>();
    }
    private void Update() {
        
        if (doHighlight)
        {
            if((GameObject.Find("Map").GetComponent("Map") as Map).mapa[pos.x,pos.y].canBuild)
                objRenderer.material = haighlightMaterialCanBuild;
            else
                objRenderer.material = haighlightMaterialCannotBuild;
            doHighlight = false;
            updates = 0;
        }
        else if(updates > 2){
            objRenderer.material = baseMaterial;
            updates = 0;
        }
        else 
            updates++;
    }
}