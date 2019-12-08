using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    Pole[,] mapa;


    public GameObject laka;
    public GameObject las;
    public Vector2Int rozmiar = new Vector2Int(10,10);
    // Start is called before the first frame update
    void Start()
    {
        mapa = new Pole[rozmiar.x, rozmiar.y];
        MapGenerator generator = new MapGenerator();
        generator.init();
        generator.addField(Pole.type.LAKA, ref laka,100,int.MaxValue, true);
        generator.addField(Pole.type.LAS, ref las, 40, 1000, false);
        generator.generate(mapa,rozmiar);
        
        // Debug.Log(mapa[9,9].Left.mesh.name);
        // Debug.Log(mapa[9,9].Up.mesh.name);
        // Debug.Log(mapa[9,9].Down.mesh.name);
        // Debug.Log(mapa[9,9].Right.mesh.name);
    }


    
}
