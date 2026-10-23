using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;
    [SerializeField] private float _radio = 0.15f;

    private void FixedUpdate()
    {
        estaEnSuelo = false;

        Collider2D[] colisiones = Physics2D.OverlapCircleAll(transform.position, _radio);
        foreach (Collider2D colision in colisiones)
        {
            if (colision.CompareTag("Suelo"))
            {
                estaEnSuelo = true;
                Debug.Log("Toca: " + colision.name);
                break;
            }
        }
    }
}