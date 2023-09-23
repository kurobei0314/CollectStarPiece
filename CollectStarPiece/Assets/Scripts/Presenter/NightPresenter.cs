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
    [SerializeField] private StarPieceView[] _starPieceViews;

    // Start is called before the first frame update
    void Start()
    {
        // 画面が押されたかつパーティクルが再生されている時に押す
        _nightButtonTrigger.OnPointerDownAsObservable()
            .Where(_ => _nightButtonView.IsPlayingStarParticle())
            .Subscribe(_ => {
                _starPiece.AddCurrentPiece(1);
            }).AddTo(this);

        // 表示している数が増えた時に星のカケラの表示数を増やす
        _starPiece.CurrentPiece
            .Pairwise()
            .Where(value => value.Current > value.Previous)
            .Subscribe(_ => {
                int index;
                while (true) {
                    index = UnityEngine.Random.Range(0, _starPieceViews.Length);
                    if (!_starPieceViews[index].gameObject.activeSelf) break;
                }
                _starPieceViews[index].SetStarPiece();
            }).AddTo(this);
    }

}
