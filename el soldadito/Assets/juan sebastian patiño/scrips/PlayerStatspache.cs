using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private int _vidaActual;
    [SerializeField] private UIManager _uiManager;

    private EscudoJugador _escudo;
    private bool _muerto;

    private void Start()
    {
        _vidaActual = _vidaMaxima;
        _escudo = GetComponent<EscudoJugador>();

        ActualizarVida();
    }

    public void RestarVida(int dano)
    {
        if (_muerto) return;

        if (_escudo != null)
        {
            dano = _escudo.AbsorberDano(dano);
        }

        _vidaActual -= dano;
        _vidaActual = Mathf.Max(0, _vidaActual);

        ActualizarVida();

        if (_vidaActual == 0)
        {
            Morir();
        }
    }

    public void SumarVida(int cura)
    {
        if (_muerto) return;

        _vidaActual += cura;
        _vidaActual = Mathf.Min(_vidaActual, _vidaMaxima);

        ActualizarVida();
    }

    private void ActualizarVida()
    {
        if (_uiManager != null)
        {
            _uiManager.ActualizarBarraVida(
                (float)_vidaActual / _vidaMaxima
            );
        }
    }

    public void Morir()
    {
        if (_muerto) return;

        _muerto = true;

        Debug.Log("El jugador ha muerto");

        if (_uiManager != null)
        {
            _uiManager.MostrarPanelPerdiste();
        }

        Destroy(gameObject);
    }
}