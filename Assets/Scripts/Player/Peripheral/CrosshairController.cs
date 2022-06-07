using ShooterController;
using UnityEditor.PackageManager;
using UnityEngine;
using static BoBLogger.Logger;
namespace Player.Peripheral
{
    public class CrosshairController : MonoBehaviour
    {
        public Shooter shooter;

        private void Start()
        {
            Cursor.visible = Debug.isDebugBuild;
        }

        private void Update()
        {
            if (Camera.main == null)
            {
                Log("No Camera found!", LogLevel.Error);
                return;
            }
            var mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                0.0f - Camera.main.transform.position.z));
            var mouseInWorld = new Vector3(mouse.x, mouse.y);


            transform.position = mouseInWorld;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shooter.Shoot(mouseInWorld);
            }
        }
    }
}
