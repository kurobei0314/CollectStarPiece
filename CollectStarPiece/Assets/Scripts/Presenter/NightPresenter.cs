using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class NightPresenter : MonoBehaviour
{
    [SerializeField] private ObservableEventTrigger _nightButtonViewGO;

    // Start is called before the first frame update
    void Start()
    {
        _nightButtonViewGO.OnPointerDownAsObservable()
        .Subscribe(_ => {
            
        }).AddTo(this);
    }

}
