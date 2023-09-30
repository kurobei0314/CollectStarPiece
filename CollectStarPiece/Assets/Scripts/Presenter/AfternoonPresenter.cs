using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class AfternoonPresenter : MonoBehaviour
{
    [SerializeField] private ObservableEventTrigger[] _starPieceViewTriggers;
    [SerializeField] private StarPiece _starPiece;
    //[SerializeField] private StarPiece _starPiece;
    [SerializeField] private Score _score;
    [SerializeField] private PlayerView _playerView;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _starPieceViewTriggers.Length; i++) {
            _starPieceViewTriggers[i].OnPointerDownAsObservable()
                .Subscribe(_ => {
                    _starPiece.SubCurrentPiece(1);
                    _score.AddScorePoint(1);
                    _playerView.ChangeGetImage();
                    AudioManager.Instance.PlaySE("GetItem");
                }).AddTo(this);
        }
    }
}
