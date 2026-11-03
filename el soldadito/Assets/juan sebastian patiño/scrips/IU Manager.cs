using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image barradevida;

    public void ActualizarBarraVida(float vida)
    {
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
}