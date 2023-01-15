using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordItem : MonoBehaviour
{
    [SerializeField] TMP_Text _orderNumber;

    [SerializeField] TMP_Text _raceTime;

    public void Set(int n, float time) 
    {
        _orderNumber.text = $"{n}.";
        _raceTime.text = time.ToString("0.###");

    }

}
