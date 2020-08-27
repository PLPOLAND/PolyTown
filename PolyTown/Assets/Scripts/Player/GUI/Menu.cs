using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject settingsCanva;
    public GameObject mainMenuCanva;
    public Button wczytajButton;
    SaveSystem saveSystem;
    private void Start() {
        saveSystem = GameObject.Find("SaveMenager").GetComponent<SaveSystem>();

        if (!saveSystem.issaveFileExist("save")){
            if (wczytajButton!=null)
            {
                wczytajButton.interactable = false;
            }
        }
        else{
            if (wczytajButton != null)
            {
                wczytajButton.interactable = true;
            }
        }
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
        saveSystem.save("save");
    }
    public void loadGame(){
        saveSystem.shouldLoad = true;
        SceneManager.LoadScene(1);
    }
    public void options(){
            mainMenuCanva.SetActive(false);
            settingsCanva.SetActive(true);
    }


}
