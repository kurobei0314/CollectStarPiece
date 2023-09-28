using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

namespace Timeline
{
    [System.Serializable]
    public class TextDisplayClip : PlayableAsset, ITimelineClipAsset
    {
        public ClipCaps clipCaps
        {
            get => ClipCaps.None;
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var playable = ScriptPlayable<TextDisplayBehaviour>.Create(graph);
            playable.GetBehaviour().Clip = this;
            return playable;
        }
    }
}
