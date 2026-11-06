using UnityEngine;
using UnityEngine.Events;

public class PowerUpCuracion : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _alCurar;

    [SerializeField] private int _cantidad = 25;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        PlayerStatspache stats = colision.GetComponentInParent<PlayerStatspache>();

        if (stats == null)
        {
            return;
        }

        stats.SumarVida(_cantidad);

        Debug.Log("Curación recogida");

        Destroy(gameObject);
    }
}