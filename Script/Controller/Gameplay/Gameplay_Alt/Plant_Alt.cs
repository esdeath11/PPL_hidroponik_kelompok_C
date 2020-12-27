using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Plant_Alt : MonoBehaviour
{
    [SerializeField] Image plant;
    [SerializeField] Text plant_age;
    [SerializeField] Sprite selada_seed, bayam_seed, selada_sprout, selada_leaf, bayam_sprout, bayam_leaf, dry;
    string id_plantAlt;
    float timer, age;
    bool plant_status;
    public static int bibit_selada, bibit_bayam;
    
    void Start()
    {
        plant_status = false;
    }

    // Update is called once per frame
    void Update()
    {
        growth_PlantAlt();
        this.plant_age.text = age.ToString();
    }

    public void planting()
    {
        if(Tools_Alt.tools_rock_status == true && Navigation_Alt.harvest_status == false && plant_status == false)
        {
            Debug.Log(Plating_GP.rockwool_status);
            check_seed();
        }
        
    }

    void check_seed()
    {
        if(Item_inventory.codePlant == "selada" && Item_inventory.selada > 0)
        {
            Item_inventory.selada -= 1;
            this.plant.sprite = selada_seed;
            id_plantAlt = "selada";
            Debug.Log(Item_inventory.codePlant);
            this.plant_status = true;
        }

        else if(Item_inventory.codePlant == "bayam" && Item_inventory.bayam > 0)
        {
            Item_inventory.bayam -= 1;
            this.plant.sprite = bayam_seed;
            this.plant_status = true;
            id_plantAlt = "bayam";
            Debug.Log(Item_inventory.codePlant);
        }
    }


    void growth_PlantAlt()
    {
        if(plant_status == true)
        {
            this.timer += Time.deltaTime;
            this.age = Mathf.Floor(timer % 60);
            this.growth_changeAlt();
        }
        
    }

    void growth_changeAlt()
    {
        if(id_plantAlt == "selada")
        {
            if (this.age > 3 && this.age < 5)
            {
                this.plant.sprite = selada_sprout;
            }
            if (this.age >= 6 && this.age <= 7)
            {
                this.plant.sprite = selada_leaf;
            }
            if(this.age >= 10)
            {
                this.age = 10;
            }
        }
        else if(id_plantAlt == "bayam")
        {
            if (this.age >= 3 && this.age <= 5)
            {
                this.plant.sprite = bayam_sprout;
            }
            if (this.age >= 6 && this.age <= 7)
            {
                this.plant.sprite = bayam_leaf;
            }
            if(this.age >= 10)
            {
                this.age = 10;
            }
        }
       
    }


    public void harvest()
    {
        if(Navigation_Alt.harvest_status == true)
        {
            this.plant.sprite = dry;
            
            if(this.id_plantAlt == "selada")
            {
                this.age = 0;
                Item_inventory.bibit_Selada += 1;
            }

            else if(this.id_plantAlt == "bayam")
            {
                this.age = 0;
                Item_inventory.bibit_bayam += 1;
            }
        }
    }
}
