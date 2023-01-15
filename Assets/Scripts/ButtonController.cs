using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] ButtonState State;
    private Vector3 _initPos;

    public Action<ButtonState> ButtonPressed;
    private void Start()
    {
        _initPos = transform.position;
    }
    public void ResetPos() 
    {
        transform.position = _initPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            transform.position -= new Vector3(0, 0.2f, 0);
            ButtonPressed?.Invoke(State);
        
        }
    }
}
public enum ButtonState 
{
    start,finish

}
