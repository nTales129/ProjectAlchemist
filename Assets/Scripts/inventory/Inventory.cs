using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 10;

    private List<string> ingredients = new List<string>();

    public bool TryAddIngredient(string ingredientName)
    {
        if (ingredients.Count >= capacity)
        {
            Debug.Log("Inventário cheio.");
            return false;
        }

        ingredients.Add(ingredientName);

        Debug.Log("Coletou " + ingredientName);
        return true;
    }

    public void PrintIngredients()
    {
        Debug.Log("Inventário (" + ingredients.Count + "/" + capacity + ")");

        foreach (string ingredientName in ingredients)
        {
            Debug.Log("- " + ingredientName);
        }
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.iKey.wasPressedThisFrame)
        {
            PrintIngredients();
        }
    }
}