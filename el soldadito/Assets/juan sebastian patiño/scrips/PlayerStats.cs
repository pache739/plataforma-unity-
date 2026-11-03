using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private int _vidaActual;
    [SerializeField] private UIManager _uiManager;

    private EscudoJugador _escudo;

    private void Start()
    {
        _vidaActual = _vidaMaxima;
        _escudo = GetComponent<EscudoJugador>();

        ActualizarVida();
    }

    public void RestarVida(int dano)
    {
        if (_escudo != null)
        {
            dano = _escudo.AbsorberDano(dano);
        }

        _vidaActual -= dano;

        if (_vidaActual < 0)
        {
            _vidaActual = 0;
        }

        ActualizarVida();

        Debug.Log("Vida: " + _vidaActual);

        if (_vidaActual == 0)
        {
            Morir();
        }
    }

    public void SumarVida(int cura)
    {
        _vidaActual += cura;

        if (_vidaActual > _vidaMaxima)
        {
            _vidaActual = _vidaMaxima;
        }

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
        Debug.Log("El jugador ha muerto");
        Destroy(gameObject);
    }
}