using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _velocidadMovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private float _force = 10f;
    [SerializeField] private DetectorSuelo _detectorSuelo;
    [SerializeField] private SpriteRenderer _reflect;

    private Animator _animador;
    private float _movimientoHorizontal;
    private bool _saltar;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
    }

    private void Update()
    {
        _movimientoHorizontal = 0f;

        if (Input.GetKey(KeyCode.D))
            _movimientoHorizontal = 1f;

        if (Input.GetKey(KeyCode.A))
            _movimientoHorizontal = -1f;

        bool caminando = _movimientoHorizontal != 0f;
        _animador.SetBool("caminando", caminando);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("PRESIONÉ W");
            Debug.Log("¿Estoy en el suelo?: " + _detectorSuelo.estaEnSuelo);

            if (_detectorSuelo.estaEnSuelo)
                _saltar = true;
        }
    }

    private void FixedUpdate()
    {
        _cuerpoRigido2D.linearVelocity = new Vector2(
            _movimientoHorizontal * _velocidadMovimiento,
            _cuerpoRigido2D.linearVelocity.y
        );

        if (_saltar)
        {
            _cuerpoRigido2D.AddForce(
                Vector2.up * _force,
                ForceMode2D.Impulse
            );

            _saltar = false;
        }
    }
}