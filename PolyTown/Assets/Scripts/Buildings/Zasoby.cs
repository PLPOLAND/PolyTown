using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Zasoby
{
    [SerializeField]
    private float maxPojemnosc;
    [SerializeField]
    private float drewno;
    [SerializeField]
    private float woda;
    [SerializeField]
    private float jagody;
    [SerializeField]
    private float pieniadze;
    public Zasoby(){
        this.maxPojemnosc = 0;
        this.drewno = 0;
        this.woda = 0;
        this.jagody = 0;
        this.pieniadze = 0;
    }

    public Zasoby(float maxPojemnosc, float drewno, float woda, float jagody, float pieniadze){
        this.maxPojemnosc = maxPojemnosc;
        this.drewno = drewno;
        this.woda = woda;
        this.jagody = jagody;
        this.pieniadze = pieniadze;
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
    public void setPieniadze(float newPieniadze){
        pieniadze = newPieniadze;
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
    public float addPieniadze(float addPieniadze){
        var over = 0f;
        pieniadze += addPieniadze;
        if (pieniadze > maxPojemnosc)
        {
            over = pieniadze - maxPojemnosc;
        }
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
    public void subPieniadze(float subPieniadze){
        pieniadze -= subPieniadze;
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
    public float getPieniadze(){
        return pieniadze;
    }
    /// <summary>
    /// Dodaj zasoby (drewno, woda, jagody, pojemnosc)
    /// </summary>
    public Zasoby add(Zasoby zasobyAdd){
        Zasoby over = new Zasoby();
        
        addPojemnosc(zasobyAdd.maxPojemnosc);
        over.drewno += addDrewno(zasobyAdd.drewno);
        over.woda += addWoda(zasobyAdd.woda);
        over.jagody += addJagody(zasobyAdd.jagody);
        return over;
    }

    /// <summary>
    /// Dodaj zasoby (drewno, woda, jagody, pojemnosc, pieniadze)
    /// </summary>
    public Zasoby addWithPieniadze(Zasoby zasobyAdd){
        Zasoby over = new Zasoby();
        
        addPojemnosc(zasobyAdd.maxPojemnosc);
        over.drewno += addDrewno(zasobyAdd.drewno);
        over.woda += addWoda(zasobyAdd.woda);
        over.jagody += addJagody(zasobyAdd.jagody);
        over.pieniadze += addPieniadze(zasobyAdd.pieniadze);
        return over;
    }
    /// <summary>
    /// Dodaj zasoby (drewno, woda, jagody)
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
    /// <summary>
    /// Odejmuje zasoby (Drewno, Woda, Jagody, Pieniadze)
    /// </summary>
    public void subWithPieniadze(Zasoby zasobySub)
    {
        subDrewno(zasobySub.drewno);
        subWoda(zasobySub.woda);
        subJagody(zasobySub.jagody);
        subPieniadze(zasobySub.pieniadze);
    }

    public bool isOkToSub(Zasoby zasobySub){
        bool ok = true;
        if (drewno - zasobySub.drewno < 0)
            ok = false;
        if (woda - zasobySub.woda < 0)
            ok = false;
        if (jagody - zasobySub.jagody < 0)
            ok = false;
        return ok;
    }

    public bool isOkToSubMoney(Zasoby zasobySub){
        bool ok = true;
        if (pieniadze - zasobySub.pieniadze < 0)
        {
            ok = false;
        }
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
