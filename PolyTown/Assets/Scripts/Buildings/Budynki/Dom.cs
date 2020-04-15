using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dom : Budynek
{
    private void Start() {
        init();
    }
    void Update()
    {
        produkujZasoby();
        wyslijZMagazynu();
    }
}
