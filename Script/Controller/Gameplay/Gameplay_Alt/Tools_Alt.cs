using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tools_Alt : MonoBehaviour
{
    [SerializeField] Image plant, plant1, plant2, plant3, plant4, plant5, plant6, plant7, plant8, plant9;
    [SerializeField] Sprite dry, wet, hole;
    [SerializeField] Text tools_rock;
    int toggle_rockwool;
    public static bool tools_rock_status;


    
    void Start()
    {
        toggle_rockwool = 1;
        tools_rock_status = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void toggle_rock()
    {
        if(tools_rock_status == false)
        {
            switch (toggle_rockwool)
            {
                case 1:
                    flush_rockAlt();
                    toggle_rockwool = 2;
                    tools_rock.text = "Perforated Rockwool";
                    break;
                case 2:
                    hole_rockAlt();
                    toggle_rockwool = 1;
                    tools_rock_status = true;
                    tools_rock.text = "Rockwool Ready";
                    break;
            }
        }
        
    }


    void flush_rockAlt()
    {
        plant.sprite = wet;
        plant1.sprite = wet;
        plant2.sprite = wet;
        plant3.sprite = wet;
        plant4.sprite = wet;
        plant5.sprite = wet;
        plant6.sprite = wet;
        plant7.sprite = wet;
        plant8.sprite = wet;
        plant9.sprite = wet;


    }

    void hole_rockAlt()
    {
        plant.sprite = hole;
        plant1.sprite = hole;
        plant2.sprite = hole;
        plant3.sprite = hole;
        plant4.sprite = hole;
        plant5.sprite = hole;
        plant6.sprite = hole;
        plant7.sprite = hole;
        plant8.sprite = hole;
        plant9.sprite = hole;

    }
}
