using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class BackgroundView : MonoBehaviour
{
    private bool _isButtonEnabled= true;
    public bool IsButtonEnabled => _isButtonEnabled;

    [SerializeField] GameObject _backgroundImage;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickChangeTimeButton(){
        if (!_isButtonEnabled) return;
        _isButtonEnabled = false;

        // ここで背景が回る
        _backgroundImage.transform
            .DORotate(_backgroundImage.transform.eulerAngles + Vector3.forward * 180f, 1f, RotateMode.FastBeyond360)
            .OnComplete(() => _isButtonEnabled = true);
    }
}
