using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private int _monedasNecesarias = 2;
    [SerializeField] private GameObject _panelVictoria;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        InventarioMonedas inventario = colision.GetComponentInParent<InventarioMonedas>();

        if (inventario == null)
        {
            return;
        }

        if (inventario.Monedas < _monedasNecesarias)
        {
            Debug.Log("Te faltan " + (_monedasNecesarias - inventario.Monedas) + " monedas");
            return;
        }

        Debug.Log("¡Ganaste!");

        if (_panelVictoria != null)
        {
            _panelVictoria.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}