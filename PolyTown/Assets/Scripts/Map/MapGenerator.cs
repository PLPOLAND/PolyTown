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

    public void addField(Pole.type typ, ref GameObject mesh, int prawdopodobienstwo)
    {
        fields.Add(new FieldType(typ, mesh, prawdopodobienstwo));
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
                Pole nowepole = new Pole();
                nowepole.mesh = MonoBehaviour.Instantiate(fields[0].mesh);
                map[i, j] = nowepole;
                nowepole.mesh.name = i + " " + j;
                nowepole.mesh.layer = 9;
                // newobj.AddComponent<MeshCollider>();
                // newobj.AddComponent<ClickOn>();
                // var n = newobj.GetComponent<ClickOn>();
                // n.red = red;
                nowepole.changePos(pos);
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

    }
    void generateIsland(FieldType field, Pole[,] mapa, Vector2Int startPos)
    {
        var poleS = mapa[startPos.x,startPos.y];
        

    }
}

class FieldType
{
    public Pole.type type;
    public GameObject mesh;
    public int prawdopodobienstwo;

    public FieldType(Pole.type type, GameObject mesh, int prawdopodobienstwo)
    {
        this.type = type;
        this.mesh = mesh;
        this.prawdopodobienstwo = prawdopodobienstwo;
    }
}
