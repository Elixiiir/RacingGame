using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public UnityEvent UseObject;
    public virtual void Use()
    {
        UseObject?.Invoke();
    }
}
