using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 10;

    private List<string> ingredients = new List<string>();
    private List<string> potions = new List<string>();

    private int UsedSpace => ingredients.Count + potions.Count;

    public bool TryAddIngredient(string ingredientName)
    {
        if (UsedSpace >= capacity)
        {
            Debug.Log("Inventário cheio.");
            return false;
        }

        ingredients.Add(ingredientName);
        Debug.Log("Coletou " + ingredientName);
        return true;
    }

    public bool TryAddPotion(string potionName)
    {
        if (UsedSpace >= capacity)
        {
            Debug.Log("Inventário cheio.");
            return false;
        }

        potions.Add(potionName);
        return true;
    }

    public bool HasIngredients(List<string> ingredientNames)
    {
        List<string> availableIngredients = new List<string>(ingredients);

        foreach (string ingredientName in ingredientNames)
        {
            if (!availableIngredients.Remove(ingredientName))
                return false;
        }

        return true;
    }

    public bool RemoveIngredient(string ingredientName)
    {
        int ingredientIndex = ingredients.IndexOf(ingredientName);

        if (ingredientIndex == -1)
            return false;

        ingredients.RemoveAt(ingredientIndex);
        return true;
    }

    public void PrintIngredients()
    {
        Debug.Log("Inventário (" + UsedSpace + "/" + capacity + ")");

        Debug.Log("Ingredientes:");
        foreach (string ingredientName in ingredients)
        {
            Debug.Log("- " + ingredientName);
        }

        Debug.Log("Poções:");
        foreach (string potionName in potions)
        {
            Debug.Log("- " + potionName);
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