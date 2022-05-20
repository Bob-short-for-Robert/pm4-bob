using UnityEngine;

public class HelperClass
{
    public static void WaitForSeconds(float seconds)
    {
        var start = Time.time;
        while (Time.time < start + seconds)
        {
        }
    }
}
