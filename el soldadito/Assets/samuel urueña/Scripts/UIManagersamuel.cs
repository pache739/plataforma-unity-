using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textoMonedas;

    public void ActualizarMonedas(int cantidad)
    {
        if (_textoMonedas != null)
        {
            _textoMonedas.text = "X" + cantidad;
        }
    }
}