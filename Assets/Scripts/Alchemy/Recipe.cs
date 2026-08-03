using System.Collections.Generic;

public class Recipe
{
    public string potionName;
    public List<string> requiredIngredients;

    public Recipe(string potionName, List<string> requiredIngredients)
    {
        this.potionName = potionName;
        this.requiredIngredients = requiredIngredients;
    }

    public bool Matches(List<string> selectedIngredients)
    {
        if (selectedIngredients.Count != requiredIngredients.Count)
            return false;

        List<string> remainingIngredients = new List<string>(requiredIngredients);

        foreach (string ingredientName in selectedIngredients)
        {
            if (!remainingIngredients.Remove(ingredientName))
                return false;
        }

        return true;
    }
}