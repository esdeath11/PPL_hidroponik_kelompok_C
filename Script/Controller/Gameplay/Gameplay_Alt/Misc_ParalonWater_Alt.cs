using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc_ParalonWater_Alt
{
    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;

    public Misc_ParalonWater_Alt()
    {
        waterAmount = 100f;
        waterDecoy = 3.4f;
    }

    public void decoyWater()
    {
        waterAmount -= waterDecoy * Time.deltaTime;
    }

    public float GetWaterNormalized()
    {
        return waterAmount / MAX_WATER;
    }
}
