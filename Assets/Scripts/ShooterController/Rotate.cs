using UnityEngine;

namespace ShooterController
{
    public class Rotate : MonoBehaviour
    {
        // Update is called once per frame
        public void RotateTowards(Transform towards)
        {
            var degree = DegreeBetweenTwoPoints(transform.position, towards.position);
            var to = new Vector3(0, 0, degree);
            transform.rotation = Quaternion.Euler(to);
        }


        private static float DegreeBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
