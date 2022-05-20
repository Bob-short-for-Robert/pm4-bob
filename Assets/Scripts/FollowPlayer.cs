using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 2;

    private float _slow = 0;
    private float _isSlowedFor = 0;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
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
        transform.position =
            Vector3.MoveTowards(transform.position, _player.transform.position, (speed - _slow) * Time.deltaTime);
    }
    
    public void ModifySpeed(float reduceSpeed, float timeSpan)
    {
        //avoid going over 0 speed by forcin
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
