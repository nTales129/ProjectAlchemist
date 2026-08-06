using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 10;

    private List<string> ingredients = new List<string>();
    private List<string> potions = new List<string>();

    private int UsedSpace => ingredients.Count + potions.Count;

    public event Action OnInventoryChanged;

    public bool TryAddIngredient(string ingredientName)
    {
        if (UsedSpace >= capacity)
        {
            Debug.Log("Inventário cheio.");
            return false;
        }

        ingredients.Add(ingredientName);
        Debug.Log("Coletou " + ingredientName);

        NotifyInventoryChanged();
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

        NotifyInventoryChanged();
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

        NotifyInventoryChanged();
        return true;
    }

    public string GetInventoryText()
    {
        string text = "Inventário (" + UsedSpace + "/" + capacity + ")";

        text += "\n\nIngredientes";

        if (ingredients.Count == 0)
        {
            text += "\n- Nenhum";
        }
        else
        {
            foreach (string ingredientName in ingredients)
            {
                text += "\n- " + ingredientName;
            }
        }

        text += "\n\nPoções";

        if (potions.Count == 0)
        {
            text += "\n- Nenhuma";
        }
        else
        {
            foreach (string potionName in potions)
            {
                text += "\n- " + potionName;
            }
        }

        return text;
    }

    private void NotifyInventoryChanged()
    {
        OnInventoryChanged?.Invoke();
    }
}