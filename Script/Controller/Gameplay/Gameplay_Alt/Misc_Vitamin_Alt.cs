using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc_Vitamin_Alt
{
    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;

    public Misc_Vitamin_Alt()
    {
        waterAmount = 100f;
        waterDecoy = 1.4f;
    }

    public void decoyVitamin()
    {
        waterAmount -= waterDecoy * Time.deltaTime;
    }

    public float GetWaterNormalized()
    {
        return waterAmount / MAX_WATER;
    }
}
