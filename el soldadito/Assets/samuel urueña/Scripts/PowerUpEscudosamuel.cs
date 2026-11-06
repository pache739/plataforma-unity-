using UnityEngine;

public class powerUpescudo : MonoBehaviour
{
    [SerializeField] private int _cantidad = 25;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        playerStats stats =
            colision.GetComponentInParent<playerStats>();

        if (stats == null)
        {
            return;
        }

        stats.RestaurarEscudo(_cantidad);

        Destroy(gameObject);
    }
}