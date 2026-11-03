using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image barradevida;

    public void SumarFillAmount(float amount)
    {
        barradevida.fillAmount += amount;
    }

    public void RestarFillAmount(float amount)
    {
        barradevida.fillAmount = barradevida.fillAmount - amount;
    }

    public void RestartFillAmout(float amount)
    {
        barradevida.fillAmount = barradevida.fillAmount - amount;
    }

    public void colorBarra(Color myColor)
    {
        barradevida.color = myColor;
    }

}