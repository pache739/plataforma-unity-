
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Temporizador : MonoBehaviour
{
    [Header("Tiempo de partida")]
    [SerializeField] private float _tiempoTotal = 600f;

    [Header("Reloj visual")]
    [SerializeField] private float _duracionVuelta = 60f;
    [SerializeField] private Image _imagenReloj;

    [Header("Al terminar")]
    [SerializeField] private UnityEvent _alTerminar;

    private Sprite[] _cuadros;
    private float _tiempoRestante;
    private bool _terminado = false;

    private void Start()
    {
        _cuadros = Resources.LoadAll<Sprite>("Dinamita");

        System.Array.Sort(_cuadros,
            (a, b) => string.Compare(a.name, b.name));

        // Iniciar los 10 minutos
        _tiempoRestante = _tiempoTotal;

        Debug.Log("Partida iniciada. Tiempo: " + _tiempoRestante);

        ActualizarImagen();
    }

    private void Update()
    {
        if (_terminado)
            return;

        // Descontar el tiempo real de la partida
        _tiempoRestante -= Time.deltaTime;

        // Comprobar si terminaron los 10 minutos
        if (_tiempoRestante <= 0f)
        {
            _tiempoRestante = 0f;
            _terminado = true;

            Debug.Log("¡SE ACABARON LOS 10 MINUTOS!");

            _alTerminar.Invoke();

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
            return;

        // Tiempo transcurrido desde el inicio
        float transcurrido = _tiempoTotal - _tiempoRestante;

        // Repetir las imágenes cada 60 segundos
        float tiempoVuelta = transcurrido % _duracionVuelta;

        int indice = Mathf.FloorToInt(
            (tiempoVuelta / _duracionVuelta) * _cuadros.Length
        );

        indice = Mathf.Clamp(indice, 0, _cuadros.Length - 1);

        _imagenReloj.sprite = _cuadros[indice];
    }
}