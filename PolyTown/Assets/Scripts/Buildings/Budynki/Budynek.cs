using System.Collections;
using System.Collections.Generic;
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
    protected float timerMagazyn = 0f;
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
            if (zasobyGraczaLink.isOkToAdd(doPobraniaZmagazynu) && magazynWewnetrzny.isOkToAdd(doPobraniaZmagazynu))
            {
                zasobyGraczaLink.add(doPobraniaZmagazynu);
                magazynWewnetrzny.subNPojemnosc(doPobraniaZmagazynu);
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
    public class BudynekToSave
    {
        float maxPojemnosc;
        float drewno;
        float woda;
        float jagody;
        int pozycjaNaMapieX;
        int pozycjaNaMapieY;
        BudynekType typ = BudynekType.NONE;

        public BudynekToSave(Budynek b){
            maxPojemnosc = b.magazynWewnetrzny.getPojemnosc();
            drewno = b.magazynWewnetrzny.getDrewno();
            woda = b.magazynWewnetrzny.getWoda();
            jagody = b.magazynWewnetrzny.getJagody();
            pozycjaNaMapieX = b.pozycjaNaMapie.x;
            pozycjaNaMapieY = b.pozycjaNaMapie.y;
            typ = b.typ;
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