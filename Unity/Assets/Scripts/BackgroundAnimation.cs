using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    public Image background;
    public Sprite[] bglist;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0 && slider.value <= 0.2)
        {
            background.sprite = bglist[0];
        }
        else if (slider.value > 0.2 && slider.value <= 0.3)
        {
            background.sprite = bglist[2];
        }
        else if (slider.value > 0.3 && slider.value <= 0.4)
        {
            background.sprite = bglist[3];
        }
        else if (slider.value > 0.4 && slider.value <= 0.5)
        {
            background.sprite = bglist[4];
        }
        else if (slider.value > 0.5 && slider.value <= 0.6)
        {
            background.sprite = bglist[5];
        }
        else if (slider.value > 0.6 && slider.value <= 0.7)
        {
            background.sprite = bglist[6];
        }
        else if (slider.value > 0.7 && slider.value <= 0.8)
        {
            background.sprite = bglist[7];
        }
        else if (slider.value > 0.8)
        {
            background.sprite = bglist[8];
        }
    }
}
