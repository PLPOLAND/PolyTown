using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Watch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object = null;

    DateTime time;
    void Start()
    {
        time = DateTime.Now;
        m_Object.text = time.ToString("HH:mm");
    }
    private void Update() {
        time = DateTime.Now;
        m_Object.text = time.ToString("HH:mm");
    }
}
