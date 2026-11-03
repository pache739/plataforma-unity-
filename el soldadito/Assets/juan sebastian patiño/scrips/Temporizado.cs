using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private float _tiempoTotal = 60f;
    [SerializeField] private bool _repetir = true;
    [SerializeField] private Image _imagenReloj;
    [SerializeField] private UnityEvent _alTerminar;

    private Sprite[] _cuadros;
    private float _tiempoRestante;
    private bool _terminado;

    private void Start()
    {
        _cuadros = Resources.LoadAll<Sprite>("Dinamita");
        System.Array.Sort(_cuadros, (a, b) => string.Compare(a.name, b.name));

        _tiempoRestante = _tiempoTotal;
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
            Debug.Log("Se acabó el tiempo");
            _alTerminar.Invoke();

            if (_repetir)
            {
                _tiempoRestante = _tiempoTotal;
            }
            else
            {
                _tiempoRestante = 0f;
                _terminado = true;
            }
        }

        ActualizarImagen();
    }

    private void ActualizarImagen()
    {
        if (_imagenReloj == null || _cuadros.Length == 0)
        {
            return;
        }

        float transcurrido = _tiempoTotal - _tiempoRestante;
        int indice = Mathf.FloorToInt(transcurrido / _tiempoTotal * _cuadros.Length);
        indice = Mathf.Clamp(indice, 0, _cuadros.Length - 1);
        _imagenReloj.sprite = _cuadros[indice];
    }
}