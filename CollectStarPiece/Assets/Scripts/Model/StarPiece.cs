using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPiece : MonoBehaviour
{
    private int _maxStarPiece = 5;
    private int _current_piece = 0;
    public int CurrentPiece => _current_piece;

    public void AddCurrentPiece(int num)
    {
        if (_current_piece >= _maxStarPiece) return;
        _current_piece += num;
    }

    public void SubCurrentPiece(int num)
    {
        if (_current_piece < 0) return;
        _current_piece -= num;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
