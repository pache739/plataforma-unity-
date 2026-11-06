using UnityEngine;

public class PowerUpCuracion : MonoBehaviour
{
    [SerializeField] private int _cura = 20;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        PlayerStats stats = colision.GetComponentInParent<PlayerStats>();

        if (stats == null)
        {
            return;
        }

        Debug.Log("Four Loko recogida");
        stats.SumarVida(_cura);
        Destroy(gameObject);
    }
}