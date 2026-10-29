using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private float _tiempoTotal = 60f;
    [SerializeField] private TextMeshProUGUI _texto;
    [SerializeField] private UnityEvent _alTerminar;

    private float _tiempoRestante;
    private bool _terminado;

    private void Start()
    {
        _tiempoRestante = _tiempoTotal;
        ActualizarTexto();
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
            ActualizarTexto();
            Debug.Log("Se acabó el tiempo");
            _alTerminar.Invoke();
            return;
        }

        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (_texto == null)
        {
            return;
        }

        int total = Mathf.CeilToInt(_tiempoRestante);
        int minutos = total / 60;
        int segundos = total % 60;
        _texto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}