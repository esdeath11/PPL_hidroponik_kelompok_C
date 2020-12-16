using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation_auth : MonoBehaviour
{
    [SerializeField] GameObject mainmenu, newgame, loadgame, choosemenu;


    public void OpenMenu()
    {
        mainmenu.SetActive(true);
        newgame.SetActive(false);
        loadgame.SetActive(false);
        choosemenu.SetActive(false);
    }

    public void chooseMenu()
    {
        mainmenu.SetActive(false);
        newgame.SetActive(false);
        loadgame.SetActive(false);
        choosemenu.SetActive(true);
    }

    public void NewGame()
    {
        mainmenu.SetActive(false);
        newgame.SetActive(true);
        loadgame.SetActive(false);
        choosemenu.SetActive(false);
    }

    public void loadGame()
    {
        mainmenu.SetActive(false);
        newgame.SetActive(false);
        loadgame.SetActive(true);
        choosemenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void About_game()
    {
        SceneManager.LoadScene("About");
    }

    public void Help_Game()
    {
        SceneManager.LoadScene("Help");
    }

}
