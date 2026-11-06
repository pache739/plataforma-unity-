using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {

        InventarioMonedas inventario = colision.GetComponentInParent<InventarioMonedas>();

        if (inventario == null)
        {
            Debug.Log("No encontré InventarioMonedas en " + colision.name);
            return;
        }

        inventario.SumarMoneda();
        Destroy(gameObject);
    }
}