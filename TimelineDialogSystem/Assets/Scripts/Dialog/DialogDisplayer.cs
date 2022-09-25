using System;
using TMPro;
using UnityEngine;

public class DialogDisplayer : MonoBehaviour
{
    [Header("Dialog UI Components")]
    [SerializeField] private GameObject dialogPanel;

    [SerializeField] private TMP_Text dialogName;
    [SerializeField] private TMP_Text dialogDescription;

    public Action<AudioClip> OnMaxVisibleCharactersSet;

    public int GetDescriptionMaxVisibleCharacters()
    {
        return dialogDescription.maxVisibleCharacters;
    }

    public void SetDescriptionMaxVisibleCharacters(int value)
    {
        dialogDescription.maxVisibleCharacters = value;
    }

    public void SetUpDialog(DialogCharacter dialogCharacter, string description)
    {
        dialogName.text = dialogCharacter.Name;
        dialogDescription.text = description;
    }
}

[System.Serializable]
public struct DialogSentence
{
    public DialogCharacter dialogCharacter;
    public string Description;
}