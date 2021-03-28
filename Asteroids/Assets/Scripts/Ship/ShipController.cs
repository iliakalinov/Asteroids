using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //выбрать какие кнопки за что отвечают
    [SerializeField] private KeyCode engineKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    //класс отчечает за повороты
    private RotateController rotateController;
    //отвечает за "импульс"
    private EngineController engineController;

    //пламя движения
    public GameObject FireShip;

    public Rigidbody2D rb;
    public Transform tr;

    Vector2 mousePos;

    public float moveSpeed = 0.5f;
    public float moveAceleration = 1;

    private void Start()
    {
        engineController = GetComponent<EngineController>();
        rotateController = GetComponent<RotateController>();
    }


    private void Update()
    {   
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(engineKey))
        {
            engineController.AddForce();
            ChangeVisibleFire(true);
        }

        if (Input.GetKeyUp(engineKey))
        {
            ChangeVisibleFire(false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(leftKey))
        {
            rotateController.RotateLeft();
        }
        else if (Input.GetKey(rightKey))
            rotateController.RotateRight();
    }

    private void ChangeVisibleFire(bool status)
    {
        FireShip.SetActive(status);
    }

}
