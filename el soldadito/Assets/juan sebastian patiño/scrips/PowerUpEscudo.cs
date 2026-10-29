using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    [SerializeField] private int _cantidad = 25;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        PlayerStats stats = colision.GetComponentInParent<PlayerStats>();

        if (stats == null)
        {
            return;
        }

        stats.RestaurarEscudo(_cantidad);
        Destroy(gameObject);
    }
}