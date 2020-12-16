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
public class Register_auth : MonoBehaviour
{
    public static string username_rg;
    [SerializeField] InputField usernamefield;
    DatabaseReference reference;
    int selada, rockwool, money, bibit_selada;
    public static bool register_status;
    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        selada = 0;
        rockwool = 0;
        money = 30000;
        bibit_selada = 0;
    }


    public void submitRegister()
    {
        username_rg = usernamefield.text;
        reference.Child(username_rg).Child("Name").SetValueAsync(username_rg).ToString();
        reference.Child(username_rg).Child("Inventory").Child("Biji").Child("selada").SetValueAsync(selada).ToString();
        reference.Child(username_rg).Child("Inventory").Child("Tools").Child("Rockwool").SetValueAsync(rockwool).ToString();
        reference.Child(username_rg).Child("Shop").Child("Economy").Child("Money").SetValueAsync(money).ToString();
        reference.Child(username_rg).Child("Inventory").Child("Bibit").Child("Bibit Selada").SetValueAsync(bibit_selada).ToString();
        register_status = true;
        SceneManager.LoadScene("Loading");


    }




}
