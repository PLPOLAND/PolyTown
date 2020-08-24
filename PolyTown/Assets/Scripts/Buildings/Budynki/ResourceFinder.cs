﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceFinder
{
    [SerializeField]
    Pole.type doZnalezieniaPole = Pole.type.NONE; // powinno być ustawione jeśli szukamy przez pole
    [SerializeField]
    BudynekType doZnalezieniaBudynek = BudynekType.NONE;// powinno być ustawione jeśli szukamy przez budynek

    [SerializeField]
    int promien = 1;

    Map mapa = null;
    [SerializeField]
    TypSzukania typSzukania = TypSzukania.NONE;

    void init()
    {
        if (mapa == null)
            mapa = GameObject.Find("Map").GetComponent<Map>(); // init
    }
    public bool znajdź(Vector2Int pozycja)
    {
        if (typSzukania == TypSzukania.NONE)//nie chciano aby szukać to nie szukamy
        {
            return true;
        }

        init(); //inicjalizujemy
        
        bool znaleziono = false;

        Pole poleStartowe = mapa.getPole(pozycja);
        int movesToDo = promien;
        if (typSzukania == TypSzukania.POLE)
        {
            znaleziono = sprawdzRozgalezieniaPole(movesToDo, poleStartowe, poleStartowe);
        }
        else
        {
            znaleziono = sprawdzRozgalezieniaBudynek(movesToDo, poleStartowe, poleStartowe);
        }

        Debug.Log("Czy znaleziono: " + znaleziono);

        return znaleziono;
    }
    bool sprawdzRozgalezieniaPole(int moves, Pole next, Pole curr)
    {
        
        if (next.Up.typ == doZnalezieniaPole && next.Up != curr || next.Down.typ == doZnalezieniaPole && next.Down != curr || next.Left.typ == doZnalezieniaPole && next.Left != curr || next.Right.typ == doZnalezieniaPole && next.Right != curr)
            return true;
        else
        {
            moves--;
            if (moves == 0)
                return false;

            bool tmp = false;
            tmp = sprawdzRozgalezieniaPole(moves, next.Up,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaPole(moves, next.Down,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaPole(moves, next.Left,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaPole(moves, next.Right,next);
            return tmp;

        }
    }
    /// <summary>
    /// Wizualizacja sprawdzania rozgałęzień
    /// </summary>
    /// <param name="moves">pozostała ilość ruchów</param>
    /// <param name="next"> pole do sprawdzenia</param>
    bool sprawdzRozgalezieniaPoleVis(int moves, Pole next, Pole curr)
    {
        Debug.Log(next.cords.ToString());
        if (next.Up.typ == doZnalezieniaPole && next.Up != curr)
        {
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Down.typ == doZnalezieniaPole && next.Down != curr)
        {
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Left.typ == doZnalezieniaPole && next.Left != curr)
        {
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (next.Right.typ == doZnalezieniaPole && next.Right != curr)
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
        tmp = sprawdzRozgalezieniaPoleVis(moves, next.Up, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaPoleVis(moves, next.Down, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaPoleVis(moves, next.Left, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaPoleVis(moves, next.Right, curr);
        return tmp;
    }
    bool sprawdzRozgalezieniaBudynek(int moves, Pole next, Pole curr)
    {
        
        if (next.Up.budynek != null && next.Up.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Up != curr || next.Down.budynek != null && next.Down.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek&& next.Down != curr || next.Left.budynek != null && next.Left.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Left != curr || next.Right.budynek != null && next.Right.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Right !=curr)
            return true;
        else
        {
            moves--;
            if (moves == 0)
                return false;

            bool tmp = false;
            tmp = sprawdzRozgalezieniaBudynek(moves, next.Up,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaBudynek(moves, next.Down,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaBudynek(moves, next.Left,next);
            if (tmp == true)
                return true;
            tmp = sprawdzRozgalezieniaBudynek(moves, next.Right,next);
            return tmp;

        }
    }
    /// <summary>
    /// Wizualizacja sprawdzania rozgałęzień
    /// </summary>
    /// <param name="moves">pozostała ilość ruchów</param>
    /// <param name="next"> pole do sprawdzenia</param>
    bool sprawdzRozgalezieniaBudynekVis(int moves, Pole next, Pole curr)
    {
        Debug.Log(next.cords.ToString());
        if (next.Up.budynek != null && next.Up.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Up != curr)
        {
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Up.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }

        if (next.Down.budynek != null && next.Down.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Down != curr)
        {
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Down.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }

        if (next.Left.budynek != null && next.Left.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Left != curr)
        {
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(0,1,0,1);
            return true;
        }
        else{
            next.Left.mesh.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }

        if (next.Right.budynek != null && next.Right.budynek.GetComponent<Budynek>().typ == doZnalezieniaBudynek && next.Right != curr)
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
        tmp = sprawdzRozgalezieniaBudynekVis(moves, next.Up, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaBudynekVis(moves, next.Down, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaBudynekVis(moves, next.Left, curr);
        if (tmp == true)
            return true;
        tmp = sprawdzRozgalezieniaBudynekVis(moves, next.Right, curr);
        return tmp;
    }

    public enum TypSzukania
    {
        NONE,
        POLE,
        BUDYNEK
    }
}