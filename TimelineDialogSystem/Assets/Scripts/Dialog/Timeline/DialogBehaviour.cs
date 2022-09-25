using UnityEngine;
using UnityEngine.Playables;

public class DialogBehaviour : PlayableBehaviour
{
    public DialogSentence dialogSentence;
    public float charPerSecond;
    public bool isUseCustomCharDelay;

    private int maxVisibleCharacters = 0;
    private int previousVisibleCharacterValue = 0;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        DialogDisplayer dialogDisplayer = playerData as DialogDisplayer;

        float charPerSecond = dialogSentence.Description.Length / (float)playable.GetDuration();

        if (!isUseCustomCharDelay && IsAllCharactersWritten())
        {
            CalculateMaxVisibleCharacters(dialogDisplayer, playable, charPerSecond);
        }
        else if (isUseCustomCharDelay && IsAllCharactersWritten())
        {
            CalculateMaxVisibleCharacters(dialogDisplayer, playable, this.charPerSecond);
        }

        if (maxVisibleCharacters != previousVisibleCharacterValue && IsAllCharactersWritten())
        {
            dialogDisplayer.OnMaxVisibleCharactersSet?.Invoke(dialogSentence.dialogCharacter.DialogSound);
        }

        dialogDisplayer.SetUpDialog(dialogSentence.dialogCharacter, dialogSentence.Description);
        dialogDisplayer.SetDescriptionMaxVisibleCharacters(maxVisibleCharacters);

        bool IsAllCharactersWritten()
        {
            return maxVisibleCharacters != dialogSentence.Description.Length;
        }
    }

    private void CalculateMaxVisibleCharacters(DialogDisplayer dialogDisplayer, Playable playable, float charSpeed)
    {
        previousVisibleCharacterValue = dialogDisplayer.GetDescriptionMaxVisibleCharacters();
        maxVisibleCharacters = (int)Mathf.Round((float)playable.GetTime() * charSpeed);
    }
}