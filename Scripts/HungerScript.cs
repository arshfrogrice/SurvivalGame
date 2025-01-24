using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider slider;

    public void Setmaxhealth(int Hunger){

    slider.maxValue = Hunger;
    slider.value= Hunger;


    }
    public void SetHealth(int Hunger) {

    slider.value= Hunger;
    }
}
