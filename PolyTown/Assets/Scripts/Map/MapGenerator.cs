using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{


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
                Pole nowepole = new Pole(MonoBehaviour.Instantiate(fields[0].mesh),fields[0].type, fields[0].canBeBuild,pos,i+" " + j, 9);
                map[i, j] = nowepole;   
                // nowepole.mesh = MonoBehaviour.Instantiate(fields[0].mesh);
                // nowepole.mesh.name = i + " " + j;
                // nowepole.mesh.layer = 9;
                // newobj.AddComponent<MeshCollider>();
                // newobj.AddComponent<ClickOn>();
                // var n = newobj.GetComponent<ClickOn>();
                // n.red = red;
                // nowepole.changePos(pos);
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
                System.Random r = new System.Random((int)DateTime.Now.Ticks);
                
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
                Debug.Log("Ten sam typ ("+p.typ.ToString()+")");
                continue;
            }
            else
            {
                Debug.Log("Inne typy, sprawdzenie trafienia...");
                if (czyZmianaPola(field.prawdopodobienstwo) && field.maxIlosc>0)
                {
                    Debug.Log("Wylosowano TAK");
                    field.maxIlosc--;
                    var tmp = MonoBehaviour.Instantiate(field.mesh);
                    // mapa[p.cords.x,p.cords.y] = new Pole(tmp,field.type,field.canBeBuild,p.cords,p.mesh.name,p.mesh.layer);
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
                    Debug.Log("Wylosowano NIE");
                    continue;
                }
            }
        }

    }
    
    bool czyZmianaPola(int prawdopodobienstwo){
        System.Random r = new System.Random((int)DateTime.Now.Ticks);
        var tmpNumber = r.Next(100);
        Debug.Log(tmpNumber);
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
