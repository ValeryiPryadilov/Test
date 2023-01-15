using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool _isStarted;
    private float _timer;
    private List<float> _raceTime = new List<float>();
    [SerializeField] private TimerUi _timerUi;
    [SerializeField] Transform _playerStartPos;
    [SerializeField] RecordsWindow _recordsWindow;
    [SerializeField] GameObject _player;
    private List<ButtonController>  _buttons;
    private PlayerController _playerController;

    private void Awake()
    {
        
        _recordsWindow.Init(OnRestartButtonPressed);
    }
    private void Start()
    {
        _buttons = FindObjectsOfType<ButtonController>().ToList();
        foreach (var button in _buttons)
        {
            button.ButtonPressed += OnButtonPressed;

        }
        _playerController = _player.GetComponent<PlayerController>();
    }
    private void OnButtonPressed(ButtonState state) 
    {
        switch (state) 
        {
            case ButtonState.start:
                _isStarted = true;
                break;

            case ButtonState.finish:
                if (_isStarted) 
                {
                    _isStarted = false;

                    _raceTime.Add(_timer);
                    _raceTime.Sort();
                    _recordsWindow.SetRecords(_raceTime);
                    _recordsWindow.gameObject.SetActive(true);
                    _playerController.SetFinish(true);
                }
                break;

        }
    
    }

    private void Update()
    {
        

        if (_isStarted) 
        {
            _timer += Time.deltaTime;
            _timerUi.SetValue(_timer);
        
        }
    }

    
    private void OnRestartButtonPressed() 
    {
        _playerController.SetFinish(false);
        _recordsWindow.gameObject.SetActive(false);
        _timer= 0;
        _player.transform.SetPositionAndRotation(_playerStartPos.position, _playerStartPos.rotation);
        foreach (var button in _buttons) 
        {
            button.ResetPos();
        
        }
    }
}
