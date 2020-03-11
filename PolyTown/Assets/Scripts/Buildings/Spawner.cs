using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dom;

    public void spawn(Vector2Int pozycja){
        var budynek = MonoBehaviour.Instantiate(dom);
        var map = GameObject.Find("Map").GetComponent("Map") as Map;
        budynek.transform.position = map.getPositionOfPole(pozycja);
    }
}
