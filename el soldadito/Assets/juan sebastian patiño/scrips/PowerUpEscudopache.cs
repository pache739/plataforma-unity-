
using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    [SerializeField] private int _cantidad = 25;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        EscudoJugador escudo = colision.GetComponentInParent<EscudoJugador>();

        if (escudo == null)
        {
            return;
        }

        escudo.RestaurarEscudo(_cantidad);

        Destroy(gameObject);
    }
}