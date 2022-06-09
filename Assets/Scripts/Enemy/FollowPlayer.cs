using Attributes.Speed;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class FollowPlayer : MonoBehaviour
    {
        [FormerlySerializedAs("_speedSystem")] [SerializeField]
        private SpeedSystemAttribute speedSystem;

        private GameObject _player;

        private void Start()
        {
            _player = GameObject.Find("Player");
        }

        private void Update()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _player.transform.position,
                    speedSystem.GetSpeed() * Time.deltaTime);
        }
    }
}
