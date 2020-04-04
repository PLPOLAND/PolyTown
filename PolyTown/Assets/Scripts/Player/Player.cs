using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Zasoby zasoby; // zasoby gracza
    public bool pause = false; // czy Gra jest zapauzowana

    private void Start() {
        pause = false;
    }

}
