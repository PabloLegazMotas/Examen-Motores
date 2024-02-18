using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDelJuego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FinDelJuego") Debug.Log("Felicidades, has escapado");
    }
}
