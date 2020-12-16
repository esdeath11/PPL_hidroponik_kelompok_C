using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_nav_GB : MonoBehaviour
{
    [SerializeField] Image alert;
    [SerializeField] Text alert_harverst;
    public static bool harvest;
    int toggle_harvest;
    // Start is called before the first frame update
    void Start()
    {
        toggle_harvest = 1;
        harvest = false;
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
