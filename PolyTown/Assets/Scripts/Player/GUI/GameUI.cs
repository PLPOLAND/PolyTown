using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text drewnoVal;
    public Text waterVal;
    public Text jagodyVal;

    void Update()
    {
        Zasoby zasoby = GameObject.Find("Player").GetComponent("Zasoby") as Zasoby;

        drewnoVal.text = zasoby.getDrewno().ToString() + "/" + zasoby.getPojemnosc().ToString();
        waterVal.text = zasoby.getWoda().ToString() + "/" + zasoby.getPojemnosc().ToString();
        jagodyVal.text = zasoby.getJagody().ToString() + "/" + zasoby.getPojemnosc().ToString();
        if (zasoby.getWoda() < 5)
        {
            waterVal.color = new Color(1, 0, 0);
        }
        else
        {
            waterVal.color = new Color(1, 1, 1);
        }
        if (zasoby.getJagody() < 5)
        {
            jagodyVal.color = new Color(1, 0, 0);
        }
        else
        {
            jagodyVal.color = new Color(1, 1, 1);
        }
        if (zasoby.getDrewno() < 5)
        {
            drewnoVal.color = new Color(1, 0, 0);
        }
        else
        {
            drewnoVal.color = new Color(1, 1, 1);
        }
    }
}
