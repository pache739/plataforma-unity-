using UnityEngine;

public class InventarioMonedasuru : MonoBehaviour
{
    [SerializeField] private int _Monedas;

    [SerializeField] private UIManager _uiManager;

    public int Monedas => _Monedas;

    private void Start()
    {
        if (_uiManager != null)
        {
            _uiManager.ActualizarMonedas(_Monedas);
        }
    }

    public void sumarMoneda()
    {
        _Monedas++;

        Debug.Log("Monedas : " + _Monedas);

        if (_uiManager != null)
        {
            _uiManager.ActualizarMonedas(_Monedas);
        }
    }
}