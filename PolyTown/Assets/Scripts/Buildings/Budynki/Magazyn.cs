using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazyn : Budynek
{
    private void Start()
    {
        init();
    }
    void Update()
    {
        produkujZasoby();
    }
}