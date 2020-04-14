using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    public Pole[,] mapa;


    public GameObject laka; //obiekt tworzący lake
    public int szansaLaki = 100;
    public int iloscLaki = int.MaxValue;
    public GameObject las; //obiekt tworzący las
    public int szansaLasu;
    public int iloscLasu;
    public GameObject gory; //obiekt tworzący góry
    public int szansaGory;
    public int iloscGor;
    public Vector2Int rozmiar = new Vector2Int(10,10);
    // Start is called before the first frame update
    void Start()
    {
        mapa = new Pole[rozmiar.x, rozmiar.y];
        MapGenerator generator = new MapGenerator();
        generator.init();
        generator.addField(Pole.type.LAKA, ref laka,szansaLaki,iloscLaki, true);
        generator.addField(Pole.type.LAS, ref las, szansaLasu, iloscLasu, false);
        generator.addField(Pole.type.GORY, ref gory, szansaGory, iloscGor, false);
        generator.generate(mapa,rozmiar);
        
        // Debug.Log(mapa[9,9].Left.mesh.name);
        // Debug.Log(mapa[9,9].Up.mesh.name);
        // Debug.Log(mapa[9,9].Down.mesh.name);
        // Debug.Log(mapa[9,9].Right.mesh.name);
    }

    public Vector3 getPositionOfPole(Vector2Int pos){
        return mapa[pos.x , pos.y].mesh.transform.position;
    }

    public Pole getPole(Vector2Int pos){
        return mapa[pos.x, pos.y];
    }
    
}
