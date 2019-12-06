using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pole
{
    public Pole Up;
    public Pole Down;
    public Pole Left;
    public Pole Right;

    public GameObject mesh;
    public type typ;

    public bool canBuild;
    public Pole(GameObject m, type t, bool canBeBuild, string name="", int layer=-1){
        this.mesh = m;
        this.typ = t;
        this.canBuild = canBeBuild;
        if (name != "")
        {
            mesh.name = name;
        }
        if (layer != -1){
            mesh.layer = layer;
        }
    }

    public Pole(){
        // mesh = new GameObject();
        typ = type.NONE;
        canBuild = false;
        Debug.LogWarning("Wygenerowano Pole(). Czy napewno tego oczekiwano?");
    }
    ~Pole(){
        MonoBehaviour.Destroy(mesh);
    }

    // public void ChangeType //TODO Do zrobienia zmiana rodzaju pola
    
    public void changePos(Vector2Int newpos){
        var tmp = this.mesh.transform.position;
        tmp.x += newpos.x;
        tmp.z += newpos.y;
        this.mesh.transform.position = tmp;
    }


    /// <summary>
    /// Typy pól na mapie
    /// </summary>
    public enum type
    {
        NONE,
        LAKA,
        LAS,
        GORY,
        WODA
    }
}

