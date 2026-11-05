using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [Header("Tiempo de partida")]
    [SerializeField] private float _tiempoTotal = 600f;

    [Header("Reloj visual")]
    [SerializeField] private float _duracionVuelta = 60f;
    [SerializeField] private Image _imagenReloj;

    [Header("UI Manager")]
    [SerializeField] private UIManager _uiManager;

    private Sprite[] _cuadros;
    private float _tiempoRestante;
    private bool _terminado;

    private void Start()
    {
        _cuadros = Resources.LoadAll<Sprite>("Dinamita");

        System.Array.Sort(
            _cuadros,
            (a, b) => string.Compare(a.name, b.name)
        );

        _tiempoRestante = _tiempoTotal;

        Debug.Log("Temporizador iniciado: " + _tiempoTotal + " segundos");

        ActualizarImagen();
    }

    private void Update()
    {
        if (_terminado)
        {
            return;
        }

        _tiempoRestante -= Time.deltaTime;

        if (_tiempoRestante <= 0f)
        {
            _tiempoRestante = 0f;
            _terminado = true;

            Debug.Log("¡SE ACABÓ EL TIEMPO!");

            if (_uiManager != null)
            {
                _uiManager.MostrarPanelPerdiste();
            }
            else
            {
                Debug.LogError("No has asignado el UIManager al Temporizador");
            }

            ActualizarImagen();

            return;
        }

        ActualizarImagen();
    }

    private void ActualizarImagen()
    {
        if (_imagenReloj == null ||
            _cuadros == null ||
            _cuadros.Length == 0)
        {
            return;
        }

        float tiempoTranscurrido = _tiempoTotal - _tiempoRestante;

        float tiempoEnVuelta = tiempoTranscurrido % _duracionVuelta;

        int indice = Mathf.FloorToInt(
            (tiempoEnVuelta / _duracionVuelta) * _cuadros.Length
        );

        indice = Mathf.Clamp(indice, 0, _cuadros.Length - 1);

        _imagenReloj.sprite = _cuadros[indice];
    }
}