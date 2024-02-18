using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float velocidadGiro = 90.0f;
    [SerializeField] private float velocidadAvance = 5.0f;

    private Vector2 Axis;

    private CharacterController characterController;
    private Vector3 posicionInicial;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 Axis = GetInputAxis();
        Rotar(Axis.x);
        Avanzar(Axis.y);
    }

    private Vector2 GetInputAxis()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Rotar(float AxisHorizontal)
    {
        transform.Rotate(0, AxisHorizontal * velocidadGiro * Time.deltaTime, 0);
    }

    private void Avanzar(float AxisVertical)
    {
        float Avance = AxisVertical * velocidadAvance * Time.deltaTime;
        characterController.Move(transform.TransformDirection(Vector3.forward) * Avance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampa"))
        {
            transform.position = posicionInicial;
        }
    }
}