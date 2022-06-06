using System;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using UnityEngine;

[AddComponentMenu("Playground/Attributes/Speed System")]
public class SpeedSystemAttribute : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    private EffectList<SlowEffect> _listOfSlowsWithTime = new EffectList<SlowEffect>();

    private void Update()
    {
        _listOfSlowsWithTime.ReduceEffectTime(Time.deltaTime);
    }

    public float GetSpeed()
    {
        var effectiveSpeed = speed - _listOfSlowsWithTime.getActiveEffect();
        if (effectiveSpeed < 0)
        {
            return 0;
        }
        return effectiveSpeed;
    }

    public void ApplySlow(SlowEffect slowEffect)
    {
        _listOfSlowsWithTime.Add(slowEffect);
    }
}