using UnityEngine;
using UnityEngine.Events;

public class Item : InteractiveObject
{
    [SerializeField] private SOitem _soItem;
    public UnityEvent TakeItem;

    public SOitem Take()
    {
        TakeItem?.Invoke();
        return _soItem;
    }
}
