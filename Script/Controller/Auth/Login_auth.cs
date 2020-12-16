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
    public static int selada, rockwool, money, bibit_selada;
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
        selada = int.Parse(e.Snapshot.Child("Inventory").Child("Biji").Child("selada").GetValue(true).ToString());
        rockwool = int.Parse(e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").GetValue(true).ToString());
        money = int.Parse(e.Snapshot.Child("Shop").Child("Economy").Child("Money").GetValue(true).ToString());
        bibit_selada = int.Parse(e.Snapshot.Child("Inventory").Child("Bibit").Child("Bibit Selada").GetValue(true).ToString());
        login_status = true;
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
        login_status = true;
        SceneManager.LoadScene("Loading");
    }
}
