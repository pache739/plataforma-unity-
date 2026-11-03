using UnityEngine;

public class EscudoJugador : MonoBehaviour
{
    [SerializeField] private int _escudoMaximo = 50;
    [SerializeField] private int _escudoActual;
    [SerializeField] private UIManagerEscudo _uiManagerEscudo;

    private void Start()
    {
        _escudoActual = _escudoMaximo;
        ActualizarBarraEscudo();
    }

    public int AbsorberDano(int dano)
    {
        int absorbido = Mathf.Min(_escudoActual, dano);

        _escudoActual -= absorbido;
        dano -= absorbido;

        ActualizarBarraEscudo();

        Debug.Log("Escudo: " + _escudoActual);

        return dano;
    }

    public void RestaurarEscudo(int cantidad)
    {
        _escudoActual += cantidad;

        if (_escudoActual > _escudoMaximo)
        {
            _escudoActual = _escudoMaximo;
        }

        ActualizarBarraEscudo();

        Debug.Log("Escudo: " + _escudoActual);
    }

    private void ActualizarBarraEscudo()
    {
        if (_uiManagerEscudo != null && _escudoMaximo > 0)
        {
            _uiManagerEscudo.ActualizarBarraEscudo(
                (float)_escudoActual / _escudoMaximo
            );
        }
    }
}