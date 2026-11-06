using UnityEngine;

public class Inventariomonedas : MonoBehaviour
{
    [SerializeField] private int _monedas;
    [SerializeField] private UIManager _uiManager;

    public int Monedas => _monedas;

    private void Start()
    {
        _uiManager.ActualizarMonedas(_monedas); // muestra X0 al empezar
    }

    public void Sumarmoneda()
    {
        _monedas++;
        Debug.Log("Monedas: " + _monedas);
        _uiManager.ActualizarMonedas(_monedas);
    }
}