using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConditionGame_Alt : MonoBehaviour
{
    [SerializeField] Image GameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        conditionFromBarUI();
    }

    void conditionFromBarUI()
    {
        if(BarUI_Alt.BarUI_GameOver_status == true)
        {
            Time.timeScale = 0;
            GameOverMove();
        }
    }

    void GameOverMove()
    {
        GameOver.rectTransform.anchoredPosition = new Vector2(-211, -60);
    }

    public void confirmGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
