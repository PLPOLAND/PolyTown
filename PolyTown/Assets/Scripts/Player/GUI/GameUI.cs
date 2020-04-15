using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI drewnoVal;
    public TextMeshProUGUI waterVal;
    public TextMeshProUGUI jagodyVal;
    Zasoby zasoby;
    public GameObject gameMenuPanel;
    public GameObject szczegolyBudynkuPanel;

    Player player;
    private void Start() {
        player = GameObject.Find("Player").GetComponent("Player") as Player;
        zasoby = player.zasoby;
    }
    void Update()
    {
        upadateZasobyText();
        kolorujLiczby();
        if (Input.GetKeyDown("escape")){
            if (!player.pause){
                gamePause();
                gameMenuPanel.SetActive(true);
                player.pause = true;
            }
            else{
                gamePlay();
                gameMenuPanel.SetActive(false);
                player.pause = false;
            }
            szczegolyBudynkuPanel.SetActive(false);
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
