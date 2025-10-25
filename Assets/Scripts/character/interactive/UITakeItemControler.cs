using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITakeItemControler : MonoBehaviour
{
    [SerializeField] private GameObject _targetTMP;
    [SerializeField] private interactivePlayerPayCaster _interactivePlayerPayCaster;

    private void Awake()
    {
        _interactivePlayerPayCaster.OnRaycastHit += (RaycastHit hit) => SetActiv(true);
        _interactivePlayerPayCaster.OnNotRaycastHit += () => SetActiv(false);
    }

    public void SetActiv(bool state)
    {
        if (_targetTMP.activeSelf != state)
        {
            _targetTMP.SetActive(state);
        }
    }
}
