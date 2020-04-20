using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieraczeJagod : Budynek
{
    private void Start()
    {
        init();
    }
    void Update()
    {
        produkujZasoby();
        wyslijZMagazynu();
        czynsz();
    }
}
