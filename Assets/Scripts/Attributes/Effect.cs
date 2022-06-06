public abstract class Effect
{
    
    private readonly float _effect;
    private float _time;

    public Effect(float effect, float time)
    {
        _effect = effect;
        _time = time;
    }
    
    public float getEffect()
    {
        return _effect;
    }
    
    public float getEffectTime()
    {
        return _time;
    }
    
    public void decreaseEffectTimeBy(float time)
    {
        _time -= time;
    }
}