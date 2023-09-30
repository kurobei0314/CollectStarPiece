using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SwitchTimePresenter : MonoBehaviour
{
    [SerializeField] private BackgroundView _backgroundView;
    [SerializeField] private Background _background;
    //[SerializeField] private ;
    // Start is called before the first frame update
    void Start()
    {
        // 昼夜切り替えボタンを押した時
        _backgroundView.ObserveEveryValueChanged(x => x.IsButtonEnabled).Where(x => !x)
        .Subscribe(_ => {
            _background.SetTime();
        }).AddTo(this);

        // 昼夜切り替えボタンを押した結果、夜のボタンを作るかどうか
        _background.ObserveEveryValueChanged(x => x.CurrentTime)
        .Subscribe(time => {
            if(!_background.isInitialized) return;
            if (time == Background.Time.NIGHT)
            {
                _backgroundView.ChangeNightBackground();
            }
            else
            {
                _backgroundView.ChangeAfternoonBackground();
            }
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
