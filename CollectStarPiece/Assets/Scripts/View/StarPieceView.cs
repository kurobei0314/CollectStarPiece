using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarPieceView : MonoBehaviour, IPointerDownHandler
{
    public void SetStarPiece()
    {
        this.gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData data)
    {
        this.gameObject.SetActive(false);
    }
}
