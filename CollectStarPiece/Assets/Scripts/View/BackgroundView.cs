using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class BackgroundView : MonoBehaviour
{
    private bool _isButtonEnabled;
    public bool IsButtonEnabled => _isButtonEnabled;
    
    // Start is called before the first frame update
    void Start()
    {
        _isButtonEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickChangeTimeButton(){
        if (!_isButtonEnabled) return;
        _isButtonEnabled = false;
        
        Debug.Log("wa------------------------i");

        // ここで背景が回る
    }
}
