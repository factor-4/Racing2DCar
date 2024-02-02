using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {


    public Button[] buttons;
    public Text scoreText;
    bool gameOver;
    int score;

	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        NewMethod1();
    }

    private void NewMethod1()
    {
        NewMethod2();
    }

    private void NewMethod2()
    {
        NewMethod3();
    }

    private void NewMethod3()
    {
        scoreText.text = "Score: " + score;
    }

    void scoreUpdate ()
    {
        if(gameOver==false)
        {
            score += 1;
        }
        
    }
    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
  
    public void Play ()
    {
        SceneManager.LoadScene("level1");
    }
    public void Play2()
    {
        SceneManager.LoadScene("level2");
    }
    public void Play3()
    {
        SceneManager.LoadScene("new level");
    }
    public void countryRoad()
    {
        SceneManager.LoadScene("level3");
    }
    public void Play4()
    {
        SceneManager.LoadScene("info");
    }
    public void Pause ()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }

    public void Replay()
    {
       SceneManager.LoadScene(sceneBuildIndex:Application.loadedLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("newMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
