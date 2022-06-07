using UnityEngine;
using static BoBLogger.Logger;

namespace Player.Peripheral
{
    [AddComponentMenu("Playground/Movement/Camera Follow")]
    public class CameraFollow : MonoBehaviour
    {
        [Header("Object to follow")]
        // This is the object that the camera will follow
        [SerializeField] private Transform target;

        //Bound camera to limits
        [SerializeField] private bool limitBounds;
        [SerializeField] private float left = -5f;
        [SerializeField] private float right = 5f;
        [SerializeField] private float bottom = -5f;
        [SerializeField] private float top = 5f;

        private Vector3 _lerpedPosition;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        // FixedUpdate is called every frame, when the physics are calculated
        private void FixedUpdate()
        {
            if (target == null) return;
            // Find the right position between the camera and the object
            _lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
            _lerpedPosition.z = -10f;
        }


        // LateUpdate is called after all other objects have moved
        private void LateUpdate()
        {
            if (target != null)
            {
                // Move the camera in the position found previously
                transform.position = _lerpedPosition;

                // Bounds the camera to the limits (if enabled)
                if (!limitBounds) return;
                BindCameraToMap();
                return;
            }

            Log("No Target found for Camera to follow", LogType.Error);
        }

        // TODO FIXME
        private void BindCameraToMap()
        {
            var bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
            var topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
            var screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

            var boundPosition = transform.position;
            if (boundPosition.x > right - (screenSize.x / 2f))
            {
                boundPosition.x = right - (screenSize.x / 2f);
            }

            if (boundPosition.x < left + (screenSize.x / 2f))
            {
                boundPosition.x = left + (screenSize.x / 2f);
            }

            if (boundPosition.y > top - (screenSize.y / 2f))
            {
                boundPosition.y = top - (screenSize.y / 2f);
            }

            if (boundPosition.y < bottom + (screenSize.y / 2f))
            {
                boundPosition.y = bottom + (screenSize.y / 2f);
            }

            transform.position = boundPosition;
        }
    }
}
