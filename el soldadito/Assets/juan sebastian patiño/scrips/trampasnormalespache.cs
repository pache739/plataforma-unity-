using UnityEngine;

public class PinchosQuitaVida : MonoBehaviour
{
    [SerializeField] private int _daño = 10;
    [SerializeField] private float _tiempoEntreGolpes = 1f;

    private float _ultimoGolpe = -100f;

    private void OnCollisionEnter2D(Collision2D colision)
    {
        Golpear(colision.collider);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        Golpear(colision);
    }

    private void Golpear(Collider2D colision)
    {
        if (Time.time - _ultimoGolpe < _tiempoEntreGolpes)
        {
            return;
        }

        PlayerStats stats = colision.GetComponentInParent<PlayerStats>();

        if (stats == null)
        {
            return;
        }

        _ultimoGolpe = Time.time;
        stats.RestarVida(_daño);
    }
}