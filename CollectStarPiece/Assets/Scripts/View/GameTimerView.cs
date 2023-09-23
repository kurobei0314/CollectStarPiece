using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimerView : MonoBehaviour
{
    private bool _isStartMainGame = false;
    private float _nowTime = 60.0f;
    public float NowTime => _nowTime;
    [SerializeField] private TextMeshProUGUI _timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartTimer(float time)
    {
        _nowTime = time;
        _isStartMainGame = true;
    }

    public void EndTimer()
    {
        _isStartMainGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartMainGame)
        {
            _nowTime -= Time.deltaTime;
            _timerText.text = ((int)_nowTime).ToString();
        }
    }
}
