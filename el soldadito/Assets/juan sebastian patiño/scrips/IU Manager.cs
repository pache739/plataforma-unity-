using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Barra de vida")]
    [SerializeField] private Image barradevida;

    [Header("Panel de derrota")]
    [SerializeField] private GameObject panelPerdiste;

    [Header("Monedas")]
    [SerializeField] private TextMeshProUGUI _textoMonedas;

    public void ActualizarBarraVida(float vida)
    {
        if (barradevida == null)
        {
            return;
        }

        barradevida.fillAmount = vida;

        if (vida > 0.6f)
        {
            barradevida.color = Color.green;
        }
        else if (vida > 0.3f)
        {
            barradevida.color = new Color(1f, 0.5f, 0f);
        }
        else
        {
            barradevida.color = Color.red;
        }
    }

    public void MostrarPanelPerdiste()
    {
        if (panelPerdiste != null)
        {
            panelPerdiste.SetActive(true);
        }
    }

    public void ActualizarMonedas(int cantidad)
    {
        if (_textoMonedas != null)
        {
            _textoMonedas.text = "X" + cantidad;
        }
    }
}