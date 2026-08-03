using System.Collections.Generic;

public class RecipeBook
{
    private List<Recipe> recipes = new List<Recipe>();

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
}