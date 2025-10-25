using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControler : MonoBehaviour
{
    [SerializeField] private float _speed = 12f;
    [Space(15)]
    [SerializeField, Range(0f, 1000f)] private int _sensation;
    [SerializeField] private float _minUpAngele = -70;
    [SerializeField] private float _maxUpAngele = 70;
    [Space(15)]
    [SerializeField] private CharacterController _controller;
    public static playerControler Instance;

    public bool IsMoving = true;


    private Camera _mainCamera;
    private float xRotation = 0;

    private void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (IsMoving)
        {
            // Получение входных данных для перемещения
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            _controller.Move(move * _speed * Time.deltaTime);
        }

        float mouseX = Input.GetAxis("Mouse X") * _sensation * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensation * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, _minUpAngele, _maxUpAngele);

        transform.Rotate(0f, mouseX, 0f);
        _mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
    }

    public void SetIsMoving(bool state)
    {
        IsMoving = state;
        if (IsMoving)
        {
            _controller.enabled = true;
        }
        else
        {
            _controller.enabled = false;
        }
    }
}
