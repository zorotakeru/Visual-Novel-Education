using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImenu : MonoBehaviour
{
    private bool btnEnabled = false;
    public GameObject btnMenu;
    public GameObject btnMainMenu;
    public GameObject btnExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowBtn()
    {
        if (btnEnabled)
        {
            btnMainMenu.SetActive(false);   
            btnExit.SetActive(false);
            btnEnabled = false;
        }
        else
        {
            btnMainMenu.SetActive(true);
            btnExit.SetActive(true);
            btnEnabled = true;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Keluar()
    {
        Application.Quit();
    }
}
