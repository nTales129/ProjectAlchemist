using UnityEngine;
using UnityEngine.InputSystem;

public class Cauldron : MonoBehaviour
{
    private bool playerInRange;
    private AlchemyManager alchemyManager;
    private AlchemyUI alchemyUI;

    private void Awake()
    {
        alchemyUI = FindFirstObjectByType<AlchemyUI>();
    }

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

            if (alchemyUI == null)
            {
                Debug.LogWarning("Não foi encontrado um AlchemyUI na cena.");
                return;
            }

            if (alchemyUI.IsOpen)
            {
                alchemyUI.Close();
            }
            else
            {
                alchemyUI.Open(alchemyManager);
            }
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

        if (alchemyUI != null && alchemyUI.IsOpen)
        {
            alchemyUI.Close();
        }
    }
}