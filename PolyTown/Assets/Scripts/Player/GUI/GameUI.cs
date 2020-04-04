using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text drewnoVal;
    public Text waterVal;
    public Text jagodyVal;
    Zasoby zasoby;
    public GameObject panel;
    bool pause = false;
    private void Start() {
        Player player = GameObject.Find("Player").GetComponent("Player") as Player;
        zasoby = player.zasoby;   
    }
    void Update()
    {
        upadateZasobyText();
        kolorujLiczby();
        if (Input.GetKeyDown("escape")){
            if (!pause){
                gamePause();
                panel.SetActive(true);
                pause = true;
            }
            else{
                gamePlay();
                panel.SetActive(false);
                pause = false;
            }
        }
    }

    void upadateZasobyText(){
        drewnoVal.text = ((int)zasoby.getDrewno()).ToString() + "/" + ((int)zasoby.getPojemnosc()).ToString();
        waterVal.text = ((int)zasoby.getWoda()).ToString() + "/" + ((int)zasoby.getPojemnosc()).ToString();
        jagodyVal.text = ((int)zasoby.getJagody()).ToString() + "/" + ((int)zasoby.getPojemnosc()).ToString();
    }
    void kolorujLiczby(){
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
    public void gamePause(){
        Time.timeScale = 0;
    }
    public void gamePlay(){
        Time.timeScale = 1;
    }
}
