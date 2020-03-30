using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject dom;
    [SerializeField]
    private GameObject jagody;
    [SerializeField]
    private GameObject drwal;
    [SerializeField]
    private GameObject woda;
    private GameObject active;
    public bool isActive = false;
    protected Zasoby zasoby_gracza;
    private void Start()
    {
        zasoby_gracza = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    private void Update() {
        if (isActive == false)
        {
            active = null;
        }
        if (Input.GetKey("escape"))
        {
            isActive = false;
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
