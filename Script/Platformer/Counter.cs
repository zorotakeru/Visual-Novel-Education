using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private float timeRemaining ;
    private float time;
    public GameObject btnEasy;
    public GameObject btnMedium;
    public GameObject btnHard;
    public GameObject player;
    public Text counter;
    public GameObject choice;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        NotPressed();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }
    
    private void TimeCount()
    {
        if (timeRemaining > 0)
        {
            counter.text = ((int)timeRemaining).ToString();
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Restart();
        }
    }

    private void Pressed()
    {
        btnEasy.SetActive(false);
        btnMedium.SetActive(false);
        btnHard.SetActive(false);
        choice.SetActive(false);
        background.SetActive(false);
        ResumeGame();
    }
    private void NotPressed()
    {
        btnEasy.SetActive(true);
        btnMedium.SetActive(true);
        btnHard.SetActive(true);
        choice.SetActive(true);
        background.SetActive(true);
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Easy()
    {
        timeRemaining = 180;
        time = 180;
        Pressed();
    }
    public void Medium()
    {
        timeRemaining = 90;
        time = 90;
        Pressed();
    }
    public void Hard()
    {
        timeRemaining =30;
        time = 30;
        Pressed();
    }
    public void Restart()
    {
        player.transform.position = new Vector2(-7.401f, -1.29f);
        timeRemaining = time;
    }

}
