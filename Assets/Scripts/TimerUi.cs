using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUi : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    public void SetValue(float value)
    {
        _text.text = value.ToString("0.###");
    
    }

    private void Awake()
    {
        _text.text = "0.0";
    }
}
