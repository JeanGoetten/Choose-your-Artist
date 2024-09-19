using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image image1;
    public Image image2;

    public List<Sprite> images1;
    public List<Sprite> images2;

    public int counter1; 
    public int counter2;

    public void Start()
    {
        image1.sprite = images1[0];
        image2.sprite = images2[0];

        counter1 = 0;
        counter2 = 0;
    }

    public void Next1()
    {
        counter1++;
        image1.sprite = images1[counter1];
    }

    public void Next2()
    {
        counter2++;
        image2.sprite = images2[counter2];
    }
}
