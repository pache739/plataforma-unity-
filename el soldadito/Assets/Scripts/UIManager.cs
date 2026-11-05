using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textoMonedas;

    public void ActualizarMonedas(int cantidad)
    {
        _textoMonedas.text = "X" + cantidad;
    }
}