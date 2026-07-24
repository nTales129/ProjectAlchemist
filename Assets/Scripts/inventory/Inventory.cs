using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private List<string> ingredients = new List<string>();

    public void AddIngredient(string ingredientName)
    {
        ingredients.Add(ingredientName);

        Debug.Log("Coletou " + ingredientName);
    }

    public void PrintIngredients()
    {
        Debug.Log("Inventário");

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