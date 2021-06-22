using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceScreen : MonoBehaviour
{

    public static ChoiceScreen instance;

    public GameObject root;

    void Awake()
    {
        instance = this;
        Hide();
    }
    // Start is called before the first frame update
    public void Show()
    {
        instance.root.SetActive(true);
    }

    public void Hide()
    {
        instance.root.SetActive(false);
    }

    public void Sepeda()
    {
        SceneManager.LoadScene(3);
    }

    public void Jalan()
    {
        SceneManager.LoadScene(2);
    }

}
