using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Inventory))]
public class AlchemyManager : MonoBehaviour
{
    private Inventory inventory;
    private RecipeBook recipeBook;

    private List<string> selectedIngredients = new List<string>();

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        recipeBook = new RecipeBook();
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectIngredient("Erva Verde");
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectIngredient("Cogumelo Azul");
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ClearSelectedIngredients();
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            recipeBook.PrintDiscoveredRecipes();
        }
    }

    public void SelectIngredient(string ingredientName)
    {
        List<string> newSelection = new List<string>(selectedIngredients);
        newSelection.Add(ingredientName);

        if (!inventory.HasIngredients(newSelection))
        {
            Debug.Log("Você não possui ingredientes suficientes para selecionar " + ingredientName + ".");
            return;
        }

        selectedIngredients.Add(ingredientName);

        Debug.Log("Selecionou " + ingredientName);
        PrintSelectedIngredients();
    }

    public void ClearSelectedIngredients()
    {
        selectedIngredients.Clear();
        Debug.Log("Ingredientes selecionados foram limpos.");
    }

    public void CraftSelectedIngredients()
    {
        if (selectedIngredients.Count == 0)
        {
            Debug.Log("Nenhum ingrediente foi selecionado.");
            return;
        }

        if (CraftPotion(selectedIngredients))
        {
            ClearSelectedIngredients();
        }
    }

    private bool CraftPotion(List<string> ingredientsToCraft)
    {
        Recipe recipe = recipeBook.FindMatchingRecipe(ingredientsToCraft);

        if (recipe == null)
        {
            Debug.Log("Receita desconhecida.");
            return false;
        }

        if (!inventory.HasIngredients(recipe.requiredIngredients))
        {
            Debug.Log("Ingredientes insuficientes no inventário.");
            return false;
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

        return true;
    }

    private void PrintSelectedIngredients()
    {
        Debug.Log("Ingredientes selecionados:");

        foreach (string ingredientName in selectedIngredients)
        {
            Debug.Log("- " + ingredientName);
        }
    }
}