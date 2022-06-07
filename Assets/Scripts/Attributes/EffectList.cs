using System.Collections.Generic;

namespace Attributes
{
    public class EffectList<T> where T : Effect
    {
        private readonly List<T> _effects = new List<T>();
        private T _highestValue;

        public float GetActiveEffect()
        {
            if (_highestValue == null)
            {
                return 0;
            }

            return _highestValue.GetEffect();
        }

        public void Add(T eff)
        {
            _effects.Add(eff);
            if (_highestValue == null || _highestValue.GetEffect() < eff.GetEffect())
            {
                _highestValue = eff;
            }
        }

        public void ReduceEffectTime(float time)
        {
            T currentHighestEffect = null;
            float currentHighestValue = 0;
            var toRemove = new List<T>();
            foreach (var eff in _effects)
            {
                eff.DecreaseEffectTimeBy(time);
                if (eff.GetEffectTime() <= 0)
                {
                    toRemove.Add(eff);
                }
                else
                {
                    if (!(currentHighestValue < eff.GetEffect())) continue;
                    currentHighestEffect = eff;
                    currentHighestValue = eff.GetEffect();
                }
            }

            toRemove.ForEach(r => _effects.Remove(r));

            _highestValue = currentHighestEffect;
        }
    }
}
