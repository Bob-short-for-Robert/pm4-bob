using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Shooter shooter;

    void Start()
    {
        //Set Cursor to not be visible if not debug build
        if (!Debug.isDebugBuild)
        {
            Cursor.visible = false;
        }
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            0.0f - Camera.main.transform.position.z));
        Vector3 mouseInWorld = new Vector3(mouse.x, mouse.y);


        transform.position = mouseInWorld;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shooter.Shoot(mouseInWorld);
        }
    }
}