using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameController : MonoBehaviour
{
    private bool _isStartAnimationEnd = false;
    private float _gameTimer = 30.0f;
    [SerializeField] private GameTimerView _gameTimeView;
    [SerializeField] private StarParticleView[] _starParticleView;

    // Start is called before the first frame update
    void Start()
    {
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime).FirstOrDefault(x => x <= 0.0f)
        .Subscribe(_ => {
            PlayEnding();
        }).AddTo(this);

        // 15秒経ったらActiveをtrueにする
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime)
                    .FirstOrDefault(x => x <= 15.0f)
                    .Subscribe(_ => _starParticleView[0].gameObject.SetActive(true));

        // 5秒経ったらActiveをtrueにする
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime)
                    .FirstOrDefault(x => x <= 5.0f)
                    .Subscribe(_ => _starParticleView[1].gameObject.SetActive(true));

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
