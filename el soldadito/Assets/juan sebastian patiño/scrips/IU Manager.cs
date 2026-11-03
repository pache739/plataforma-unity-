
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image barradevida;

    public void ActualizarBarraVida(float vida)
    {
        barradevida.fillAmount = vida;
    }
}