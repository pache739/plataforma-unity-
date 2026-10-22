using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;


private void OnTriggerStay2D(Collider2D colision)
    {
        Debug.Log("Detectando: " + colision.gameObject.name);

        if (colision.CompareTag("Suelo"))
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