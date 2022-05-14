using UnityEngine;
using UnityEngine.SceneManagement;

namespace MapTools
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
