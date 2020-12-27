using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Navigation_Alt : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image field, shop, inven, alert_harvest, single_rockWool_alt, sliced_rockwool_alt, paralon_alt;
    [SerializeField] Text harvest_text;
    public static bool harvest_status, vitamin_status;
    int toggle_harvest, toggle_vitamin;
    

    public void openField_Alt()
    {
        field.rectTransform.anchoredPosition = new Vector2(-208, -69);
    }

    public void closeField_Alt()
    {
        field.rectTransform.anchoredPosition = new Vector2(-2213, 1055);
    }

    public void open_ShopAlt()
    {
        shop.rectTransform.anchoredPosition = new Vector2(-230, -70);
    }

    public void close_ShopAlt()
    {
        shop.GetComponent<Image>().transform.position = new Vector2(-500, -500);
    }

    public void open_InventoryAlt()
    {
        inven.rectTransform.anchoredPosition = new Vector2(-230, -70);
    }

    public void close_InventoryAlt()
    {
        shop.GetComponent<Image>().transform.position = new Vector2(-500, -500);
    }

    public void cancel_PlantAlt()
    {
        Item_inventory.codePlant = "Not";
    }

    public void harvest()
    {
        switch (toggle_harvest)
        {
            case 1:
                harvest_status = true;
                alert_harvest.rectTransform.anchoredPosition = new Vector2(-206, -60);
                harvest_text.text = "Harvest Actived";
                Time.timeScale = 0;
                toggle_harvest = 2;
                break;
            case 2:
                toggle_harvest = 1;
                alert_harvest.rectTransform.anchoredPosition = new Vector2(-206, -60);
                harvest_text.text = "Harvest Deactived";
                Time.timeScale = 1;
                harvest_status = false;
                break;
        }
    }

    public void vitamin()
    {
        switch (toggle_vitamin)
        {
            case 1:
                vitamin_status = true;
                alert_harvest.rectTransform.anchoredPosition = new Vector2(-206, -60);
                harvest_text.text = "Vitamin Actived";
                Time.timeScale = 0;
                toggle_vitamin = 2;
                break;
            case 2:
                toggle_vitamin = 1;
                alert_harvest.rectTransform.anchoredPosition = new Vector2(-206, -60);
                harvest_text.text = "Vitamin Deactived";
                Time.timeScale = 1;
                vitamin_status = false;
                break;
        }
    }


    public void cutRockwool_alt()
    {
       
        if(Item_inventory.buy_rock_Status == true)
        {
            sliced_rockwool_alt.rectTransform.anchoredPosition = new Vector2(6.6603f, 19.826f);
            single_rockWool_alt.rectTransform.anchoredPosition = new Vector2(1106, -599);
        }
        
    }


    public void moveParalon()
    {
        paralon_alt.rectTransform.anchoredPosition = new Vector2(-207, -24);
        sliced_rockwool_alt.rectTransform.anchoredPosition = new Vector2(1000, 1000);
    }

    public void closeParalon()
    {
        paralon_alt.rectTransform.anchoredPosition = new Vector2(1000, 1000);
    }


    void Start()
    {
        harvest_status = false;
        toggle_harvest = 1;
        toggle_vitamin = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
