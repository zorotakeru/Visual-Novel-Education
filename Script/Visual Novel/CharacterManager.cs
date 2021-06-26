using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public RectTransform characterPanel;

    public List<Character> characters = new List<Character>();

    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    private void Awake()
    {
        instance = this;
    }

    public Character GetCharacter(string characterName)
    {
        int index = -1;
        if(characterDictionary.TryGetValue (characterName, out index))
        {
            return characters[index];
        }
        else
        {
            return CreateCharacter(characterName);
        }

        
    }

    public Character CreateCharacter(string characterName)
    {
        Character newCharacter = new Character(characterName);
        characterDictionary.Add(characterName, characters.Count);
        characters.Add(newCharacter);

        return newCharacter;
    }
}

