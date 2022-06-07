using BoBLogger;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MapTools
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            //Destroy is called foreach object on reload. so "kill" enemies before reload to despawn their drops
            foreach (var o in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(o);
            }

            SceneManager.LoadScene("Main");
            BoBLogger.Logger.Log("LOADING NEXT LEVEL", LogLevel.Info);
        }
    }
}
