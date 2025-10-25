using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class carMenager : MonoBehaviour
{
    [SerializeField] private CarController _carController;
    [SerializeField] private SOitem _necessaryItem;
    [SerializeField] private Transform _sitCarTransform;
    [SerializeField] private Transform _ExirCarTransform;

    public bool IsCar;

    public void CheckItemToSitDownCar()
    {
        if(Inventory.Instance.ItemCurrent == _necessaryItem)
        {
            SitDownCar();
        }
    }

    public void SitDownCar()
    {
        playerControler.Instance.SetIsMoving(false);

        playerControler.Instance.transform.parent = _sitCarTransform;

        playerControler.Instance.transform.localPosition = Vector3.zero;
        playerControler.Instance.transform.rotation = _sitCarTransform.rotation;

        SetIsCar(true);
    }
    public void ExitCar()
    {
        playerControler.Instance.SetIsMoving(true);

        playerControler.Instance.transform.position = _ExirCarTransform.position;
        playerControler.Instance.transform.rotation = _ExirCarTransform.rotation;
        playerControler.Instance.transform.parent = null;

        SetIsCar(false);
    }

    private void SetIsCar(bool state)
    {
        IsCar = state;
        if(IsCar)
        {
            _carController.enabled = true;
        }
        else
        {
            _carController.enabled = false;
        }
    }
}
