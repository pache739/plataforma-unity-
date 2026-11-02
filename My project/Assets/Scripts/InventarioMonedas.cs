using UnityEngine;

public class InventarioMonedas : MonoBehaviour
{
    [SerializeField] private int _monedas;

    public int Monedas => _monedas;

    public void SumarMoneda()
    {
        _monedas++;
        Debug.Log("Monedas: " + _monedas);
    }
}