using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;

    private void OnTriggerStay2D(Collider2D colision)
    {
        if (colision.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            Debug.Log("Tocó el suelo");
        }
    }

    private void OnTriggerExit2D(Collider2D colision)
    {
        if (colision.CompareTag("Suelo"))
        {
            estaEnSuelo = false;
            Debug.Log("Estoy saltando");
        }
    }

}