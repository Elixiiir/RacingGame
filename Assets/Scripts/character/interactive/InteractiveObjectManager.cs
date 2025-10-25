using System;
using UnityEngine;

public class InteractiveObjectManager : MonoBehaviour
{
    [SerializeField] private interactivePlayerPayCaster _interactivePlayerPayCaster;

    public event Action<InteractiveObject> InteractionWithObject;

    private void Awake()
    {
        _interactivePlayerPayCaster.OnRaycastHit += IsTakingItem;
    }

    private void OnDestroy()
    {
        _interactivePlayerPayCaster.OnRaycastHit -= IsTakingItem;
    }

    public void IsTakingItem(RaycastHit hit)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            InteractiveObject objectTarget = hit.collider.gameObject.GetComponent<InteractiveObject>();
            if(objectTarget != null)
            {
                InteractionWithObject?.Invoke(objectTarget);
                objectTarget.Use();
            }
        }
    }
}
