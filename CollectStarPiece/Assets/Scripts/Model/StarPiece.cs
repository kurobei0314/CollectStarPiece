using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StarPiece : MonoBehaviour
{
    private int _maxStarPiece = 5;
    private ReactiveProperty<int> _current_piece = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> CurrentPiece => _current_piece;

    public void AddCurrentPiece(int num)
    {
        if (_current_piece.Value >= _maxStarPiece) return;
        _current_piece.Value += num;
    }

    public void SubCurrentPiece(int num)
    {
        if (_current_piece.Value < 0) return;
        _current_piece.Value -= num;
    }
}
