
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int vidaMaxima = 100;
    private int vidaActual;

    public EscudoJugador escudo;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RestarVida(int dano)
    {
        dano = escudo.AbsorberDano(dano);

        vidaActual -= dano;

        if (vidaActual < 0)
        {
            vidaActual = 0;
        }

        Debug.Log("Vida: " + vidaActual);

        if (vidaActual == 0)
        {
            Debug.Log("El jugador ha muerto");
        }
    }

    public void SumarVida(int cura)
    {
        vidaActual += cura;

        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }

        Debug.Log("Vida: " + vidaActual);
    }
}