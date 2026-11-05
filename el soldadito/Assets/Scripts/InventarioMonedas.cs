using UnityEngine;

public class InventarioMonedas : MonoBehaviour
{
    [SerializeField] private int _monedas;
    [SerializeField] private UIManager _uiManager;

    public int Monedas => _monedas;

    private void Start()
    {
        _uiManager.ActualizarMonedas(_monedas); // muestra X0 al empezar
    }

    public void SumarMoneda()
    {
        _monedas++;
        Debug.Log("Monedas: " + _monedas);
        _uiManager.ActualizarMonedas(_monedas);
    }
}