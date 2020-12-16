using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Growth_GP : MonoBehaviour
{
    // Start is called before the first frame update
    private Water water;
    [SerializeField] Image thrist, Rwool;
    [SerializeField] Sprite biji, dry, tunas, leaf;
    [SerializeField] Text aging_value;
    int toggle_time;
    float age, timer, seconds;
    bool plant_status, harvest_status;

  
    void Start()
    {
        water = new Water();
        toggle_time = 1;
        this.plant_status = false;
    }

    // Update is called once per frame
    void Update()
    {

        checkplantwater();
        checkWaterConditions();
        
        this.aging();
        
    }

    
    public void Planting()
    {
        if (Item_inventory.codePlant == "selada" && Plating_GP.rockwool_status == true && Navigation_GP.status_Place == true)
        {
            Debug.Log(plant_status);
            if (plant_status == false)
            {
                if(Item_inventory.selada > 0)
                {
                    this.Rwool.sprite = biji;
                    Item_inventory.selada -= 1;
                    Debug.Log("Selada = " + Item_inventory.selada);
                    this.plant_status = true;
                }
                else
                {
                    Debug.Log("Biji selada tidak cukup silahkan beli");
                }

            }


        }

    }


    void checkplantwater()
    {
        if(this.plant_status == true)
        {
            loseWater();
        }
    }


    public void add_water()
    {
        if(Plating_GP.flush_stat == true)
        {
            if (this.water.waterAmount < 95)
            {
                this.water.waterAmount += 10;
            }
            if (this.water.waterAmount > 95 && this.water.waterAmount <= 100)
            {
                this.water.waterAmount = 100;
            }
        }
    }


    void aging() //not finished aging logic
    {
        if(this.plant_status == true)
        {
            if(this.seconds <= 9)
            {
                this.timer += Time.deltaTime;
                this.age = Mathf.Floor(timer / 60);
                this.seconds = Mathf.Floor(timer % 60);
                this.aging_value.text = this.seconds.ToString();
                this.growth();
            }

            else if(this.seconds >= 10)
            {
                Debug.Log("Paralon");
                age = 10;
                this.harvest_status = true;
            }
        }
        
    }


    public void Harvest()
    {
        if(harvest_status == true)
        {
            Rwool.sprite = dry;
            Item_inventory.bibit_Selada += 1;
            this.seconds = 0;
            timer = 0;
            this.plant_status = false;
            this.harvest_status = false;
        }

        else if(harvest_status == false)
        {

        }
    }

    void growth()
    {
        if(this.seconds >= 2 && this.seconds < 3)
        {
            Rwool.sprite = tunas;
        }

        if(this.seconds >= 4 && this.seconds<= 8)
        {
            Rwool.sprite = leaf;
        }
    }


    void checkWaterConditions()
    {
        if(this.water.waterAmount < 1 && this.plant_status == true)
        {
            Shop_GP.money_value -= 1 * (Mathf.FloorToInt(timer % 60));
        }
    }

    void loseWater()
    {
        if (toggle_time == 1)
        {
            if (water.waterAmount > 0)
            {
                this.water.Update();
                thrist.fillAmount = water.GetWaterNormalized();
            }

        }
        if (toggle_time == 2)
        {
            if (water.waterAmount > 0)
            {
                this.water.Update2();
                thrist.fillAmount = water.GetWaterNormalized();
            }

        }
    }
}

public class Water
{

    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;
    private float waterDecoyNight;

    public Water()
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

