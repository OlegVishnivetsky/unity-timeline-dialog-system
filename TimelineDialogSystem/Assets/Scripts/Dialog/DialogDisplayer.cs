using TMPro;
using UnityEngine;

public class DialogDisplayer : MonoBehaviour
{
    [Header("Dialog UI Components")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogName;
    [SerializeField] private TMP_Text dialogDescription;

    public void SetUpDialog(string name, string description)
    {
        dialogName.text = name;
        dialogDescription.text = description;
    }

    public void SetDescriptionMaxVisibleCharacters(int value)
    {
        dialogDescription.maxVisibleCharacters = value;
    }
}

[System.Serializable]
public struct DialogSentence
{
    public string Name;
    public string Description;
}
