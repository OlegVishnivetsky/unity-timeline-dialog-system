using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] private DialogSentence dialogSentence;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogBehaviour>.Create(graph);

        DialogBehaviour dialogBehaviour = playable.GetBehaviour();
        dialogBehaviour.dialogSentence = dialogSentence;

        return playable;
    }
}