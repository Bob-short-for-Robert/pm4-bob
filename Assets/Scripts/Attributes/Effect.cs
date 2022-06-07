namespace Attributes
{
    public abstract class Effect
    {
    
        private readonly float _effect;
        private float _time;

        protected Effect(float effect, float time)
        {
            _effect = effect;
            _time = time;
        }
    
        public float GetEffect()
        {
            return _effect;
        }
    
        public float GetEffectTime()
        {
            return _time;
        }
    
        public void DecreaseEffectTimeBy(float time)
        {
            _time -= time;
        }
    }
}
