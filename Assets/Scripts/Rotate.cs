using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    // Update is called once per frame
    public void RotateTowards(Transform towards)
    {
        var degree = DegreeBetweenTwoPoints(transform.position, towards.position);
        var to = new Vector3(0, 0, degree);
        if (degree < 180)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        }
    }
    
    
    private static float DegreeBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
