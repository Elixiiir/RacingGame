using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image CurrentItemImage;
    [SerializeField] InteractiveObjectManager _interactiveObjectManager;

    public SOitem ItemCurrent;

    public static Inventory Instance;

    private void Awake()
    {
        _interactiveObjectManager.InteractionWithObject += TryToAddItem;
        Instance = this;
    }

    private void OnDestroy()
    {
        _interactiveObjectManager.InteractionWithObject -= TryToAddItem;
    }

    private void TryToAddItem(InteractiveObject objectTarget)
    {
        Item item = objectTarget as Item;
        if (item != null)
        {
            ItemCurrent = item.Take();
            UpdateImage();
        } 
    }

    private void UpdateImage()
    {
        CurrentItemImage.sprite = ItemCurrent.Icon;
    }

    public bool CheckCurrentItem(SOitem item)
    {
        if( ItemCurrent == item )
        {
            return true;
        }
        return false;
    }
}
