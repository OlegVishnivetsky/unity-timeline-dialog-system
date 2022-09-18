using UnityEngine;
using UnityEngine.Playables;

public class DialogBehaviour : PlayableBehaviour
{
    public DialogSentence dialogSentence;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        DialogDisplayer dialogDisplayer = playerData as DialogDisplayer;

        float charPerSecond = dialogSentence.Description.Length / (float)playable.GetDuration();
        int maxVisibleCharacter = (int)Mathf.Round((float)playable.GetTime() * charPerSecond);

        dialogDisplayer.SetUpDialog(dialogSentence.Name, dialogSentence.Description);
        dialogDisplayer.SetDescriptionMaxVisibleCharacters(maxVisibleCharacter);
    }
}