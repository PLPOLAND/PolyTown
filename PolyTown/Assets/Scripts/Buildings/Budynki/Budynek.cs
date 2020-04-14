using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budynek : MonoBehaviour
{
    [SerializeField]
    public float onTime = 10f;//czas co który zostają dodane zasoby cykliczne (w sekundach)
    public Zasoby zasobyCykliczne;//zasoby pobieranie w określonym czasie(on time)
    public Zasoby zasobyPoczątkowe;//zasoby pobierane podczas stawiania budynku
    protected float timer = 0f;
    protected Zasoby zasobyGracza;
    protected Zasoby magazynWewnetrzny = new Zasoby();
    protected float timerWewnetrzny= 0f;
    public Vector2Int pozycjaNaMapie;
    public ResourceFinder finder;
    protected void init(){
         zasobyGracza = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    protected void produkujZasoby(){
        timer += Time.deltaTime;
        if (timer >= onTime)
        {
            timer = 0;
            wyslijDoMagazynuWewnetrzenego(zasobyGracza.add(zasobyCykliczne));//do magazynu wewnetrznego trafia nadmiar, który jest zwracany przez metodę add
        }
    }
    protected void wyslijDoMagazynuWewnetrzenego(Zasoby zasoby){
        magazynWewnetrzny.add(zasoby);
    }
}
