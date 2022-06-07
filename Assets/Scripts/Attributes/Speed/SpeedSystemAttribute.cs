using UnityEngine;

namespace Attributes.Speed
{
    [AddComponentMenu("Playground/Attributes/Speed System")]
    public class SpeedSystemAttribute : MonoBehaviour
    {
        [SerializeField] private float speed = 3;

        private readonly EffectList<SlowEffect> _listOfSlowsWithTime = new EffectList<SlowEffect>();

        private void Update()
        {
            _listOfSlowsWithTime.ReduceEffectTime(Time.deltaTime);
        }

        public float GetSpeed()
        {
            var effectiveSpeed = speed - _listOfSlowsWithTime.GetActiveEffect();
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
}