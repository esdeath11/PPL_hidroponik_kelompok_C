using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_inventory : MonoBehaviour
{
    [SerializeField] Text text_Selada, text_Rockwool, text_bibit_Selada, text_jenisbibit, text_valueBibit, text_vitamin, text_bibit_bayam, text_bayam;
    [SerializeField] Image Big_rockwool, cut_rockwool, Invetory;
    public static int selada, bayam, bawang, vitamin, rockwool, seledri, bibit_Selada, bibit_bayam;
    public static bool status_tanam, status_Rock, buy_rock_Status;
    public static string codePlant, codePlant_bibit;
    string jenis_bibit;

    // Start is called before the first frame update
    void Start()
    {
        selada = Login_auth.selada;
        bayam = Login_auth.bayam;
        vitamin = Login_auth.vitamin;
        rockwool = Login_auth.rockwool;
        bibit_Selada = Login_auth.bibit_selada;
        bibit_bayam = Login_auth.bibit_bayam;
        text_Selada.text = selada.ToString();
        status_tanam = false;
        status_Rock = false;
        codePlant = "Not Planting";
    }

    // Update is called once per frame
    void Update()
    {
        text_Selada.text = selada.ToString();
        text_Rockwool.text = rockwool.ToString();
        text_bibit_Selada.text = bibit_Selada.ToString();
        text_jenisbibit.text = jenis_bibit;
        text_valueBibit.text = bibit_Selada.ToString();
        text_vitamin.text = vitamin.ToString();
        text_bibit_bayam.text = bibit_bayam.ToString();
        text_bayam.text = bayam.ToString();
    }

    public void useSelada()
    {
        status_tanam = true;
        codePlant = "selada";
        
        Plating_GP.rockwool_status = true;
    }

    public void useBayam()
    {
        status_tanam = true;
        codePlant = "bayam";

        Plating_GP.rockwool_status = true;
    }

    public void useRockwool()
    {
        rockwool -= 1;
        Big_rockwool.rectTransform.anchoredPosition = new Vector2(3, 53.899f);
        Invetory.GetComponent<Image>().transform.position = new Vector2(-300, -300);
        
        buy_rock_Status = true;
    }

    public void useBibitSelada()
    {
        codePlant_bibit = "bibit_selada";
        jenis_bibit = "bibit selada";
    }

    public void useBibitBayam()
    {
        codePlant_bibit = "bibit_bayam";
    }
    
}
