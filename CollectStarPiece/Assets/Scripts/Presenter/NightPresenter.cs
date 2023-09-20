using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class NightPresenter : MonoBehaviour
{
    [SerializeField] private ObservableEventTrigger _nightButtonTrigger;
    [SerializeField] private NightButtonView _nightButtonView;
    [SerializeField] private StarPiece _starPiece;

    // Start is called before the first frame update
    void Start()
    {
        // 画面が押されたかつパーティクルが再生されている時に押す
        _nightButtonTrigger.OnPointerDownAsObservable()
            .Where(_ =>_nightButtonView.IsPlayingStarParticle())
            .Subscribe(_ => {
                _starPiece.AddCurrentPiece(1);
            }).AddTo(this);
    }

}
