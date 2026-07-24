using UnityEngine;

/// <summary>
/// Detecta quando o Player encosta no ingrediente.
/// Por enquanto: só destrói o objeto e mostra uma mensagem no Console.
/// Nenhuma lógica de inventário ainda.
/// </summary>
[RequireComponent(typeof(Ingredient))]
public class IngredientPickup : MonoBehaviour
{
    private Ingredient ingredientData;

    private void Awake()
    {
        ingredientData = GetComponent<Ingredient>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Inventory inventory = other.GetComponentInParent<Inventory>();

        if (inventory == null)
        {
            Debug.LogWarning("O Player não possui um Inventory.");
            return;
        }

        inventory.AddIngredient(ingredientData.ingredientName);

        Destroy(gameObject);
    }
}
