
using UnityEngine;

public class EscudoJugador : MonoBehaviour
{
    private int escudoMaximo = 50;
    private int escudoActual;

    private void Start()
    {
        escudoActual = escudoMaximo;
    }

    public int AbsorberDano(int dano)
    {
        int danoAbsorbido = Mathf.Min(escudoActual, dano);

        escudoActual -= danoAbsorbido;

        dano -= danoAbsorbido;

        Debug.Log("Escudo: " + escudoActual);

        return dano;
    }

    public void RestaurarEscudo(int cantidad)
    {
        escudoActual += cantidad;

        if (escudoActual > escudoMaximo)
        {
            escudoActual = escudoMaximo;
        }

        Debug.Log("Escudo: " + escudoActual);
    }
}
