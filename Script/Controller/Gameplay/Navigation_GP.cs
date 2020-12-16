using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigation_GP : MonoBehaviour
{
    [SerializeField] GameObject plant, plant1, plant2, plant3, plant4, plant5, plant6, plant7, plant8, plant9;
    [SerializeField] Image invetory, shop, field, bigRockwool, Background, Paralon, exitAlert, water, over;
    int toggle_field, toggle_Place, toggle_paralon, toggle_harvest;
    public static bool status_Place, plant_bibitStatus, water_status, gameover_status;
    public static int bibit_seladaInParalon;
    ParalonWater paralonWater;

    void Start()
    {
        paralonWater = new ParalonWater();
        toggle_field = 1;
        toggle_Place = 1;
        toggle_paralon = 1;
        toggle_harvest = 1;
        status_Place = false;
    }

    public void closeInventory()
    {
        invetory.GetComponent<Image>().transform.position = new Vector2(-300, -300);
    }

    public void openInventory()
    {
        invetory.rectTransform.anchoredPosition = new Vector2(-230, -70);
        toggle_field = 1;
        field.rectTransform.anchoredPosition = new Vector2(-720, -738);
    }

    public void openShop()
    {
        shop.rectTransform.anchoredPosition = new Vector2(-230, -70);
        toggle_field = 1;
        field.rectTransform.anchoredPosition = new Vector2(-720, -738);
    }

    public void closeShop()
    {
        shop.GetComponent<Image>().transform.position = new Vector2(-500, -500);
    }

    public void toggleField()
    {
        if(Item_inventory.status_Rock == true)
        {
            switch (toggle_field)
            {
                case 1:
                    field.rectTransform.anchoredPosition = new Vector2(-213, -59.495f);
                    toggle_field = 2;
                    break;
                case 2:
                    field.GetComponent<Image>().transform.position = new Vector2(-720, -738);
                    toggle_field = 1;
                    break;
            }
        }
        
        
    }

    public void cutRockwool()
    {
        if (Item_inventory.buy_rock_Status == true)
        {
            field.rectTransform.anchoredPosition = new Vector2(-205, -60);
            bigRockwool.GetComponent<Image>().transform.position = new Vector2(-1000, -1168);
            Item_inventory.status_Rock = true;
        }
        
    }


    public void switchPlace()
    {
        switch (toggle_Place)
        {
            case 1:
                Background.color = Color.black;
                status_Place = true;
                toggle_Place = 2;
                break;
            case 2:
                Background.color = Color.white;
                status_Place = false;
                toggle_Place = 1;
                break;
        }
    }

    public void switch_paralon()
    {
        switch (toggle_paralon)
        {
            case 1:
                Paralon.rectTransform.anchoredPosition = new Vector2(-223, -60);
                shop.GetComponent<Image>().transform.position = new Vector2(-500, -500);
                field.rectTransform.anchoredPosition = new Vector2(-720, -738);
                invetory.GetComponent<Image>().transform.position = new Vector2(-300, -300);
                toggle_paralon = 2;
                break;
            case 2:
                Paralon.rectTransform.anchoredPosition = new Vector2(-5274, -170);
                toggle_paralon = 1;
                break;
        }
    }

    public void Harvest()
    {
        switch (toggle_harvest)
        {
            case 1:
                
                toggle_harvest = 2;
                break;
            case 2:
                
                toggle_paralon = 1;
                break;
        }
    }

    public void add_bibit()
    {
        if (Item_inventory.codePlant_bibit == "bibit_selada" && Item_inventory.bibit_Selada > 0)
        {
            water_status = true;
            Item_inventory.bibit_Selada -= 1;
            bibit_seladaInParalon += 1;
            plant_bibitStatus = true;
            planting();

        }
    }

    void planting()
    {
        if(bibit_seladaInParalon == 1)
        {
            plant.SetActive(true);
        }

        if (bibit_seladaInParalon == 2)
        {
            plant1.SetActive(true);
        }

        if (bibit_seladaInParalon == 3)
        {
            plant2.SetActive(true);
        }

        if (bibit_seladaInParalon == 4)
        {
            plant3.SetActive(true);
        }

        if (bibit_seladaInParalon == 5)
        {
            plant4.SetActive(true);
        }

        if (bibit_seladaInParalon == 6)
        {
            plant5.SetActive(true);
        }

        if (bibit_seladaInParalon == 7)
        {
            plant6.SetActive(true);
        }

        if (bibit_seladaInParalon == 8)
        {
            plant7.SetActive(true);
        }

        if (bibit_seladaInParalon == 9)
        {
            plant8.SetActive(true);
        }
        if (bibit_seladaInParalon == 10)
        {
            plant9.SetActive(true);
        }
    }


    public void exitValidation()
    {
        exitAlert.rectTransform.anchoredPosition = new Vector2(-196, -26.394f);
    }

    public void exitAnswerYes()
    {
        Loading_auth.saveGame();
        SceneManager.LoadScene("Loading");
        
    }

    public void exitAnswerNo()
    {
        exitAlert.rectTransform.anchoredPosition = new Vector2(-1772, 117);
    }

    public void addWater()
    {
        if(paralonWater.waterAmount <= 80)
        {
            paralonWater.waterAmount += 20;
        }
        if(paralonWater.waterAmount >= 80)
        {
            paralonWater.waterAmount = 100;
        }
       
    }

    private void Update()
    {
        if (water_status == true && Help_nav_GB.harvest == false)
        {
            waterLose();
            gameOver();
        }
    }

    public void waterLose()
    {
        
        this.paralonWater.Update();
        this.water.fillAmount = paralonWater.GetWaterNormalized();
    }

    void gameOver()
    {
        if(paralonWater.waterAmount < 1)
        {
            over.rectTransform.anchoredPosition = new Vector2(-188, -60);
            Time.timeScale = 0;
        }
    }

    public void gameOverConfirm()
    {
        gameover_status = true;
        // Loading_auth.DestroyGameID();
        //  SceneManager.LoadScene("Loading");
        Application.Quit();
    }


}

public class ParalonWater
{
    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;
    private float waterDecoyNight;

    public ParalonWater()
    {
        waterAmount = 100f;
        waterDecoy = 16.4f;
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
