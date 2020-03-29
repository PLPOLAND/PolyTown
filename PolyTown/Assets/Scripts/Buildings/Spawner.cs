using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dom;
    protected Zasoby zasoby_gracza;
    private void Start()
    {
        zasoby_gracza = (GameObject.Find("Player").GetComponent("Player") as Player).zasoby;
    }
    public void spawn(Vector2Int pozycja)
    {

        var zasobyDoOdjęciaNaStart = (dom.GetComponent("Budynek") as Budynek).zasobyPoczątkowe;
        if (zasoby_gracza.isOkToSub(zasobyDoOdjęciaNaStart))
        {
            var okToBuild = (GameObject.Find("Map").GetComponent("Map") as Map).mapa[pozycja.x, pozycja.y].canBuild;
            if (okToBuild)
            {
                var budynek = MonoBehaviour.Instantiate(dom);
                budynek.transform.position = (GameObject.Find("Map").GetComponent("Map") as Map).getPositionOfPole(pozycja);
                zasoby_gracza.sub(zasobyDoOdjęciaNaStart);
                (GameObject.Find("Map").GetComponent("Map") as Map).mapa[pozycja.x, pozycja.y].canBuild = false;
            }
        }
    }
}
