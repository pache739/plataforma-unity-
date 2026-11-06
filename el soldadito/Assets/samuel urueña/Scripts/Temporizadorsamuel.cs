using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class temporizador : MonoBehaviour
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

        Array.Sort(_cuadros, (a, b) =>
            string.Compare(a.name, b.name, StringComparison.Ordinal));

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

            if (_alTerminar != null)
            {
                _alTerminar.Invoke();
            }

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
        if (_imagenReloj == null ||
            _cuadros == null ||
            _cuadros.Length == 0)
        {
            return;
        }

        if (_tiempoTotal <= 0f)
        {
            return;
        }

        float transcurrido = _tiempoTotal - _tiempoRestante;

        int indice = Mathf.FloorToInt(
            transcurrido / _tiempoTotal * _cuadros.Length
        );

        indice = Mathf.Clamp(indice, 0, _cuadros.Length - 1);

        _imagenReloj.sprite = _cuadros[indice];
    }
}