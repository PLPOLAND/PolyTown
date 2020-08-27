using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Map : MonoBehaviour
{ 
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
    }
    public void generateAgain(int seed,int sizeX, int sizeY){
        for (int i = 0; i < mapa.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < mapa.GetUpperBound(1) + 1; j++)
            {
                if (mapa[i, j] !=null)
                {
                    MonoBehaviour.Destroy(mapa[i, j].mesh);//usuwanie meshy
                }
            }
        }
        Debug.Log("Zniszczono poprzednia mapę");
        mapa = new Pole[sizeX,sizeY];
        MapGenerator generator = new MapGenerator(seed);
        generator.init();
        generator.addField(Pole.type.LAKA, ref laka, szansaLaki, iloscLaki, true);
        generator.addField(Pole.type.LAS, ref las, szansaLasu, iloscLasu, false);
        generator.addField(Pole.type.GORY, ref gory, szansaGory, iloscGor, false);
        Debug.Log("Rozpoczynam Generowanie Mapy");
        generator.generate(mapa, rozmiar);
        Debug.Log("Zakończono Generowanie Mapy");
    }
    public Vector3 getPositionOfPole(Vector2Int pos){
        return mapa[pos.x , pos.y].mesh.transform.position;
    }

    public Pole getPole(Vector2Int pos){
        return mapa[pos.x, pos.y];
    }
    
}
