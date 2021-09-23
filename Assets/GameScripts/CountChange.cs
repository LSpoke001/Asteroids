using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountChange : MonoBehaviour
{
    public CreateAsteroids asteroid;
    public Text countText;

    private void OnEnable()
    {
        asteroid.CountChanged += CountRecalculate;
    }

    private void OnDisable()
    {
        asteroid.CountChanged -= CountRecalculate;
    }

    private void CountRecalculate(int value)
    {
        countText.text = value.ToString();
    }
}
