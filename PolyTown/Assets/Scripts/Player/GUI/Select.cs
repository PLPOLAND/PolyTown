using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public Button[] buttons = new Button[4];

    private ColorBlock normalColor;
    private ColorBlock selectedColor;


    private void Start() {
        normalColor = buttons[0].colors;
        selectedColor = buttons[0].colors;
        selectedColor.normalColor = selectedColor.selectedColor;
    }
    
    public void select(Button b){
        b.colors= selectedColor;
    }
    public void deselectAll(){
        foreach (var button in buttons)
        {
            button.colors = normalColor;
        }
    }
    
}
