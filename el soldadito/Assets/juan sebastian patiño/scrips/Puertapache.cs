using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class Puertapache : MonoBehaviour
{
    [SerializeField] private int _monedasNecesarias = 1;
    [SerializeField] private TilemapCollider2D _colisionPuerta;
    [SerializeField] private GameObject _panelVictoria;
    [SerializeField] private GameObject _avisoFaltanMonedas;

    private bool _puertaAbierta;
    private bool _victoriaActivada;
    private Coroutine _corrutinaAviso;

    private void Start()
    {
        _colisionPuerta.isTrigger = false;
    }

    // Cuando la puerta está cerrada
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (_puertaAbierta) return;

        Inventariomonedas inventario =
            colision.collider.GetComponentInParent<Inventariomonedas>();

        if (inventario == null) return;

        if (inventario.Monedas >= _monedasNecesarias)
        {
            AbrirPuerta();
            Ganar();
        }
        else
        {
            MostrarAviso();
        }
    }

    // Cuando la puerta está abierta
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (!_puertaAbierta || _victoriaActivada) return;

        Inventariomonedas inventario =
            colision.GetComponentInParent<Inventariomonedas>();

        if (inventario == null) return;

        if (inventario.Monedas >= _monedasNecesarias)
        {
            Ganar();
        }
    }

    private void AbrirPuerta()
    {
        _puertaAbierta = true;
        _colisionPuerta.isTrigger = true;

        Debug.Log("¡Puerta abierta!");
    }

    private void Ganar()
    {
        if (_victoriaActivada) return;

        _victoriaActivada = true;

        Debug.Log("¡GANASTE!");

        StartCoroutine(MostrarVictoria());
    }

    private IEnumerator MostrarVictoria()
    {
        yield return new WaitForSeconds(2f);

        if (_panelVictoria != null)
            _panelVictoria.SetActive(true);

        Time.timeScale = 0f;
    }

    private void MostrarAviso()
    {
        if (_avisoFaltanMonedas == null) return;

        if (_corrutinaAviso != null)
            StopCoroutine(_corrutinaAviso);

        _avisoFaltanMonedas.SetActive(true);
        _corrutinaAviso = StartCoroutine(OcultarAviso());
    }

    private IEnumerator OcultarAviso()
    {
        yield return new WaitForSecondsRealtime(3f);

        _avisoFaltanMonedas.SetActive(false);
        _corrutinaAviso = null;
    }
}