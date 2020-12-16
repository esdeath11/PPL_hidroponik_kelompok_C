using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
public class Loading_auth : MonoBehaviour
{
    Loading loading;
    static string saveUsername;
    static DatabaseReference reference;
    [SerializeField] Image LoadingImage;
    // Start is called before the first frame update
    void Start()
    {
        loading = new Loading();
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        this.loading.Update();
        LoadingImage.fillAmount = loading.GetWaterNormalized();
        if(loading.waterAmount > 99 && Register_auth.register_status == true)
        {
            Login_auth.username_lg = Register_auth.username_rg;
            Login_auth.loading();
        }

        else if(loading.waterAmount > 99 && Login_auth.login_status == true)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public static void saveGame()
    {
        saveUsername = Login_auth.username_lg;
        Debug.Log(saveUsername);
        reference.Child(saveUsername).Child("Name").SetValueAsync(saveUsername).ToString();
        reference.Child(saveUsername).Child("Inventory").Child("Biji").Child("selada").SetValueAsync(Item_inventory.selada).ToString();
        reference.Child(saveUsername).Child("Inventory").Child("Tools").Child("Rockwool").SetValueAsync(Item_inventory.rockwool).ToString();
        reference.Child(saveUsername).Child("Shop").Child("Economy").Child("Money").SetValueAsync(Shop_GP.money_value).ToString();
        reference.Child(saveUsername).Child("Inventory").Child("Bibit").Child("Bibit Selada").SetValueAsync(Item_inventory.bibit_Selada).ToString();
    }

    public static void DestroyGameID()
    {
      //  saveUsername = Login_auth.username_lg;
      //  reference.Child(saveUsername).Child("Game Status").SetValueAsync(Navigation_GP.gameover_status);
    }
}

public class Loading
{

    public const int MAX_WATER = 100;
    public float waterAmount;
    private float waterDecoy;
    private float waterDecoyNight;

    public Loading()
    {
        waterAmount = 0f;
        waterDecoy = 16.4f;
        waterDecoyNight = 1.2f;
    }

    public void Update()
    {
        waterAmount += waterDecoy * Time.deltaTime;
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
