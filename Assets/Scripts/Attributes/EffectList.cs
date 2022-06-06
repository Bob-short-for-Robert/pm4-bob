using System.Collections.Generic;

public class EffectList<T> where T : Effect
{
    private List<T> effects = new List<T>();
    private T _highestValue;
    
    public float getActiveEffect()
    {
        if (_highestValue == null)
        {
            return 0;
        }
        return _highestValue.getEffect();
    }

    public void Add(T eff)
    {
        effects.Add(eff);
        if (_highestValue == null || _highestValue.getEffect() < eff.getEffect())
        {
            _highestValue = eff;
        }
    }

    public void ReduceEffectTime(float time)
    {
        T currentHighestEffect = null;
        float currentHighestValue = 0;
        List<T> toRemove = new List<T>();
        foreach (T eff in effects)
        {
            eff.decreaseEffectTimeBy(time);
            if (eff.getEffectTime() <= 0)
            {
                toRemove.Add(eff);
            }
            else
            {
                if (currentHighestValue < eff.getEffect())
                {
                    currentHighestEffect = eff;
                    currentHighestValue = eff.getEffect();
                }
            }
        }
        toRemove.ForEach(r => effects.Remove(r));

        _highestValue = currentHighestEffect;
    }
}
