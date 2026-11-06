using UnityEngine;
using UnityEngine.UI;

public class UIManagerEscudo : MonoBehaviour
{
    [SerializeField] private Image barraEscudo;

    public void ActualizarBarraEscudo(float escudo)
    {
        barraEscudo.fillAmount = escudo;

        if (escudo > 0.6f)
        {
            barraEscudo.color = Color.blue;
        }
        else if (escudo > 0.3f)
        {
            barraEscudo.color = new Color(0.6f, 0f, 1f);
        }
        else
        {
            barraEscudo.color = new Color(1f, 0.2f, 0.6f);
        }
    }
}