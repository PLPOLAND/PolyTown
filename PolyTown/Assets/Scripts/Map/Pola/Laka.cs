using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laka : Pole
{
    public Laka():base()
    {
        Debug.LogWarning("Wygenerowano Las(). Czy napewno tego oczekiwano?");
        canBuild = true;
    }

}
