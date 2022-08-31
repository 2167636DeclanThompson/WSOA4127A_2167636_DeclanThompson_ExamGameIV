using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public int happiness;
    public int health;
    public int safety;
    public int education;
    public int fun;
    public int environment;
    
    public Slider happySlider;
    public Slider healthSlider;
    public Slider safetySlider;
    public Slider eduSlider;
    public Slider funSlider;
    public Slider enviroSlider;

    private void Update()
    {
        happySlider.value = happiness;
        healthSlider.value = health;
        safetySlider.value = safety;
        eduSlider.value = education;
        funSlider.value = fun;
        enviroSlider.value = environment;

        happiness = (health + safety + education + fun + environment) / 5;
    }
}
