using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UnityEngine.UI;
using UnityEngine.Playables;

public class BackgroundView : MonoBehaviour
{
    private bool _isButtonEnabled = true;
    public bool IsButtonEnabled => _isButtonEnabled;

    [SerializeField] private Image[] _afternoonBackgroundImages;
    [SerializeField] private Image[] _nightBackgroundImages;

    [SerializeField] private PlayableDirector _afternoonPlayableDirector;
    [SerializeField] private PlayableDirector _nightPlayableDirector;

    [SerializeField] private GameObject StarPieces;

    [SerializeField] private GameObject _clickNightButton;
    [SerializeField] private GameObject _starParticles;

    private GameObject _currentBackground;
    
    // Start is called before the first frame update
    void Start()
    {
        _nightPlayableDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickChangeTimeButton(){
        if (!_isButtonEnabled) return;
        _isButtonEnabled = false;
    }

    // 昼に切り替える
    public void ChangeAfternoonBackground(){
        _nightPlayableDirector.Stop();
        var sequence = DOTween.Sequence(); 
        sequence.Append(_afternoonBackgroundImages[0].DOFade(1.0f, 1.0f))
                .Join(_nightBackgroundImages[0].DOFade(0.0f, 1.0f))
                .Join(_nightBackgroundImages[1].DOFade(0.0f, 1.0f))
                .OnComplete(() => {
                    _isButtonEnabled = true;
                    _afternoonPlayableDirector.Play();
                    SetActiveClickNightButton(false);
                    StarPieces.SetActive(true);
                    _starParticles.SetActive(false);
                    foreach (Transform child in _starParticles.transform)
                    {
                        child.gameObject.GetComponent<StarParticleView>().SetActiveFalse();
                    }
                    });
    }

    // 夜に切り換える
    public void ChangeNightBackground(){
        _afternoonPlayableDirector.Stop();
        var sequence = DOTween.Sequence(); 
        sequence.Append(_nightBackgroundImages[0].DOFade(1.0f, 1.0f))
                .Join(_afternoonBackgroundImages[0].DOFade(0.0f, 1.0f))
                .Join(_afternoonBackgroundImages[1].DOFade(0.0f, 1.0f))
                .OnComplete(() => {
                    _isButtonEnabled = true;
                    _nightPlayableDirector.Play();
                    SetActiveClickNightButton(true);
                    StarPieces.SetActive(false);
                    _starParticles.SetActive(true);
                    });
    }

    public void SetActiveClickNightButton(bool is_active){
        _clickNightButton.SetActive(is_active);
    }
}
