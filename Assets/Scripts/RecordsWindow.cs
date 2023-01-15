using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecordsWindow : MonoBehaviour
{
    [SerializeField] GameObject _recordItem;
    [SerializeField] Transform _itemsRoot;
    [SerializeField] int _itemsCount;
    [SerializeField] Button _restartButton;
    [SerializeField] Button _exitButton;
    private List<RecordItem> _records = new List<RecordItem>();
    
    
    public void Init(UnityAction restartButtonDelegate)
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            var item = Instantiate(_recordItem,_itemsRoot).GetComponent<RecordItem>();
            item.Set(i+1, 0);
            _records.Add(item);

            
        }
        _restartButton.onClick.AddListener(restartButtonDelegate);
        _restartButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    public void SetRecords(List<float> records) 
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            if (i < records.Count) 
            {
                _records[i].Set(i+1, records[i]);
            
            }

        }
    
    }
}
