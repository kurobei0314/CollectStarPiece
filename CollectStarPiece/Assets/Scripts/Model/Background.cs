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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTime(){
        current_time = (current_time == Time.NIGHT) ? Time.AFTERNOON : Time.NIGHT;
        Debug.Log("current: " + current_time);
    }
}
