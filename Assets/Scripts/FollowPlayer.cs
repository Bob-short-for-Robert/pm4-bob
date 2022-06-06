using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private SpeedSystemAttribute _speedSystem;
    
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _player.transform.position, _speedSystem.GetSpeed() * Time.deltaTime);
    }
}
