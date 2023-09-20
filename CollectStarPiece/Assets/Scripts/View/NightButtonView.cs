using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NightButtonView : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ParticleSystem particle;
    
    public void OnPointerDown(PointerEventData data)
    {
        
    }
}
