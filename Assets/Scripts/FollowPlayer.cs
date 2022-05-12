using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 2;

    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (_player == null) return;
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
    }
}
