using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Navigation_H : MonoBehaviour
{

    [SerializeField] GameObject FAQ_Button, Contact_Button, FAQ_Text, Contact_Text,Help_Confirm, option_confirm;

    public void confirmHelp()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void select_FAQ()
    {
        FAQ_Button.SetActive(false);    
        Contact_Button.SetActive(false);
        Contact_Text.SetActive(false);
        FAQ_Text.SetActive(true);
        Help_Confirm.SetActive(false);
        option_confirm.SetActive(true);
    }

    public void select_Contact()
    {
        FAQ_Button.SetActive(false);
        Contact_Button.SetActive(false);
        Contact_Text.SetActive(true);
        FAQ_Text.SetActive(false);
        Help_Confirm.SetActive(false);
        option_confirm.SetActive(true);
    }

    public void confirm_option()
    {
        FAQ_Text.SetActive(false);
        Contact_Text.SetActive(false);
        Contact_Button.SetActive(true);
        FAQ_Button.SetActive(true);
        Help_Confirm.SetActive(true);
        option_confirm.SetActive(false);
    }

    
}
