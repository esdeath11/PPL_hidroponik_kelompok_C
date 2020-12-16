using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEditor;
using System;

public class Database_fb : MonoBehaviour
{
    // Start is called before the first frame update

    DatabaseReference reference;
    string data;
    void Start()
    {
       // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://simulasihidro-default-rtdb.firebaseio.com/");
        
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        loadData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("data")
        .ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        data = e.Snapshot.Child("test").GetValue(true).ToString();
        Debug.Log(data);
    }
}
