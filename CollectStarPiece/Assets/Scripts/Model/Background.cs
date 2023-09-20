using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public enum Time
    {
        AFTERNOON,
        NIGHT
    }
    private Time current_time = Time.NIGHT;
    public Time CurrentTime => current_time;

    public void SetTime(){
        current_time = (current_time == Time.NIGHT) ? Time.AFTERNOON : Time.NIGHT;
    }
}
