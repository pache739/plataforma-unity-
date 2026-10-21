using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _velocidadMaxima = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] public DetectorSuelo detectorSuelo;

    private Animator _animador;
    private bool _quiereSaltar;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
    }

    private void Update()
    {
        // Salto: la tecla se lee aqui para que no se pierda
        if (Input.GetKeyDown(KeyCode.W) && detectorSuelo.estaEnSuelo)
        {
            _quiereSaltar = true;
        }

        // Animacion
        bool caminando = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        _animador.SetBool("caminando", caminando);
    }

    private void FixedUpdate()
    {
        // Derecha
        if (Input.GetKey(KeyCode.D))
        {
            _cuerpoRigido2D.AddForce(Vector2.right * _force);
        }

        // Izquierda
        if (Input.GetKey(KeyCode.A))
        {
            _cuerpoRigido2D.AddForce(Vector2.left * _force);
        }

        // Salto
        if (_quiereSaltar)
        {
            _cuerpoRigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);
            _quiereSaltar = false;
        }

        // Limitar la velocidad horizontal
        float velocidadX = Mathf.Clamp(_cuerpoRigido2D.linearVelocity.x, -_velocidadMaxima, _velocidadMaxima);
        _cuerpoRigido2D.linearVelocity = new Vector2(velocidadX, _cuerpoRigido2D.linearVelocity.y);
    }
}