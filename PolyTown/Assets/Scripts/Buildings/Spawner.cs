using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * <summary>
 * Klasa odpowiadająca za budowanie budynków.
 * </summary>
 */
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject dom;//Dom Poziom1
    [SerializeField]
    private GameObject jagody;//Zbieraczej jagód
    [SerializeField]
    private GameObject drwal;//Hata Drwala
    [SerializeField]
    private GameObject woda; //Studnia

    private GameObject active; //Aktualnie wybrany obiekt do budowy
    public bool isActive = false; //wskaźnik czy aktualnie użytkownik ma zamiar budować.
    protected Zasoby zasoby_gracza; //Odnośnik do obiektu przechowującego 
    private void Start()
    {
        zasoby_gracza = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    private void Update() {
        if (isActive == false)
        {
            active = null;
        }
        if (Input.GetKeyDown("escape"))
        {
            isActive = false;
        }
        if(Input.GetKeyDown(",")){
            active.transform.RotateAround(new Vector3(), Vector3.up, 90f);
        }
        if (Input.GetKeyDown(".")){
            active.transform.RotateAround(new Vector3(), Vector3.up, -90f);
        }
    }
    public void spawn(Vector2Int pozycja)
    {

        var zasobyDoOdjęciaNaStart = (active.GetComponent("Budynek") as Budynek).zasobyPoczątkowe;
        if (zasoby_gracza.isOkToSub(zasobyDoOdjęciaNaStart))
        {
            var okToBuild = (GameObject.Find("Map").GetComponent("Map") as Map).mapa[pozycja.x, pozycja.y].canBuild;
            if (okToBuild)
            {
                var budynek = MonoBehaviour.Instantiate(active);
                budynek.transform.position = (GameObject.Find("Map").GetComponent("Map") as Map).getPositionOfPole(pozycja);
                zasoby_gracza.sub(zasobyDoOdjęciaNaStart);
                (GameObject.Find("Map").GetComponent("Map") as Map).mapa[pozycja.x, pozycja.y].canBuild = false;
            }
        }
    }

    public void setJagody(){
        isActive = true;
        active = jagody;
    }
    public void setDom(){
        isActive = true;
        active = dom;
    }
    public void setWoda(){
        isActive = true;
        active = woda;
    }
    public void setDrwal(){
        isActive = true;
        active = drwal;
    }
}
