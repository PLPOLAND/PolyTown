using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budynek : MonoBehaviour
{
    [SerializeField]
    public float onTime = 10f;//czas co który zostają dodane zasoby cykliczne (w sekundach)
    [SerializeField]
    public Zasoby zasobyCykliczne;//zasoby pobieranie w określonym czasie(on time)
    [SerializeField]
    public Zasoby zasobyPoczątkowe;//zasoby pobierane podczas stawiania budynku
    protected float timer = 0f;
    protected float timerMagazyn = 0f;
    protected Zasoby zasobyGraczaLink;
    
    [SerializeField]
    public Zasoby magazynWewnetrzny = new Zasoby();
    [SerializeField]
    protected float onTimeMagazyn = 0f;
    [SerializeField]
    protected Zasoby doPobraniaZmagazynu = null;
    protected float timerWewnetrzny= 0f;
    public Vector2Int pozycjaNaMapie;
    [SerializeField]
    public ResourceFinder finder;
    [SerializeField]
    public BudynekType typ = BudynekType.NONE;
    protected void init(){
         zasobyGraczaLink = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    private void OnDestroy() {
        if(zasobyGraczaLink!= null && zasobyPoczątkowe!=null)
            zasobyGraczaLink.add(zasobyPoczątkowe);
    }
    protected void produkujZasoby(){
        timer += Time.deltaTime;
        if (timer >= onTime)
        {
            timer = 0;
            wyslijDoMagazynuWewnetrzenego(zasobyGraczaLink.add(zasobyCykliczne));//do magazynu wewnetrznego trafia nadmiar, który jest zwracany przez metodę add
        }
    }
    protected void wyslijDoMagazynuWewnetrzenego(Zasoby zasoby){
        magazynWewnetrzny.addNPojemnosc(zasoby);
    }
    protected void wyslijZMagazynu(){
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