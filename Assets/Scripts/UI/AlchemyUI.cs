using TMPro;
using UnityEngine;

public class AlchemyUI : MonoBehaviour
{
    [SerializeField] private GameObject alchemyPanel;
    [SerializeField] private TMP_Text selectedIngredientsText;

    private AlchemyManager alchemyManager;

    public bool IsOpen => alchemyPanel.activeSelf;

    private void Awake()
    {
        alchemyPanel.SetActive(false);
    }

    public void Open(AlchemyManager manager)
    {
        alchemyManager = manager;
        alchemyPanel.SetActive(true);
        Refresh();
    }

    public void Close()
    {
        alchemyPanel.SetActive(false);
    }

    public void AddGreenIngredient()
    {
        if (alchemyManager == null)
            return;

        alchemyManager.SelectIngredient("Erva Verde");
        Refresh();
    }

    public void AddBlueIngredient()
    {
        if (alchemyManager == null)
            return;

        alchemyManager.SelectIngredient("Cogumelo Azul");
        Refresh();
    }

    public void CraftPotion()
    {
        if (alchemyManager == null)
            return;

        alchemyManager.CraftSelectedIngredients();
        Refresh();
    }

    public void ClearSelection()
    {
        if (alchemyManager == null)
            return;

        alchemyManager.ClearSelectedIngredients();
        Refresh();
    }

    private void Refresh()
    {
        selectedIngredientsText.text =
            alchemyManager.GetSelectedIngredientsText();
    }
}