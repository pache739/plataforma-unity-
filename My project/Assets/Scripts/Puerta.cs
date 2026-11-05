using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private int _monedasNecesarias = 2;
    [SerializeField] private GameObject _panelVictoria;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("Algo tocó la puerta: " + colision.name);

        InventarioMonedas inventario = colision.GetComponentInParent<InventarioMonedas>();

        if (inventario == null)
        {
            Debug.Log("Pero no tiene InventarioMonedas");
            return;
        }

        if (inventario.Monedas < _monedasNecesarias)
        {
            Debug.Log("Te faltan " + (_monedasNecesarias - inventario.Monedas) + " monedas");
            return;
        }

        Debug.Log("¡Ganaste!");

        if (_panelVictoria == null)
        {
            Debug.Log("El campo Panel Victoria está vacío");
            return;
        }

        _panelVictoria.SetActive(true);
        Time.timeScale = 0f;
    }
}