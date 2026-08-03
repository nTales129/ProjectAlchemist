using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cauldron : MonoBehaviour
{
    private bool playerInRange;
    private AlchemyManager alchemyManager;

    private void Update()
    {
        if (!playerInRange)
            return;

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (alchemyManager == null)
            {
                Debug.LogWarning("O Player não possui um AlchemyManager.");
                return;
            }

            List<string> testIngredients = new List<string>
            {
                "Erva Verde",
                "Cogumelo Azul"
            };

            alchemyManager.CraftPotion(testIngredients);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = true;
        alchemyManager = other.GetComponentInParent<AlchemyManager>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;
        alchemyManager = null;
    }
}