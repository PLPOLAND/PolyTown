using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Console : MonoBehaviour
{
    [SerializeField]
    protected float timer = 0f;
    [SerializeField]
    static string text = "";
    public TextMeshProUGUI poletextowe;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        poletextowe.text = text;
        timer += Time.deltaTime;
        if (timer >= 2.5)
        {
            timer = 0;
            text ="";
        }

    }

    public void set(string s){
        text = s+"\n";
        timer = 0;
    }
    public void add(string a){
        text += a +"\n";
        timer = 0;
    }

}
