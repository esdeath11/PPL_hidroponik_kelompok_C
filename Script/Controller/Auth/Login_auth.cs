using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;
public class Login_auth : MonoBehaviour
{
    DatabaseReference reference;
    public static string username_lg, usernameloading;
    public static int selada, rockwool, money, bibit_selada, vitamin, bayam, bibit_bayam;
    [SerializeField] InputField usernamefield;
    public static bool login_status;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void getUsername()
    {
        username_lg = usernamefield.text;
        Item_inventory.buy_rock_Status = false;
        Growth_GP.status_gameOver = false;
        loadGame();
    }

    public static void loading()
    {
        usernameloading = username_lg;
        loadData();
    }

    public static void loadData()
    {
        
        FirebaseDatabase.DefaultInstance
        .GetReference(username_lg)
        .ValueChanged += HandleValueChanged;
    }

    public static void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        Debug.Log("done");
        vitamin = int.Parse(e.Snapshot.Child("Inventory").Child("Tools").Child("Vitamin").GetValue(true).ToString());
        selada = int.Parse(e.Snapshot.Child("Inventory").Child("Biji").Child("selada").GetValue(true).ToString());
        rockwool = int.Parse(e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").GetValue(true).ToString());
        money = int.Parse(e.Snapshot.Child("Shop").Child("Economy").Child("Money").GetValue(true).ToString());
        bayam = int.Parse(e.Snapshot.Child("Inventory").Child("Biji").Child("bayam").GetValue(true).ToString());
        bibit_selada = int.Parse(e.Snapshot.Child("Inventory").Child("Bibit").Child("Bibit Selada").GetValue(true).ToString());
        bibit_bayam = int.Parse(e.Snapshot.Child("Inventory").Child("Bibit").Child("Bibit Bayam").GetValue(true).ToString());
        login_status = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
        
    }

    void loadGame()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference(username_lg)
        .ValueChanged += HandleValue;
    }

    private void HandleValue(object sender, ValueChangedEventArgs e)
    {
        selada = int.Parse(e.Snapshot.Child("Inventory").Child("Biji").Child("selada").GetValue(true).ToString());
        rockwool = int.Parse(e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").GetValue(true).ToString());
        money = int.Parse(e.Snapshot.Child("Shop").Child("Economy").Child("Money").GetValue(true).ToString());
        bibit_selada = int.Parse(e.Snapshot.Child("Inventory").Child("Bibit").Child("Bibit Selada").GetValue(true).ToString());
        bayam = int.Parse(e.Snapshot.Child("Inventory").Child("Biji").Child("bayam").GetValue(true).ToString());
        bibit_bayam = int.Parse(e.Snapshot.Child("Inventory").Child("Bibit").Child("Bibit Bayam").GetValue(true).ToString());
        login_status = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading");
    }
}
