using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private int _monedasnecesarias = 2;
    [SerializeField] private GameObject _PanelVictoria;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("Algo tocó la puerta: " + colision.name);

        InventarioMonedasuru inventario =
            colision.GetComponentInParent<InventarioMonedasuru>();

        if (inventario == null)
        {
            Debug.Log("Pero no tiene InventarioMonedas");
            return;
        }

        if (inventario.Monedas < _monedasnecesarias)
        {
            Debug.Log(
                "Te faltan " +
                (_monedasnecesarias - inventario.Monedas) +
                " monedas"
            );

            return;
        }

        Debug.Log("¡Ganaste!");

        if (_PanelVictoria == null)
        {
            Debug.Log("El campo Panel Victoria está vacío");
            return;
        }

        _PanelVictoria.SetActive(true);

        Time.timeScale = 0f;
    }
}