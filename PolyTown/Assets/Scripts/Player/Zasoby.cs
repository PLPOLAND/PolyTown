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
    public Zasoby(){
        this.maxPojemnosc = 0;
        this.drewno = 0;
        this.woda = 0;
        this.jagody = 0;
    }

    public Zasoby(float maxPojemnosc, float drewno, float woda, float jagody){
        this.maxPojemnosc = maxPojemnosc;
        this.drewno = drewno;
        this.woda = woda;
        this.jagody = jagody;
    }
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
    public float addDrewno(float addDrewno)
    {
        var over = 0f;
        drewno += addDrewno;
        if (drewno > maxPojemnosc){
            over = drewno - maxPojemnosc;
        }
        drewno = Mathf.Clamp(drewno, 0, maxPojemnosc);
        return over;
    }
    public float addWoda(float addWoda){
        var over = 0f;
        woda+=addWoda;
        if (woda > maxPojemnosc)
        {
            over = woda - maxPojemnosc;
        }
        woda = Mathf.Clamp(woda,0, maxPojemnosc);
        return over;
    }
    public float addJagody(float addJagody)
    {
        var over = 0f;
        jagody += addJagody;
        if (jagody > maxPojemnosc)
        {
            over = jagody - maxPojemnosc;
        }
        jagody = Mathf.Clamp(jagody,0, maxPojemnosc);
        return over;
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

    public Zasoby add(Zasoby zasobyAdd){
        Zasoby over = new Zasoby();
        
        addPojemnosc(zasobyAdd.maxPojemnosc);
        over.drewno += addDrewno(zasobyAdd.drewno);
        over.woda += addWoda(zasobyAdd.woda);
        over.jagody += addJagody(zasobyAdd.jagody);

        return over;
    }
    /// <summary>
    /// Dodaj zasoby bez pojemnosci
    /// </summary>
    public Zasoby addNPojemnosc(Zasoby zasobyAdd){
        Zasoby over = new Zasoby();

        over.drewno += addDrewno(zasobyAdd.drewno);
        over.woda += addWoda(zasobyAdd.woda);
        over.jagody += addJagody(zasobyAdd.jagody);

        return over;
    }
    public void sub(Zasoby zasobySub){
        subPojemnosc(zasobySub.maxPojemnosc);
        subDrewno(zasobySub.drewno);
        subWoda(zasobySub.woda);
        subJagody(zasobySub.jagody);
    }
    /// <summary>
    /// Odejmuje zasoby bez pojemnosci
    /// </summary>
    /// <param name="zasobySub"></param>
    public void subNPojemnosc(Zasoby zasobySub){
        subDrewno(zasobySub.drewno);
        subWoda(zasobySub.woda);
        subJagody(zasobySub.jagody);
    }
    public bool isOkToSub(Zasoby zasobyAdd){
        bool ok = true;
        if (drewno - zasobyAdd.drewno < 0)
            ok = false;
        if (woda - zasobyAdd.woda < 0)
            ok = false;
        if (jagody - zasobyAdd.jagody < 0)
            ok = false;
        return ok;
    }
    public bool isFull(ZasobTyp typ){
        switch(typ){
            case ZasobTyp.NONE:
                return false;
            case ZasobTyp.WODA:
                if (woda == maxPojemnosc)
                    return true;
                return false;
            case ZasobTyp.DREWNO:
                if (drewno == maxPojemnosc)
                    return true;
                return false;
            case ZasobTyp.JAGODY:
                if (jagody == maxPojemnosc)
                    return true;
                return false;
            default: 
            return false;
        }
    }

    public bool isOkToAdd(Zasoby zasobyAdd){
        bool ok = true;
        if (drewno + zasobyAdd.drewno > maxPojemnosc)
            ok = false;
        if (woda + zasobyAdd.woda > maxPojemnosc)
            ok = false;
        if (jagody + zasobyAdd.jagody > maxPojemnosc)
            ok = false;
        return ok;

    }
    public enum ZasobTyp
    {
        NONE,
        WODA,
        DREWNO,
        JAGODY
    }
}
