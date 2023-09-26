using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NightButtonView : MonoBehaviour, IPointerDownHandler
{
    // [SerializeField] private ParticleSystem _particle;

    public void OnPointerDown(PointerEventData data)
    {
        
    }

    public bool IsPlayingStarParticle ()
    {
        // TODO: パーティクルが再生されてるかをみる
        // return _particle.gameObject.activeSelf;
        return true;
    }
}
