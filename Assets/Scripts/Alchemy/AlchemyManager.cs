using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Inventory))]
public class AlchemyManager : MonoBehaviour
{
    private Inventory inventory;
    private RecipeBook recipeBook;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        recipeBook = new RecipeBook();
    }

    public void CraftPotion(List<string> selectedIngredients)
    {
        Recipe recipe = recipeBook.FindMatchingRecipe(selectedIngredients);

        if (recipe == null)
        {
            Debug.Log("Receita desconhecida.");
            return;
        }

        if (!inventory.HasIngredients(recipe.requiredIngredients))
        {
            Debug.Log("Ingredientes insuficientes no inventário.");
            return;
        }

        foreach (string ingredientName in recipe.requiredIngredients)
        {
            inventory.RemoveIngredient(ingredientName);
        }

        inventory.TryAddPotion(recipe.potionName);

        Debug.Log("Produziu " + recipe.potionName + "!");

        if (recipeBook.DiscoverRecipe(recipe))
        {
            Debug.Log("Nova receita descoberta!");
        }
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.lKey.wasPressedThisFrame)
        {
            recipeBook.PrintDiscoveredRecipes();
        }
    }
}