using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVidaMaximo = 100;
    [SerializeField] private Image _barraVida;
    [SerializeField] private GameObject _panelPerdiste;

    private int _puntosVidaActuales;

    private void Start()
    {
        _puntosVidaActuales = _puntosVidaMaximo;
        ActualizarBarra();
    }

    public void RestarVida(int dano)
    {
        _puntosVidaActuales = Mathf.Max(_puntosVidaActuales - dano, 0);
        ActualizarBarra();

        if (_puntosVidaActuales <= 0)
        {
            Morir();
        }
    }

    public void SumarVida(int cura)
    {
        _puntosVidaActuales = Mathf.Min(_puntosVidaActuales + cura, _puntosVidaMaximo);
        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        Debug.Log("Vida: " + _puntosVidaActuales);

        if (_barraVida == null)
        {
            return;
        }

        _barraVida.fillAmount = (float)_puntosVidaActuales / _puntosVidaMaximo;

        if (_puntosVidaActuales >= 80)
        {
            _barraVida.color = new Color(68f / 255f, 189f / 255f, 68f / 255f, 1f);
        }
        else if (_puntosVidaActuales >= 40)
        {
            _barraVida.color = new Color(245f / 255f, 73f / 255f, 39f / 255f, 1f);
        }
        else
        {
            _barraVida.color = new Color(212f / 255f, 19f / 255f, 19f / 255f, 1f);
        }
    }

    private void Morir()
    {
        if (_panelPerdiste != null)
        {
            _panelPerdiste.SetActive(true);
        }

        Destroy(gameObject);
    }
}