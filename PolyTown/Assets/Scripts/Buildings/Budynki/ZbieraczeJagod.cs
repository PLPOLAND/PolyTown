﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieraczeJagod : Dom
{
    private void Start()
    {
        init();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= onTime)
        {
            timer = 0;
            zasobyGracza.add(zasobyCykliczne);
        }
    }
}
