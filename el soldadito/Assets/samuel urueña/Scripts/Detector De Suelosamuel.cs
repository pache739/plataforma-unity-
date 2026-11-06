using UnityEngine;

public class DetectorSueloUru : MonoBehaviour
{
    public bool estaEnSuelo;

    [SerializeField] private float _radio = 0.25f;

    private void FixedUpdate()
    {
        estaEnSuelo = false;

        Collider2D[] colisiones = Physics2D.OverlapCircleAll(
            transform.position,
            _radio
        );

        foreach (Collider2D colision in colisiones)
        {
            if (colision.CompareTag("Suelo"))
            {
                estaEnSuelo = true;
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radio);
    }
}