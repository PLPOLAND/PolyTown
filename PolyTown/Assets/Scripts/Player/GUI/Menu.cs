using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject settingsCanva;
    public GameObject mainMenuCanva;
    private void Start() {
        
    }
    public void play(){
        SceneManager.LoadScene(1);
    }

    public void closeTheGame(){
        Application.Quit();
    }
    public void mainMenu(){
        SceneManager.LoadScene(0);
    }
    public void saveGame(){

    }
    public void loadGame(){

    }
    public void options(){
            mainMenuCanva.SetActive(false);
            settingsCanva.SetActive(true);
    }
}
