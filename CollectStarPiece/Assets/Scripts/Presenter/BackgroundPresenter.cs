using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class BackgroundPresenter : MonoBehaviour
{
    [SerializeField] private BackgroundView _backgroundView;
    [SerializeField] private Background _background;
    //[SerializeField] private ;
    // Start is called before the first frame update
    void Start()
    {
        _backgroundView.ObserveEveryValueChanged(x => x.IsButtonEnabled).Where(x => !x)
        .Subscribe(_ => {
            _background.SetTime();
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
