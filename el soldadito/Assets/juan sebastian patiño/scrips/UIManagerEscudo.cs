
using UnityEngine;
using UnityEngine.UI;

public class UIManagerEscudo : MonoBehaviour
{
    [SerializeField] private Image barraEscudo;

    public void ActualizarBarraEscudo(float escudo)
    {
        barraEscudo.fillAmount = escudo;
    }
}