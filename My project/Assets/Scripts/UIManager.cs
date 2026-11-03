using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _barra;
    [SerializeField] private TextMeshProUGUI _textoMonedas;

    public void ActualizarMonedas(int cantidad)
    {
        _textoMonedas.text = "X" + cantidad;
    }

    // ... aquí siguen SumarFillAmount, RestarFillAmount y ColorBarra como los tienes
}