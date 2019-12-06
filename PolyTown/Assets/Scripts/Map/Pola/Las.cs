using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las :  Pole
{

    public Las():base()
    {
        Debug.LogWarning("Wygenerowano Las(). Czy napewno tego oczekiwano?");
        canBuild = true;
    }
}
