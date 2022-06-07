using System;
using Attributes.Speed;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        public SpeedSystemAttribute _speedSystem;
    
        private BoxCollider2D boxCollider;
        private RaycastHit2D raycasthit;
        private Vector3 moveDelta;


        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // reset moveDelta 
            moveDelta = new Vector3(x, y, 0);

            // swap Sprite direction
            if (moveDelta.x < 0)
                transform.localScale = Vector3.one;
            else if (moveDelta.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);

            var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
            raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
                Math.Abs(moveDelta.y * Time.deltaTime), collisionMasks);
            if (raycasthit.collider == null)
            {
                transform.Translate(0, moveDelta.y * Time.deltaTime * _speedSystem.GetSpeed(), 0);
            }

            raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
                Math.Abs(moveDelta.x * Time.deltaTime), collisionMasks);
            if (raycasthit.collider == null)
            {
                transform.Translate(moveDelta.x * Time.deltaTime * _speedSystem.GetSpeed(), 0, 0);
            }
        }
    }
}
