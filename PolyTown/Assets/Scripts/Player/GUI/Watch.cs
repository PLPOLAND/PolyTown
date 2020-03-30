using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Watch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    DateTime time;
    void Start()
    {
        time = DateTime.Now;
        m_Object.text = time.Hour+":"+time.Minute;
    }
    private void Update() {
        time = DateTime.Now;
        m_Object.text = time.Hour + ":" + time.Minute;
    }
}
