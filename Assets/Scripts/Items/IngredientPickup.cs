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
        // Ajuste a tag "Player" conforme o nome usado no seu GameObject do jogador.
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Coletou " + ingredientData.ingredientName);

        Destroy(gameObject);
    }
}
