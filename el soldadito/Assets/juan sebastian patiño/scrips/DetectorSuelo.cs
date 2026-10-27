using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detectando: " + collision.gameObject.name);

        if (collision.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            Debug.Log("ESTOY EN EL SUELO");
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            estaEnSuelo = false;
        }
    }
}