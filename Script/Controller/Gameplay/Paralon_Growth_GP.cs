using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paralon_Growth_GP : MonoBehaviour
{
    [SerializeField] Image plant;
    [SerializeField] GameObject plant_object;
    [SerializeField] Sprite young_plant, harvest_plant, Bibit;
    [SerializeField] Text agePlant;
    float timer,age,seconds;
    bool harvest_status;
    public static bool growth_status;
    bool growth_inParalon;

    // Start is called before the first frame update
    void Start()
    {

        seconds = 10;
        age = 10;
    }

    // Update is called once per frame
    void Update()
    {
        this.harvest_status = Help_nav_GB.harvest;
        
        this.checkAging();
    }

    void checkAging()
    {
        if (Navigation_GP.plant_bibitStatus == true && Help_nav_GB.harvest == false && Navigation_GP.bibit_seladaInParalon > 0)
        {
            timer += Time.deltaTime;
            this.aging();
        }
    }


    void aging()
    {
       // this.age = Mathf.Floor(timer / 60);
        this.seconds = Mathf.Floor(timer % 60);
        this.age = this.seconds;
        this.agePlant.text = seconds.ToString();
        growth();
    }

    void growth()
    {
        if(age >= 15 && age <= 20)
        {
            this.plant.sprite = young_plant;
        }

        if(age >= 21)
        {
            this.plant.sprite = harvest_plant;
            this.harvest_status = true;
        }
    }


    public void collect()
    {

        if (this.harvest_status == true && Navigation_GP.bibit_seladaInParalon > 0)
        {
            this.plant.sprite = Bibit;
            this.plant_object.SetActive(false);
            Navigation_GP.bibit_seladaInParalon -= 1;
            Shop_GP.money_value += 3500;
        }
    }

}

