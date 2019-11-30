using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    GameObject[,] mapa;


    public GameObject laka;
    public GameObject las;
    public Vector2Int rozmiar = new Vector2Int(10,10);
    // Start is called before the first frame update
    void Start()
    {
        mapa = new GameObject[rozmiar.x, rozmiar.y];
        Debug.Log(laka==null);
        MapGenerator generator = new MapGenerator();
        generator.init();
        generator.addField(Fields.LAKA, ref laka);
        generator.addField(Fields.LAS, ref las);
        generator.generate(mapa,rozmiar);
    }


    
}
