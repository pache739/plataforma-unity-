using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVidaMaximo = 100;
    [SerializeField] private int _puntosVidaActuales;
    [SerializeField] private int _escudoMaximo = 50;
    [SerializeField] private int _escudoActual;
    [SerializeField] private Image _barraVida;
    [SerializeField] private Image _barraEscudo;
    [SerializeField] private GameObject _panelPerdiste;

    private void Start()
    {
        _puntosVidaActuales = _puntosVidaMaximo;
        _escudoActual = _escudoMaximo;
        ActualizarBarra();
    }

    public void RestarVida(int dano)
    {
        // El escudo absorbe el daño primero
        int absorbido = Mathf.Min(_escudoActual, dano);
        _escudoActual -= absorbido;
        dano -= absorbido;

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

    public void RestaurarEscudo(int cantidad)
    {
        _escudoActual = Mathf.Min(_escudoActual + cantidad, _escudoMaximo);
        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        Debug.Log("Vida: " + _puntosVidaActuales + " | Escudo: " + _escudoActual);

        if (_barraEscudo != null)
        {
            _barraEscudo.fillAmount = (float)_escudoActual / _escudoMaximo;
        }

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