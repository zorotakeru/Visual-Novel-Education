using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    DialogueSystem dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }
    public static string[] LoadWords()
    {
        string text = Resources.Load<TextAsset>("words").text;
        return text.Split(new char[] { ' ' });
    }

    public string[] s = new string[]
    {
        "Em...:Bento",
        "Namaku bento ",
        "rumah real estate ",
        "mobilku banyak ",
        "harta berlimpah",
        "orang memanggilku ",
        "bos eksekutif ",
        "tokoh papan atas ",
        "atas segalanya "
    };
    // Update is called once per frame

    int index = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!dialogue.isSpeaking)
            {
                if (index >= s.Length)
                {
                    return;
                }
                Say(s[index]);
                index++;
            }
        }
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech,speaker);
    }
}
