using UnityEngine;
using UnityEngine.UI;

public class TimeofDayScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime(float time)
    {
        slider.maxValue = time; // sets the max time for the bar 
        slider.value = time; // sets the bar to the max time
    }

    public void SetCurrentTime(float time)
    {
        slider.value = time; // this will be used to update the bar
    }
}
