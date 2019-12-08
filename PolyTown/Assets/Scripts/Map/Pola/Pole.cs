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

    public bool canBuild;//Czy na tym polu można budować?
    public Vector2Int cords;
    public Pole(GameObject m, type t, bool canBeBuild, Vector2Int cords, string name="", int layer=-1){
        this.mesh = m;
        this.typ = t;
        this.canBuild = canBeBuild;
        this.cords = cords;
        this.changePos(cords);
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
    /// <summary>
    /// Zmiana pozycji pola(pozycja w świecie)
    /// </summary>
    /// <param name="newpos">Vector2Int - przechowuje docelowe koordynaty</param>
    public void changePos(Vector2Int newpos){
        var tmp = this.mesh.transform.position;
        tmp.x += newpos.x;
        tmp.z += newpos.y;
        this.mesh.transform.position = tmp;
    }

    public void changeMesh(GameObject mesh){
        mesh.name = this.mesh.name;//ustaw stara nazwe
        mesh.layer = this.mesh.layer;//ustaw stara warstwe
        mesh.transform.position = this.mesh.transform.position;//ustaw stara pozycje
        MonoBehaviour.Destroy(this.mesh);//usuń stary mesh
        this.mesh=mesh;//przypisz nowy mesh
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

