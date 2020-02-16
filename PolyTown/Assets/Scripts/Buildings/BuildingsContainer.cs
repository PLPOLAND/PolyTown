using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsContainer : MonoBehaviour
{

    List<Budynek> data;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Budynek Kontener Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBuilding(Vector2 pos){
        Debug.Log("addBuilding");
    }
}
