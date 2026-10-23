using UnityEngine;

public class DetectorSuelo : MonoBehaviour

{
    [SerializeField] private MovimientoJugador _personaje;
    public bool estaEnSuelo;
    private bool _puedeSaltar = true;


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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            _puedeSaltar = true;
        }
    }
}
