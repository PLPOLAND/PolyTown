using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceFinder
{
    [SerializeField]
    Pole.type doZnalezienia = Pole.type.NONE;

    [SerializeField]
    int promien = 1;

    Map mapa = null;

    void init()
    {
        if (mapa == null)
            mapa = GameObject.Find("Map").GetComponent<Map>(); // init
    }
    public bool znajdź(Vector2Int pozycja)
    {
        if (doZnalezienia == Pole.type.NONE)//nie szukamy jeśli nie sprecyzowano szukanego pola z zasobami
            return true;
        init();
        bool znaleziono = false;

        Pole poleStartowe = mapa.getPole(pozycja);
        int movesToDo = promien;

        znaleziono = sprawdzRozgalezienia(movesToDo, poleStartowe, poleStartowe);

        Debug.Log("Czy znaleziono: " + znaleziono);

        return znaleziono;
    }
    bool sprawdzRozgalezienia(int moves, Pole next, Pole curr)
    {
        
        if (next.Up.typ == doZnalezienia && next.Up != curr || next.Down.typ == doZnalezienia && next.Down != curr || next.Left.typ == doZnalezienia && next.Left != curr || next.Right.typ == doZnalezienia && next.Right != curr)
            return true;
        else
        {
            moves--;
            if (moves == 0)
                return false;

            bool tmp = false;
            tmp = sprawdzRozgalezienia(moves, next.Up,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezienia(moves, next.Down,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezienia(moves, next.Left,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezienia(moves, next.Right,next);
            return tmp;

        }
    }
    /// <summary>
    /// Wizualizacja sprawdzania rozgałęzień
    /// </summary>
    /// <param name="moves">pozostała ilość ruchów</param>
    /// <param name="next"> pole do sprawdzenia</param>
    bool sprawdzRozgalezieniaVis(int moves, Pole next, Pole curr)
    {
        Debug.Log(next.cords.ToString());
        if (next.Up.typ == doZnalezienia && next.Up != curr)
        {
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Down.typ == doZnalezienia && next.Down != curr)
        {
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Left.typ == doZnalezienia && next.Left != curr)
        {
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Right.typ == doZnalezienia && next.Right != curr)
        {
            next.Right.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Right.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        
        moves--;
        if (moves == 0)
            return false;

        bool tmp = false;
        tmp = sprawdzRozgalezieniaVis(moves, next.Up, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaVis(moves, next.Down, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaVis(moves, next.Left, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaVis(moves, next.Right, curr);
        return tmp;
    }
}
