using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

    // Use this for initialization
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
	void Start () {
        Time.timeScale = 0;
        isEndGame = false;
        pnlEndGame.SetActive(false);
        isStartFirstTime = true;
    }

    // Update is called once per frame
    void Update() {
        if (isEndGame)
        {
            if (Input.GetKey(KeyCode.Space) && isStartFirstTime)
            {
                //load man choi
                StartGame();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1;
            }
        }
	}
    public void ReStartButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }
    public void ReStartButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void ReStartButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ReStart()
    {
        StartGame();
    }
    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your Point\n" + gamePoint.ToString();
    }
}
