using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIParalonBar_alt : MonoBehaviour
{
    [SerializeField] Image ParalonWater;
    Misc_ParalonWater_Alt misc_paralon;
    public static bool paralon_waterStatus;
    void Start()
    {
        misc_paralon = new Misc_ParalonWater_Alt();
        paralon_waterStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        decoyWaterParalon();
        checkWater();
    }

    void decoyWaterParalon()
    {
        if(paralon_waterStatus == true)
        {
            misc_paralon.decoyWater();
            ParalonWater.fillAmount = misc_paralon.GetWaterNormalized();
        }
        
    }


    void checkWater()
    {
        if(misc_paralon.waterAmount <= 0)
        {
            BarUI_Alt.BarUI_GameOver_status = true;
        }
    }

    public void addWater()
    {
        if(misc_paralon.waterAmount > 0 && misc_paralon.waterAmount < 80)
        {
            misc_paralon.waterAmount += 20;
        }

        if(misc_paralon.waterAmount >= 80)
        {
            misc_paralon.waterAmount = 100;
        }
    }
}
