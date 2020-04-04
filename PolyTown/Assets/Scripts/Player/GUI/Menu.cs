using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
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
}
