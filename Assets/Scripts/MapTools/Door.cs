using System.Linq;
using Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BoBLogger.Logger;

namespace MapTools
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0) return;
            if ((from spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint") 
                    let a = spawnPoint.GetComponent<SpawnPoint>().WaveCount 
                    select spawnPoint).Any(spawnPoint => spawnPoint.GetComponent<SpawnPoint>().WaveCount > 0))
            {
                return;
            }
            //Destroy is called foreach object on reload. so "kill" enemies before reload to despawn their drops
            SceneManager.LoadScene("Main");
            Log("LOADING NEXT LEVEL", LogType.Log);
        }
    }
}
