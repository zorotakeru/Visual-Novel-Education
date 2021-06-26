using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovelController : MonoBehaviour
{

    List<string> data = new List<string>();
    private int progress;
    public string story;
    // Start is called before the first frame update
    void Start()
    {   
        LoadChapterFile(story);
        HandleLine(data[0]);
        progress = 1;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Next();
        }
    }

    public void Next()
    {
        if (progress < data.Count)
        {
            HandleLine(data[progress]);
            progress++;
        }
    }

    void LoadChapterFile(string fileName)
    {
        data = FileManager.ReadTextAsset(Resources.Load<TextAsset>($"Story/{fileName}"));
    }


    //3 isi
    //dialog detail(nama dan additive), dialog, action
    void HandleLine(string line)
    {
        Debug.Log(line);
        string[] dialogueAndActions = line.Split('"'); // karna dipisahkan oleh (") maka akhir dari (") akan dimasukan index ke 2
        Debug.Log(dialogueAndActions.Length);

        if (dialogueAndActions.Length == 3)
        {
            HandleDialogue(dialogueAndActions[0], dialogueAndActions[1]);
            HandleEventsFromLine(dialogueAndActions[2]);
        }
        else
        {
            HandleEventsFromLine(dialogueAndActions[0]);
        }

    }

    string cachedLastSpeaker = "";
    void HandleDialogue(string dialogueDetails, string dialogue)
    {
        
        string speaker = cachedLastSpeaker;
        bool additive = dialogueDetails.Contains("+");
        if (additive)
            dialogueDetails = dialogueDetails.Remove(dialogueDetails.Length - 1);

        if(dialogueDetails.Length > 0)
        {
            if (dialogueDetails[dialogueDetails.Length - 1] == ' ')
                //hapus spasi antara nama dan tulisan
                dialogueDetails = dialogueDetails.Remove(dialogueDetails.Length - 1);

            speaker = dialogueDetails;
            cachedLastSpeaker = speaker;
        }

        if(speaker != "narrator")
        {
            Character character = CharacterManager.instance.GetCharacter(speaker);
            character.CharacterSay(dialogue, additive);
        }
        else
        {
            DialogueSystem.instance.Say(dialogue, speaker, additive);
        }   

    }

    void HandleEventsFromLine(string events)
    {
        
        string[] actions = events.Split(' ');

        foreach(string action in actions)
        {
            HandleAction(action);
        }
    }

    void HandleAction(string action)
    {
        Debug.Log("Handle Action [" + action + "]");
        string[] data = action.Split('(', ')');
        

        switch (data[0])
        {   
            case ("setPosition"):
                Command_SetPositions(data[1]);
                break;
            //case ("movePosition"):
            //    Command_MoveCharacter(data[1]);
            //    break;
            case ("setExpression"):
                Command_ChangeBodyExpression(data[1]);
                break;
            case ("setBackground"):
                Command_SetLayerImage(data[1], BackgroundController.instance.background);
                break;
            case ("hideCharacter"):
                Command_HideCharacter(data[1]);
                break;
            case ("choice"):
                Command_Choice(data[1]);
                break;
            case ("flip"):
                Command_Flip(data[1]);
                break;
            case ("menu"):
                Command_Menu();
                break;
            case ("close"):
                Command_Close();
                break;
        }
    }

    //void Command_MoveCharacter(string data)
    //{
    //    string[] parameters = data.Split(',');
    //    string character = parameters[0];
    //    float locationX = float.Parse(parameters[1]);
    //    float locationY = float.Parse(parameters[2]);
    //    float speed = parameters.Length >= 4 ? float.Parse(parameters[3]) : 1f;
    //    bool smooth = parameters.Length == 5 ? bool.Parse(parameters[4]) : false;

    //    Character character1 = CharacterManager.instance.GetCharacter(character);
    //    character1.MoveTo(new Vector2(locationX, locationY), speed, smooth);

    //}
    void Command_SetPositions(string data) //Boy,0.2,0
    {
        string[] parameters = data.Split(','); //parameter[0] Boy
        string character = parameters[0];
        float locationX = float.Parse(parameters[1]);
        float locationY = float.Parse(parameters[2]);

        Character character1 = CharacterManager.instance.GetCharacter(character);
        character1.SetPosition(new Vector2(locationX, locationY));
    }
    void Command_ChangeBodyExpression(string data) //Boy,face,open
    {
        string[] parameters = data.Split(',');
        string character = parameters[0]; //Boy
        string region = parameters[1]; //face
        string spriteName = parameters[2]; //open

        Character character1 = CharacterManager.instance.GetCharacter(character);
        Sprite sprite = character1.GetSprite(spriteName);

        if(region.ToLower() == "body")
        {
            character1.SetBody(sprite);
        }
        if (region.ToLower() == "face")
        {
            character1.SetExpression(sprite);
        }
    }
    void Command_SetLayerImage(string data, BackgroundController.LAYER layer)
    {
        Debug.Log(data);
        Texture2D tex = Resources.Load("Images/Background/" + data) as Texture2D;
        layer.SetTexture(tex);
    }
    void Command_HideCharacter(string data)
    {
        Character character1 = CharacterManager.instance.GetCharacter(data);
        character1.HideCharacter();
    }
    void Command_Choice(string data)
    {
        ChoiceScreen screen = ChoiceScreen.instance;
        if (data == "show")
        {
            screen.Show();
        }
        else if(data == "hide")
        {
            screen.Hide();
        }
    }
    void Command_Flip(string data)
    {
        Character character1 = CharacterManager.instance.GetCharacter(data);
        character1.Flip();
    }
    void Command_Menu()
    {
        SceneManager.LoadScene(0);
    }
    void Command_Close()
    {
        DialogueSystem.instance.Close();
    }
}
