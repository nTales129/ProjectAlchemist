using UnityEngine;

/// <summary>
/// Representa os dados básicos de um ingrediente do jogo.
/// Por enquanto é só um MonoBehaviour simples, sem ScriptableObject.
/// </summary>
public class Ingredient : MonoBehaviour
{
    [Header("Dados do Ingrediente")]
    public string ingredientName = "Erva Verde";
    public Sprite icon;
    public int id;
}
