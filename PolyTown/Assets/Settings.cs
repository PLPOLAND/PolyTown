using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown jakosc;
    public GameObject settings;
    public GameObject mainMenu;
    void Start()
    {
        jakosc.value = QualitySettings.GetQualityLevel();
        Debug.Log(jakosc.value);
    }

    public void SetQuality (int qualiatyIndex){
        QualitySettings.SetQualityLevel(qualiatyIndex);
    }
    public void back(){
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
}
