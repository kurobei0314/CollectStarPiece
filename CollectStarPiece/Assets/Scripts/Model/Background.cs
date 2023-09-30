using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public enum Time
    {
        NIGHT,
        AFTERNOON
    }

    public bool isInitialized = false; 
    private Time current_time;
    public Time CurrentTime => current_time;

    public void InitializeTime(){
        current_time = Time.NIGHT;
        isInitialized = true;
    }

    public void SetTime(){
        current_time = (current_time == Time.NIGHT) ? Time.AFTERNOON : Time.NIGHT;
    }
}
