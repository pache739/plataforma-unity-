using UnityEngine;

public class powerUpCuracion : MonoBehaviour
{
    [SerializeField] private int _cura = 20;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        playerStats stats =
            colision.GetComponentInParent<playerStats>();

        if (stats == null)
        {
            return;
        }

        Debug.Log("Four Loko recogida");

        stats.SumarVida(_cura);

        Destroy(gameObject);
    }
}