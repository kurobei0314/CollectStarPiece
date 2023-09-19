using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private enum Time
    {
        AFTERNOON,
        NIGHT
    }
    private Time current_time = Time.NIGHT;

    public void SetTime(){
        current_time = (current_time == Time.NIGHT) ? Time.AFTERNOON : Time.NIGHT;
    }
}
