using UnityEngine;

public class PinchosInstantanea : MonoBehaviour
{
    private Transform _soldado;
    private Vector3 _posicionInicial;

    private void Start()
    {
        MovimientoJugador jugador = FindFirstObjectByType<MovimientoJugador>();
        _soldado = jugador.transform;
        _posicionInicial = _soldado.position;
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        Matar(colision.collider);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        Matar(colision);
    }

    private void Matar(Collider2D colision)
    {
        if (colision.GetComponentInParent<MovimientoJugador>() == null)
        {
            return;
        }

        _soldado.position = _posicionInicial;
        _soldado.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}