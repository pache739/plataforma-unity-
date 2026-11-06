using UnityEngine;

public class moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log(
            "Tocó: " + colision.name +
            " | Tag: " + colision.tag
        );

        InventarioMonedasuru inventario =
            colision.GetComponentInParent<InventarioMonedasuru>();

        if (inventario == null)
        {
            Debug.Log(
                "No encontré InventarioMonedas en " +
                colision.name
            );

            return;
        }

        inventario.sumarMoneda();

        Destroy(gameObject);
    }
}