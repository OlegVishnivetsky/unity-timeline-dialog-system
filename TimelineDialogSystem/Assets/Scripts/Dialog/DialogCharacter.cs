using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "ScriptableObject/New Character")]
public class DialogCharacter : ScriptableObject
{
    public string Name;
    public AudioClip DialogSound;
}