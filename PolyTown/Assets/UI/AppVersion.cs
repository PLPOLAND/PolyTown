using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppVersion : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objDocelowy = null;
        void Start()
    {
        objDocelowy.text = "v " + Application.version;
    }
}
