using Controller;
using UI.Hud;
using UnityEngine;

namespace Attributes.Health
{
    [AddComponentMenu("Playground/Attributes/Health System")]
    public class HealthSystemAttribute : MonoBehaviour
    {
        [SerializeField] private int health = 3;
        [SerializeField] private AudioSource audioDmg;

        private GameController _gc;
        private UIScript _ui;
        private int _maxHealth;
        private bool _isPlayer;

        private void Start()
        {
            // Find the UI in the scene and store a reference for later use
            _gc = GameController.Instance;
            _ui = FindObjectOfType<UIScript>();

            if (CompareTag("Player"))
            {
                _isPlayer = true;
            }

            // Notify the UI so it will show the right initial amount
            if (_ui != null && _isPlayer)
            {
                _ui.SetHealth(health);
            }

            _maxHealth = health; //note down the maximum health to avoid going over it when the player gets healed
        }


        // changes the energy from the player
        // also notifies the UI (if present)
        public void ModifyHealth(int amount)
        {
            //avoid going over the maximum health by forcing
            if (health + amount > _maxHealth)
            {
                amount = _maxHealth - health;
            }

            health += amount;

            UpdateUI(amount);

            if (_isPlayer)
            {
                audioDmg.Play();
            }
            
            //DEAD
            if (health > 0) return;
            _gc.AddPoints();
            if (!_isPlayer)
            {
                Destroy(gameObject);
            }
        }

        private void UpdateUI(int amount)
        {
            // Notify the UI so it will change the number in the corner
            if (_ui != null && _isPlayer)
            {
                _ui.ChangeHealth(amount);
            }
        }
    }
}
