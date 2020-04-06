using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{    
    public Material baseMaterial;
    public Material haighlightMaterialCanBuild;
    public Material haighlightMaterialCannotBuild;
    public Vector2Int pos;
    private Renderer objRenderer;
    private static Map map;
    public void onClick(){
        Debug.Log("Kliknięto pole z cordami: " + pos);
        var spawner = GameObject.Find("SpawnerBudynkow").GetComponent("Spawner") as Spawner;
        spawner.spawn(pos);
        
    }
    public void highLight(){
        if (map.mapa[pos.x, pos.y].canBuild)
            objRenderer.material = haighlightMaterialCanBuild;
        else
            objRenderer.material = haighlightMaterialCannotBuild;
    }
    public void clearHighLight(){
        objRenderer.material = baseMaterial;
    }
    private void Start() {
        objRenderer = this.GetComponent<Renderer>();
        if (map == null)
        {
            map = GameObject.Find("Map").GetComponent<Map>();
        }
    }

}