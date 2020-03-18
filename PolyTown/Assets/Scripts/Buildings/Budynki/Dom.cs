using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dom : MonoBehaviour
{
    public const float onTime = 10f;
    [SerializeField]
    public Zasoby t;
    float timer = 0f;
    private void Start() {
        Debug.Log("DomSTART");
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=onTime)
        {
            timer = 0;
            // var zasoby = GameObject.Find("Player").GetComponent("Zasoby") as Zasoby;
            // zasoby.subJagody(1);
        }
    }
}
