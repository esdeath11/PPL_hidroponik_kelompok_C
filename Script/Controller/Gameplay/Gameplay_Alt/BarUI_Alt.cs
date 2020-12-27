using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarUI_Alt : MonoBehaviour
{
    [SerializeField] Image water_rockwoolAlt;
    Misc_BarAlt misc_Bar;
    public static bool BarUI_GameOver_status;
    // Start is called before the first frame update
    void Start()
    {
        misc_Bar = new Misc_BarAlt();
        BarUI_GameOver_status = false;
    }

    // Update is called once per frame
    void Update()
    {
        waterDecoyUpdate();
    }

    void waterDecoyUpdate()
    {
        if(Tools_Alt.tools_rock_status == true)
        {
            misc_Bar.waterUpdate();
            water_rockwoolAlt.fillAmount = misc_Bar.GetWaterNormalized();
            checkAmountWater();
        }
        
    }

    void checkAmountWater()
    {
        if(misc_Bar.waterAmount < 1)
        {
            BarUI_GameOver_status = true;
        }
    }

    public void addWater_Alt()
    {
        if(misc_Bar.waterAmount < 80)
        {
            misc_Bar.waterAmount += 20;
        }
        else if(misc_Bar.waterAmount >= 80)
        {
            misc_Bar.waterAmount = 100;
        }
        
    }
}
