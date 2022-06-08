using UnityEngine;

namespace Controller
{
    public class AudioOnImpact : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void OnTriggerEnter(Collider other)
        {
            audioSource.Play();
        }
    }
}
