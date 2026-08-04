using System.Collections.Generic;
using UnityEngine;

public class RecipeBook
{
    private List<Recipe> recipes = new List<Recipe>();
    private List<string> discoveredRecipes = new List<string>();

    public RecipeBook()
    {
        recipes.Add(
            new Recipe(
                "Poção de Cura",
                new List<string> { "Erva Verde", "Cogumelo Azul" }
            )
        );
    }

    public Recipe FindMatchingRecipe(List<string> selectedIngredients)
    {
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Matches(selectedIngredients))
                return recipe;
        }

        return null;
    }

    public bool DiscoverRecipe(Recipe recipe)
    {
        if (discoveredRecipes.Contains(recipe.potionName))
            return false;

        discoveredRecipes.Add(recipe.potionName);
        return true;
    }

    public void PrintDiscoveredRecipes()
    {
        Debug.Log("Receitas descobertas:");

        foreach (string potionName in discoveredRecipes)
        {
            Debug.Log("- " + potionName);
        }
    }
}