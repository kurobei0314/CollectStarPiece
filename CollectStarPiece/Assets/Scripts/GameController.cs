using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameController : MonoBehaviour
{
    private bool _isStartAnimationEnd = false;
    private float _gameTimer = 30.0f;
    [SerializeField] private GameTimerView _gameTimeView;

    // Start is called before the first frame update
    void Start()
    {
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime).Where(x => x <= 0.0f)
        .Subscribe(_ => {
            PlayEnding();
        }).AddTo(this);
        // ここでアニメーション流す

        _gameTimeView.StartTimer(_gameTimer);

    }

    // Update is called once per frame
    void Update()
    {
        // 最初のアニメーションが終わったら
        // if (!isStartAnimationEnd && playableDirector.state != PlayState.Playing)
        // {
            // isStartAnimationEnd = true;
            // _gameTimeView.StartTimer(_gameTimer);
        // }
    }

    // エンディングを流す
    void PlayEnding()
    {
        Debug.Log("ゲーム終わったー");
    }
}
