using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Paralon_Alt : MonoBehaviour
{
    [SerializeField] Image plant;
    [SerializeField] Sprite bayam1, bayam2, bayam3, selada1, selada2, selada3, dry;
    [SerializeField] Text plant_age;
    float timer, age;
    string id_plant;
    bool plant_status;
    

    public void planting()
    {
        Item_inventory.codePlant_bibit = "bibit_selada";
        Item_inventory.bibit_Selada = 3;
        if (Item_inventory.codePlant_bibit == "bibit_selada" && Item_inventory.bibit_Selada > 0)
        {
            Item_inventory.bibit_Selada -= 1;
            this.plant.sprite = selada1;
            this.id_plant = "selada";
            this.plant_status = true;
            UIParalonBar_alt.paralon_waterStatus = true;
        }

        else if(Item_inventory.codePlant_bibit == "bibit_bayam" && Item_inventory.bibit_bayam > 0)
        {
            Item_inventory.bibit_bayam -= 1;
            this.plant.sprite = bayam1;
            this.id_plant = "bayam";
            this.plant_status = true;
            UIParalonBar_alt.paralon_waterStatus = true;
        }
    }

    private void Update()
    {
        growthPlant();
        this.plant_age.text = this.age.ToString();
    }


    void growthPlant()
    {
        if(this.plant_status == true)
        {
            this.timer += Time.deltaTime;
            this.age = 10 + Mathf.Floor(this.timer % 60);
            growthchange();
        }
        
    }

    void growthchange()
    {
        if(this.id_plant == "selada")
        {
            if (this.age == 15)
            {
                this.plant.sprite = selada2;
            }
            if (this.age == 35)
            {
                this.plant.sprite = selada3;
            }
        }

        else if (this.id_plant == "bayam")
        {
            if (this.age == 15)
            {
                this.plant.sprite = bayam2;
            }
            if (this.age == 35)
            {
                this.plant.sprite = bayam3;
            }
        }

    }


    public void harvest()
    {
        if(Navigation_Alt.harvest_status == true && this.age >= 45)
        {
            this.plant.sprite = dry;
            Shop_GP.money_value += 3500;
        }
    }

}
