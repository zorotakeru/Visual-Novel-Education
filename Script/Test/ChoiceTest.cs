using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTest : MonoBehaviour
{

    ChoiceScreen screen;


    // Start is called before the first frame update
    void Start()
    {
        screen = ChoiceScreen.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            screen.Show();
        }
    }
}
