using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Zasoby
{
    public float maxPojemnosc;
    public float drewno;
    public float woda;
    public float jagody;
    // void Start()
    // {
    //     maxPojemnosc = 40;
    //     drewno = 40;
    //     woda = 40;
    //     jagody = 40;
    // }

    public void setMaxPojemnosc(float newMax)
    {
        maxPojemnosc = newMax;
    }
    public void setDrewno(float newDrewno)
    {
        drewno = newDrewno;
    }
    public void setWoda(float newWoda)
    {
        woda = newWoda;
    }
    public void setJagody(float newJagody)
    {
        jagody = newJagody;
    }
    public void addPojemnosc(float addMax)
    {
        maxPojemnosc += addMax;
        maxPojemnosc = Mathf.Clamp(maxPojemnosc, 40, float.MaxValue);
    }
    public void addDrewno(float addDrewno)
    {
        drewno += addDrewno;
        drewno = Mathf.Clamp(drewno, 0, maxPojemnosc);
    }
    public void addWoda(float addWoda){
        woda+=addWoda;
        woda = Mathf.Clamp(woda,0, maxPojemnosc);
    }
    public void addJagody(float addJagody)
    {
        jagody += addJagody;
        jagody = Mathf.Clamp(jagody,0, maxPojemnosc);
    }
    public void subPojemnosc(float subMax)
    {
        maxPojemnosc -= subMax;
        maxPojemnosc = Mathf.Clamp(maxPojemnosc, 40, float.MaxValue);
    }
    public void subDrewno(float subDrewno)
    {
        drewno -= subDrewno;
        drewno = Mathf.Clamp(drewno,0, maxPojemnosc);
    }
    public void subWoda(float subWoda)
    {
        woda -= subWoda;
        woda = Mathf.Clamp(woda, 0, maxPojemnosc);
    }
    public void subJagody(float subJagody)
    {
        jagody -= subJagody;
        jagody = Mathf.Clamp(jagody, 0, maxPojemnosc);
    }
    public float getPojemnosc()
    {
        return maxPojemnosc;
    }
    public float getDrewno()
    {
        return drewno;
    }
    public float getWoda()
    {
        return woda;
    }
    public float getJagody()
    {
        return jagody;
    }
}
