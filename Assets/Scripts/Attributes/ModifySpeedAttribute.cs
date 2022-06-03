using UnityEngine;

[AddComponentMenu("Playground/Attributes/Modify Speed")]
public class ModifySpeedAttribute : MonoBehaviour
{
    public int slowTarget = 0;
    public float slowTargetForSeconds = 0;
    
    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        var speedScript = colliderData.gameObject.GetComponent<SpeedSystemAttribute>();

        if (speedScript != null)
        {
            speedScript.ModifySpeed(slowTarget, slowTargetForSeconds);
        }
    }
}
