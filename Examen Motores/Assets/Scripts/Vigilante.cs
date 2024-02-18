using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vigilante : MonoBehaviour
{
    [SerializeField] float longitud_rayo = 15f;
    public LayerMask LayerToHitRaycast;
    [SerializeField] Transform ojos;
    private bool mirandoIzquierda;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Vigilancia());
        Raycast();
    }

    private void Raycast()
    {
        Vector3 direction = ojos.forward;
        Vector3 target = (ojos.position + (direction * longitud_rayo));
        RaycastHit hit;
        if (Physics.Raycast(ojos.position, direction, out hit, longitud_rayo, LayerToHitRaycast))
        {

        }
        else
        {
            Debug.DrawRay(ojos.position, Vector3.forward * longitud_rayo, Color.green);
        }
    }

    IEnumerator Vigilancia()
    {
        while (true)
        {
            if (mirandoIzquierda)
            {
                for (int i = 0; i < 15; i++)
                {
                    transform.Rotate(Vector3.up, 1);
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    transform.Rotate(Vector3.up, -1);
                    yield return new WaitForSeconds(0.05f);
                }
            }
            mirandoIzquierda = !mirandoIzquierda;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
