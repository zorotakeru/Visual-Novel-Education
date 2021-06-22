using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    public ELEMENTS elements;
    public GameObject speechPanel { get { return elements.speechPanel; } }
    public Text speakerNameText { get { return elements.speakerNameText; } }
    public Text speechText { get { return elements.speechText; } }
    void Awake()
    {
        instance = this;
    }
    public void Say(string speech, string speaker = "", bool additive = false)
    {
        StopSpeaking();

        if (additive)
            speechText.text = targetSpeech;


        speaking = StartCoroutine(Speaking(speech, additive , speaker));
    }

    //public void SayAdd(string speech, string speaker = "")
    //{
    //    StopSpeaking();
    //    speechText.text = targetSpeech;
    //    speaking = StartCoroutine(Speaking(speech, true, speaker));
    //}

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }


    string targetSpeech = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string speech,bool additive, string speaker = "")
    {
        speechPanel.SetActive(true);
        targetSpeech = speech; 

        if (!additive)
            speechText.text = "";
        else
            targetSpeech = speechText.text + targetSpeech;

        speakerNameText.text = DetermineSpeaker(speaker);


        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForSeconds(0.05f);
        }

        StopSpeaking();
    }

    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text;
        if(s != speakerNameText.text && s != "")
            retVal = (s.ToLower().Contains("narrator")) ? "" : s;

        return retVal;
    }

    public void Close()
    {
        StopSpeaking();
        speechPanel.SetActive(false);
    }

    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public Text speakerNameText;
        public Text speechText;
    }

    
}
