using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarVitamin_Alt : MonoBehaviour
{
    [SerializeField] Image vitaminBar;
    Misc_Vitamin_Alt misc_vitamin;
    public static bool status_vitamin;
    void Start()
    {
        status_vitamin = false;
        misc_vitamin = new Misc_Vitamin_Alt();
    }

    // Update is called once per frame
    void Update()
    {
        decoyVitaminAlt();
    }

    void decoyVitaminAlt()
    {
        if (Tools_Alt.tools_rock_status == true)
        {
            misc_vitamin.decoyVitamin();
            vitaminBar.fillAmount = misc_vitamin.GetWaterNormalized();
            checkVitaminAlt();
        }
        
    }

    void checkVitaminAlt()
    {
        if(misc_vitamin.waterAmount < 1)
        {
            BarUI_Alt.BarUI_GameOver_status = true;
        }
    }

    public void add_vitaminAlt()
    {
        if(misc_vitamin.waterAmount < 85 && Item_inventory.vitamin > 0 && Navigation_Alt.vitamin_status == true)
        {
            Debug.Log("Masuk");
            Debug.Log(Navigation_Alt.vitamin_status);
            misc_vitamin.waterAmount += 15;
            Item_inventory.vitamin -= 15;
        }
        if(misc_vitamin.waterAmount >= 85 && Item_inventory.vitamin >= 15 && Navigation_Alt.vitamin_status == true)
        {
            misc_vitamin.waterAmount = 100;
            Item_inventory.vitamin -= 15;
        }
    }
}
