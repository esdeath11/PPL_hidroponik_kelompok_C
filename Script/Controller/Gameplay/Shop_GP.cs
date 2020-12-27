using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop_GP : MonoBehaviour
{
    [SerializeField] Text Money, username;
    public static int money_value;
    void Start()
    {
        username.text = Login_auth.username_lg;
        money_value = Login_auth.money;
    }

    public void buySelada()
    {
        if(money_value >= 3000 )
        {
            Item_inventory.selada += 3;
            money_value -= 3000;
        }
        
    }

    public void buyBayam()
    {
        if(money_value >= 3000)
        {
            Item_inventory.bayam += 3;
            money_value -= 3000;
        }
    }

    public void buyRockwool()
    {
        if(money_value >= 7500)
        {
            Item_inventory.rockwool += 1;
            money_value -= 7500;
        }
        
    }

    public void buyVitamin()
    {
        if(money_value >= 5000)
        {
            Item_inventory.vitamin += 100;
            money_value -= 5000;
        }
    }
    
    void Update()
    {
        Money.text = money_value.ToString();
    }
}
