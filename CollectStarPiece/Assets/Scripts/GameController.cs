using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UniRx.Triggers;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool _isStartAnimationEnd = false;
    private float _gameTimer = 30.0f;
    [SerializeField] private PlayableDirector _opDirector;
    [SerializeField] private PlayableDirector _edDirector;
    [SerializeField] private GameTimerView _gameTimeView;
    [SerializeField] private StarParticleView[] _starParticleView;
    [SerializeField] private GameObject _starParticles;
    [SerializeField] private Background _background;

    [SerializeField] private GameObject _gameResultUI;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Score _scoreNum;

    [SerializeField] private GameObject _starParticleResultView;

    // Start is called before the first frame update
    void Start()
    {
        _opDirector.stopped += OnPlayableDirectorStopped;
        _starParticles.SetActive(false);
        _gameResultUI.SetActive(false);
        AudioManager.Instance.PlayBGM("Main");
        _starParticleResultView.SetActive(false);
        for (int i = 0 ; i< _starParticleView.Length; i++){
            _starParticleView[i].gameObject.SetActive(false);
        }

        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime).FirstOrDefault(x => x <= 0.0f)
        .Subscribe(_ => {
            PlayEnding();
        }).AddTo(this);

        // 15秒経ったらActiveをtrueにする
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime)
                    .FirstOrDefault(x => x <= 20.0f)
                    .Subscribe(_ => _starParticleView[1].gameObject.SetActive(true)).AddTo(this);

        // 5秒経ったらActiveをtrueにする
        _gameTimeView.ObserveEveryValueChanged(x => x.NowTime)
                    .FirstOrDefault(x => x <= 10.0f)
                    .Subscribe(_ => _starParticleView[2].gameObject.SetActive(true)).AddTo(this);
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (_opDirector == aDirector){
            _gameTimeView.StartTimer(_gameTimer);
            _background.InitializeTime();
            _starParticles.SetActive(true);
            _starParticleView[0].gameObject.SetActive(true);
        } 
        else if (_edDirector == aDirector) {
            _scoreText.text = "願いのかけらを" + _scoreNum.ScoreNum + "個集めました";
            _gameResultUI.SetActive(true);
            _starParticleResultView.SetActive(true);
        }
    }

    // エンディングを流す
    void PlayEnding()
    {
        for (int i = 0 ; i< _starParticleView.Length; i++){
            _starParticleView[i].gameObject.SetActive(false);
        }
        _edDirector.Play();
        _edDirector.stopped += OnPlayableDirectorStopped;
        AudioManager.Instance.PlayBGM("Ed");
    }

    public void OnClickRestartButton(){
        AudioManager.Instance.PlaySE("Button");
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    public void OnClickTweetButton(){
        AudioManager.Instance.PlaySE("Button");
        naichilab.UnityRoomTweet.Tweet ("Ycollectstarpiece", "願いのかけらを" + _scoreNum.ScoreNum + "個集めました", "願いのかけら", "unity1week");
    }
}
