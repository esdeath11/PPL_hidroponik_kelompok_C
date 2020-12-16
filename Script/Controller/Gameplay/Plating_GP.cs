using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plating_GP : MonoBehaviour
{
    [SerializeField] Image Rwool, Rwool1, Rwool2, Rwool3, Rwool4, Rwool5, Rwool6, Rwool7, Rwool8, Rwool9, SiramAlert;
    [SerializeField] Sprite wet, dry, hole;
    [SerializeField] Text name_Rwool, Siram_Alert;
    public static int toggle_rwool, toggle_flush;
    public static bool flush_stat, rockwool_status;

   


    void Start()
    {
        
        toggle_rwool = 1;
        rockwool_status = false;
        toggle_flush = 1;
    }

    
    public void editRockwool()
    {
        if(Item_inventory.status_Rock == true)
        {
            switch (toggle_rwool)
            {
                case 1:
                    Rwool.sprite = wet;
                    Rwool1.sprite = wet;
                    Rwool2.sprite = wet;
                    Rwool3.sprite = wet;
                    Rwool4.sprite = wet;
                    Rwool5.sprite = wet;
                    Rwool6.sprite = wet;
                    Rwool7.sprite = wet;
                    Rwool8.sprite = wet;
                    Rwool9.sprite = wet;
                    name_Rwool.text = "Perforated Rockwool";
                    toggle_rwool = 2;
                    break;
                case 2:
                    Rwool.sprite = hole;
                    Rwool1.sprite = hole;
                    Rwool2.sprite = hole;
                    Rwool3.sprite = hole;
                    Rwool4.sprite = hole;
                    Rwool5.sprite = hole;
                    Rwool6.sprite = hole;
                    Rwool7.sprite = hole;
                    Rwool8.sprite = hole;
                    Rwool9.sprite = hole;
                    name_Rwool.text = "Rockwool Ready";
                    rockwool_status = true;
                    break;
            }
        }
        
    }


    public void cancelPlantSeed()
    {
        rockwool_status = false;
    }


    public void watering_access()
    {
        switch (toggle_flush)
        {
            case 1:
                flush_stat = true;
                toggle_flush = 2;
                SiramAlert.rectTransform.anchoredPosition = new Vector2(-170, -25.687f);
                Siram_Alert.text = "Siram Actived";
                break;
            case 2:
                toggle_flush = 1;
                Siram_Alert.text = "Siram Deactived";
                SiramAlert.rectTransform.anchoredPosition = new Vector2(-170, -25.687f);
                flush_stat = false;
                break;
        }
    }

    public void siram_AlertConfirm()
    {
        SiramAlert.rectTransform.anchoredPosition = new Vector2(-2811, -60);
    }




    private void Update()
    {

    }

    

}



