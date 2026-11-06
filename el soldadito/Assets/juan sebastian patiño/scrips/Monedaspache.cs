
using UnityEngine;

public class Monedapache : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        Inventariomonedas inventario =
            colision.GetComponentInParent<Inventariomonedas>();

        if (inventario == null)
        {
            Debug.Log("No encontré InventarioMonedas en " + colision.name);
            return;
        }

        inventario.Sumarmoneda();

        Destroy(gameObject);
    }
}