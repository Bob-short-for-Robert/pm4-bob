using UnityEngine;
using MapTools;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
    public int health = 3;

    private UIScript ui;
    private int maxHealth;

    private bool isPlayer = false;

    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        ui = GameObject.FindObjectOfType<UIScript>();

        if (CompareTag("Player"))
        {
            isPlayer = true;
        }

        // Notify the UI so it will show the right initial amount
        if (ui != null && isPlayer)
        {
            ui.SetHealth(health);
        }

        maxHealth = health; //note down the maximum health to avoid going over it when the player gets healed
    }


    // changes the energy from the player
    // also notifies the UI (if present)
    public void ModifyHealth(int amount)
    {
        //avoid going over the maximum health by forcin
        if (health + amount > maxHealth)
        {
            amount = maxHealth - health;
        }

        health += amount;

        UpdateUI(amount);

        //DEAD
        if (health <= 0)
        {
            SpawnEffect();
            ui.AddOnePoint();
            Destroy(gameObject);
        }
    }

    private void UpdateUI(int amount)
    {
        // Notify the UI so it will change the number in the corner
        if (ui != null && isPlayer)
        {
            ui.ChangeHealth(amount);
        }
    }

    private void SpawnEffect()
    {
        var map = GameObject.Find("Map");
        var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));
        mapController.AddEffect(transform.position, 0);
    }
}