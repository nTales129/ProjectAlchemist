using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TMP_Text inventoryText;
    [SerializeField] private Inventory inventory;

    public bool IsOpen => inventoryPanel.activeSelf;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
    }

    private void Start()
    {
        inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDestroy()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= Refresh;
        }
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.iKey.wasPressedThisFrame)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (IsOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        inventoryPanel.SetActive(true);
        Refresh();
    }

    public void Close()
    {
        inventoryPanel.SetActive(false);
    }

    private void Refresh()
    {
        inventoryText.text = inventory.GetInventoryText();
    }
}