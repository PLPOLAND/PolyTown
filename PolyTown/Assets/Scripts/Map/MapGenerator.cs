using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{

    System.Random r;

    public MapGenerator(){//ziarno losowe
        int seed = (int)DateTime.Now.Ticks;
        r = new System.Random(seed);
        GameObject.Find("SaveMenager").GetComponent<SaveSystem>().saveData.seed = seed;
    }
    public MapGenerator(int i){//ustalone ziarno
        r = new System.Random(i);
        GameObject.Find("SaveMenager").GetComponent<SaveSystem>().saveData.seed = i;
    }

    private List<FieldType> fields;
    public void init()
    {
        fields = new List<FieldType>();
    }

    public void addField(Pole.type typ, ref GameObject mesh, int prawdopodobienstwo, int maxIlosc, bool canBeBuild)
    {
        fields.Add(new FieldType(typ, mesh, prawdopodobienstwo, maxIlosc, canBeBuild));
    }
    /// <summary>
    /// Metoda generująca mape z podanych pól
    /// </summary>
    /// <param name="map">Obiekt w którym zostaną zapisane pola</param>
    /// <param name="size">Rozmiar mapy</param>
    public void generate(Pole[,] map, Vector2Int size)
    {

        Vector2Int pos = new Vector2Int(-(size.x / 2) * 4, -(size.y / 2) * 4);//pozycja początkowa
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Pole nowepole = new Pole(MonoBehaviour.Instantiate(fields[0].mesh),fields[0].type, fields[0].canBeBuild,pos,new Vector2Int(i,j), i + " " + j, 9);
                map[i, j] = nowepole;
                nowepole.mesh.transform.SetParent(GameObject.Find("Map").transform);
                pos.y += 4;
            }
            pos.y = -(size.y / 2) * 4;
            pos.x += 4;
        }
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (j - 1 >= 0)
                {
                    map[i, j].Up = map[i, j - 1];
                }
                if (j + 1 < size.y)
                {
                    map[i, j].Down = map[i, j + 1];
                }
                if (i - 1 > 0)
                {
                    map[i, j].Left = map[i - 1, j];
                }
                if (i + 1 < size.y)
                {
                    map[i, j].Right = map[i + 1, j];
                }
            }
        }
        for (int i = 1; i < fields.Count; i++)
        {
            while (fields[i].maxIlosc >= 5)
            {
                generateIsland(fields[i], map, size, new Vector2Int(r.Next(1,size.x-1), r.Next(1,size.y)-1));
            }   

        }

    }
    void generateIsland(FieldType field, Pole[,] mapa,Vector2Int mapSize, Vector2Int startPos)
    {
        var poleS = mapa[startPos.x,startPos.y];
        Queue<Pole> pola = new Queue<Pole>();
        pola.Enqueue(poleS);
        while (pola.Count!=0)
        {
            var p = pola.Dequeue();
            if (p.typ == field.type)
            {
                continue;
            }
            else
            {
                if (czyZmianaPola(field.prawdopodobienstwo) && field.maxIlosc>0)
                {
                    field.maxIlosc--;
                    var tmp = MonoBehaviour.Instantiate(field.mesh);
                    var tmp1 = tmp.GetComponent("Field") as Field;
                    var tmp2 = p.mesh.GetComponent("Field") as Field;
                    tmp1.pos = tmp2.pos;
                    tmp.transform.SetParent(GameObject.Find("Map").transform);
                    p.changeMesh(tmp);
                    p.canBuild = field.canBeBuild;
                    p.typ = field.type;
                    
                    if (!(p.Up==null))
                    {
                        pola.Enqueue(p.Up);
                    }
                    if (!(p.Left==null))
                    {
                        pola.Enqueue(p.Left);
                    }
                    if (!(p.Right==null))
                    {
                        pola.Enqueue(p.Right);
                    }
                    if (!(p.Down==null))
                    {
                        pola.Enqueue(p.Down);
                    }
                }
                else
                {
                    continue;
                }
            }
        }

    }
    
    bool czyZmianaPola(int prawdopodobienstwo){
        
        var tmpNumber = r.Next(100);
        // Debug.Log(tmpNumber);
        if(tmpNumber <=prawdopodobienstwo)
            return true;
        else
            return false;
    }
}

class FieldType
{
    public Pole.type type;
    public GameObject mesh;
    public int prawdopodobienstwo;
    public int maxIlosc;
    public bool canBeBuild;

    public FieldType(Pole.type type, GameObject mesh, int prawdopodobienstwo, int maxIlosc, bool canBeBuild)
    {
        this.type = type;
        this.mesh = mesh;
        this.prawdopodobienstwo = prawdopodobienstwo;
        this.maxIlosc = maxIlosc;
        this.canBeBuild = canBeBuild;
    }
}
