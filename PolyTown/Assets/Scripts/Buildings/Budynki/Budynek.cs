using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using UnityEngine;

public class Budynek : MonoBehaviour
{
    [SerializeField]
    public float onTime = 10f;//czas co który zostają dodane zasoby cykliczne (w sekundach)
    [SerializeField]
    protected float onTimeMagazyn = 0f;
    [SerializeField]
    public Zasoby zasobyCykliczne;//zasoby pobieranie w określonym czasie(on time)
    [SerializeField]
    public Zasoby zasobyPoczątkowe;//zasoby pobierane podczas stawiania budynku
    protected float timer = 0f;
    protected float timerCzynsz = 0f;
    public float timerMagazyn = 0f;
    protected Zasoby zasobyGraczaLink;

    [SerializeField]
    public Zasoby magazynWewnetrzny = new Zasoby();
    [SerializeField]
    protected Zasoby doPobraniaZmagazynu = null;
    private bool czyPobranoZasoby = false; //flaga informująca o poprawnym pobraniu zasobów z magazynu głównego.
    [SerializeField]
    private bool czyPobieraZasoby = false; //flaga inforująca o tym czy budynek pobiera zasoby.
    protected float timerWewnetrzny = 0f;
    public Vector2Int pozycjaNaMapie;
    [SerializeField]
    public ResourceFinder finder;
    [SerializeField]
    public BudynekType typ = BudynekType.NONE;
    protected void init()
    {
        zasobyGraczaLink = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    private void OnDestroy()
    {
        if (zasobyGraczaLink != null && zasobyPoczątkowe != null)
            zasobyGraczaLink.add(zasobyPoczątkowe);
    }
    protected void produkujZasoby()
    {
        timer += Time.deltaTime;
        if (timer >= onTime)
        {
            timer = 0;
            wyslijDoMagazynuWewnetrzenego(zasobyCykliczne);//Zasoby trafiają do magazynu wewnetrznego z którego następnie są wysyłane do magazynu głównego
        }
    }

    protected void pobierzZasoby(){
        timer += Time.deltaTime;
        if(timer >= onTime){
            timer = 0;
            if (zasobyGraczaLink.isOkToSub(zasobyCykliczne))
            {
                czyPobranoZasoby = true;
                zasobyGraczaLink.sub(zasobyCykliczne);
            }
            else
            {
                czyPobranoZasoby = false;
            }
        }
    }

    protected void wyslijDoMagazynuWewnetrzenego(Zasoby zasoby)
    {
        magazynWewnetrzny.addNPojemnosc(zasoby);
    }
    protected void wyslijZMagazynu()
    {
        timerMagazyn += Time.deltaTime;
        if (timerMagazyn >= onTimeMagazyn)
        {
            timerMagazyn = 0;
            switch (this.typ)
            {
                case BudynekType.DRWAL:
                    if (zasobyGraczaLink.isOkToAddDrewno(doPobraniaZmagazynu) && magazynWewnetrzny.isOkToSubDrewno(doPobraniaZmagazynu))
                        {
                            zasobyGraczaLink.add(doPobraniaZmagazynu);
                            magazynWewnetrzny.subNPojemnosc(doPobraniaZmagazynu);
                        }
                    break;
                case BudynekType.STUDNIA:
                    if (zasobyGraczaLink.isOkToAddWoda(doPobraniaZmagazynu) && magazynWewnetrzny.isOkToSubWoda(doPobraniaZmagazynu))
                        {
                            zasobyGraczaLink.add(doPobraniaZmagazynu);
                            magazynWewnetrzny.subNPojemnosc(doPobraniaZmagazynu);
                        }
                    break;
                case BudynekType.ZBIERACZEJAGOD:
                    if (zasobyGraczaLink.isOkToAddJagody(doPobraniaZmagazynu) && magazynWewnetrzny.isOkToSubJagody(doPobraniaZmagazynu))
                        {
                            zasobyGraczaLink.add(doPobraniaZmagazynu);
                            magazynWewnetrzny.subNPojemnosc(doPobraniaZmagazynu);
                        }
                    break;
            }
            
        }
    }

    protected void czynsz(){
        timerCzynsz += Time.deltaTime;
        if (timerCzynsz >= onTime)
        {
            timerCzynsz = 0;
            if (czyPobieraZasoby == true)
            {
                if (czyPobranoZasoby == true)
                {
                    zasobyGraczaLink.addPieniadze(zasobyCykliczne.getPieniadze());
                }
            }
            else{
                zasobyGraczaLink.addPieniadze(zasobyCykliczne.getPieniadze());
            }
        }
    }
    [System.Serializable]
    public class BudynekToSave : ISerializable
    {
        public float maxPojemnosc;
        public float drewno;
        public float woda;
        public float jagody;
        public int pozycjaNaMapieX;
        public int pozycjaNaMapieY;
        public BudynekType typ = BudynekType.NONE;

        public BudynekToSave(Budynek b){
            maxPojemnosc = b.magazynWewnetrzny.getPojemnosc();
            drewno = b.magazynWewnetrzny.getDrewno();
            woda = b.magazynWewnetrzny.getWoda();
            jagody = b.magazynWewnetrzny.getJagody();
            pozycjaNaMapieX = b.pozycjaNaMapie.x;
            pozycjaNaMapieY = b.pozycjaNaMapie.y;
            typ = b.typ;
        }
        public BudynekToSave(SerializationInfo info, StreamingContext ctxt)
        {
            this.maxPojemnosc = (float)info.GetValue("maxPojemnosc", typeof(float));
            this.drewno = (float)info.GetValue("drewno", typeof(float));
            this.woda = (float)info.GetValue("woda", typeof(float));
            this.jagody = (float)info.GetValue("jagody", typeof(float));
            this.pozycjaNaMapieX = (int)info.GetValue("pozycjaNaMapieX", typeof(int));
            this.pozycjaNaMapieY = (int)info.GetValue("pozycjaNaMapieY", typeof(int));
            this.typ = (BudynekType)info.GetValue("typ", typeof(BudynekType));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("maxPojemnosc", this.maxPojemnosc);
            info.AddValue("drewno", this.drewno);
            info.AddValue("woda", this.woda);
            info.AddValue("jagody", this.jagody);
            info.AddValue("pozycjaNaMapieX", this.pozycjaNaMapieX);
            info.AddValue("pozycjaNaMapieY", this.pozycjaNaMapieY);
            info.AddValue("typ", this.typ);
        }
    }
}

public enum BudynekType
{
    NONE,
    DOM,
    DRWAL,
    ZBIERACZEJAGOD,
    STUDNIA,
    CENTRUM,
    MAGAZYN
}