using System;
using UnityEngine;

[AddComponentMenu("Playground/Attributes/Speed System")]
public class SpeedSystemAttribute : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;
    
    private int _slow = 0;
    private float _isSlowedFor = 0;

    private void Update()
    {
        if (_isSlowedFor <= 0)
        {
            _isSlowedFor = 0;
            _slow = 0;
        }
        else
        {
            _isSlowedFor -= Time.deltaTime;
        }
    }

    public int GetSpeed()
    {
        return speed - _slow;
    }
    
    public void ModifySpeed(int reduceSpeed, float timeSpan)
    {
        //avoid going over 0 speed by forcing
        if (speed - reduceSpeed < 0)
        {
            _slow = speed;
        }
        else
        {
            _slow -= reduceSpeed;
        }

        _isSlowedFor += timeSpan;
    }
}
