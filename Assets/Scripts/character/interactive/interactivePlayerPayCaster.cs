using System;
using UnityEngine;

public class interactivePlayerPayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerInteractive;
    [SerializeField] private float _rayLength;

    public event Action<RaycastHit> OnRaycastHit;
    public event Action OnNotRaycastHit;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength, _layerInteractive))
        {
            if (hit.collider.gameObject != null)
            {
                OnRaycastHit?.Invoke(hit);
            }
        }
        else
        {
            OnNotRaycastHit?.Invoke();
        }
    }
}
