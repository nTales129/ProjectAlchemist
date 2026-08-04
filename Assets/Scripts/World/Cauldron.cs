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

            alchemyManager.CraftSelectedIngredients();
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