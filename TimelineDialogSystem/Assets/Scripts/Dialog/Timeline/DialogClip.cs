using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] private DialogSentence dialogSentence;

    [Space(5)]
    [SerializeField] private float charPerSecond;

    [Tooltip("If it false, char delay will be depend on your clip length")]
    [SerializeField] private bool isUseCustomCharDelay;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogBehaviour>.Create(graph);

        DialogBehaviour dialogBehaviour = playable.GetBehaviour();
        dialogBehaviour.dialogSentence = dialogSentence;
        dialogBehaviour.charPerSecond = charPerSecond;
        dialogBehaviour.isUseCustomCharDelay = isUseCustomCharDelay;

        return playable;
    }
}