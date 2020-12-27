using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc_BarAlt
{
    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;
    

    public Misc_BarAlt()
    {
        waterAmount = 100f;
        waterDecoy = 5.4f;
        
    }

    public void waterUpdate()
    {
        waterAmount -= waterDecoy * Time.deltaTime;
    }

    public float GetWaterNormalized()
    {
        return waterAmount / MAX_WATER;
    }



}
