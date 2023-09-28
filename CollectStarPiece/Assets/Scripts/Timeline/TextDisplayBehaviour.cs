using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

namespace Timeline
{
    public class TextDisplayBehaviour : PlayableBehaviour, ITimelineClipAsset 
    {
        public TextDisplayClip Clip { get; set; }
        public ClipCaps clipCaps
        {
            get => ClipCaps.None;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            var text = playerData as TextMeshProUGUI;
            if (text != null)
            {
                var progress = (float)(playable.GetTime() / playable.GetDuration());
                var current = Mathf.Lerp(0, text.text.Length, progress);
                var count = Mathf.CeilToInt(current);

                text.maxVisibleCharacters = count;
            }
        }
    }
}
