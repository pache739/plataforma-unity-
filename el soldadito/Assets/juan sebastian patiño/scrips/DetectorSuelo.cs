using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Suelo"))
        {
            estaEnSuelo = true;

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