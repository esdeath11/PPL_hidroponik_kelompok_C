using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_nav_GB : MonoBehaviour
{
    [SerializeField] Image alert, waterBar;
    [SerializeField] Text alert_harverst;
    public static bool harvest, plant_stat;
    int toggle_harvest;
    Watering water;
    // Start is called before the first frame update
    void Start()
    {
        water = new Watering();
        toggle_harvest = 1;
        harvest = false;
        plant_stat = false;
    }


    private void Update()
    {
        decoyWater();
    }

    void checkWater()
    {
        if(water.waterAmount < 1)
        {
            Time.timeScale = 0;
            Growth_GP.status_gameOver = true;
        }
    }


    public void addWater()
    {
        if (water.waterAmount < 95)
        {
            water.waterAmount += 10;
        }
        if (water.waterAmount > 95 && water.waterAmount <= 100)
        {
            water.waterAmount = 100;
        }

    }


    void decoyWater()
    {
        if(plant_stat == true)
        {
            water.Update();
            waterBar.fillAmount = water.GetWaterNormalized();
        }
        else
        {

        }
       
    }

    public void switchHarvest()
    {
        switch (toggle_harvest)
        {
            case 1:
                harvest = true;
                alert.rectTransform.anchoredPosition = new Vector2(-182, -60);
                toggle_harvest = 2;
                alert_harverst.text = "Harvest Actived";
                break;
            case 2:
                harvest = false;
                toggle_harvest = 1;
                alert.rectTransform.anchoredPosition = new Vector2(-182, -60);
                alert_harverst.text = "Harvest Deactived";
                break;
        }
    }

    public void confirm()
    {
        alert.rectTransform.anchoredPosition = new Vector2(-2769, -60);
    }
}

public class Watering
{

    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;
    private float waterDecoyNight;

    public Watering()
    {
        waterAmount = 100f;
        waterDecoy = 2.4f;
        waterDecoyNight = 1.2f;
    }

    public void Update()
    {
        waterAmount -= waterDecoy * Time.deltaTime;
    }

    public void Update2()
    {
        waterAmount -= waterDecoyNight * Time.deltaTime;
    }

    public float GetWaterNormalized()
    {
        return waterAmount / MAX_WATER;
    }
}