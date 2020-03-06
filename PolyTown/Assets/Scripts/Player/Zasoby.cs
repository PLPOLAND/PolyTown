using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zasoby : MonoBehaviour
{
    double maxPojemnosc;
    double drewno;
    double woda;
    double jagody;
    void Start()
    {
        maxPojemnosc = 40;
        drewno = 40;
        woda = 6;
        jagody = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMaxPojemnosc(double newMax)
    {
        maxPojemnosc = newMax;
    }
    public void setDrewno(double newDrewno)
    {
        drewno = newDrewno;
    }
    public void setWoda(double newWoda)
    {
        woda = newWoda;
    }
    public void setJagody(double newJagody)
    {
        jagody = newJagody;
    }
    public void addPojemnosc(double addMax)
    {
        maxPojemnosc += addMax;
    }
    public void addDrewno(double addDrewno)
    {
        drewno += addDrewno;
        if (drewno > maxPojemnosc)
        {
            drewno = maxPojemnosc;
        }
    }
    public void addWoda(double addWoda){
        woda+=addWoda;
        if (woda>maxPojemnosc)
        {
            woda=maxPojemnosc;
        }
    }
    public void addJagody(double addJagody)
    {
        jagody += addJagody;
        if (jagody > maxPojemnosc)
        {
            jagody = maxPojemnosc;
        }
    }
    public void subPojemnosc(double subMax)
    {
        maxPojemnosc -= subMax;
        if (maxPojemnosc < 40)
        {
            maxPojemnosc = 40;//ustaw minimum
        }
    }
    public void subDrewno(double subDrewno)
    {
        drewno -= subDrewno;
        if (drewno > maxPojemnosc)
        {
            drewno = maxPojemnosc;
        }
    }
    public void subWoda(double subWoda)
    {
        woda -= subWoda;
        if (woda > maxPojemnosc)
        {
            woda = maxPojemnosc;
        }
    }
    public void subJagody(double subJagody)
    {
        jagody -= subJagody;
        if (jagody > maxPojemnosc)
        {
            jagody = maxPojemnosc;
        }
    }
    public double getPojemnosc()
    {
        return maxPojemnosc;
    }
    public double getDrewno()
    {
        return drewno;
    }
    public double getWoda()
    {
        return woda;
    }
    public double getJagody()
    {
        return jagody;
    }
}
