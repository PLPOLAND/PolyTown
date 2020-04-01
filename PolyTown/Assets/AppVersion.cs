using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppVersion : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
        void Start()
    {
        m_Object.text = "v " + Application.version;
    }
}
