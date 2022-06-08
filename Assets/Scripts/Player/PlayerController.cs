using System;
using Attributes.Speed;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private SpeedSystemAttribute speedSystem;
        [SerializeField] private AudioSource audioSteps;

        private BoxCollider2D _boxCollider;
        private RaycastHit2D _raycastHit;
        private Vector3 _moveDelta;


        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            // reset moveDelta 
            _moveDelta = new Vector3(x, y, 0);
            
            // stop and start steps audio depending on movement
            audioSteps.mute = _moveDelta == Vector3.zero;

            // swap Sprite direction
            if (_moveDelta.x < 0)
                transform.localScale = Vector3.one;
            else if (_moveDelta.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);

            var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
            _raycastHit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
                Math.Abs(_moveDelta.y * Time.deltaTime), collisionMasks);
            if (_raycastHit.collider == null)
            {
                transform.Translate(0, _moveDelta.y * Time.deltaTime * speedSystem.GetSpeed(), 0);
            }

            _raycastHit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
                Math.Abs(_moveDelta.x * Time.deltaTime), collisionMasks);
            if (_raycastHit.collider == null)
            {
                transform.Translate(_moveDelta.x * Time.deltaTime * speedSystem.GetSpeed(), 0, 0);
            }
        }
    }
}
