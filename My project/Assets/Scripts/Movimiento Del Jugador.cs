using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _velocidadMaxima = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] public DetectorSuelo detectorSuelo;
    [SerializeField] private float _multiplicadorCaida = 3f;

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

       // Frenar al soltar A y D (solo en el suelo)
       if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && detectorSuelo.estaEnSuelo)
    {
           _cuerpoRigido2D.linearVelocity = new Vector2(0, _cuerpoRigido2D.linearVelocity.y);
    }

        // Salto
        if (_quiereSaltar)
    {
        if (detectorSuelo.estaEnSuelo)
    {
        _cuerpoRigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);
    }
        _quiereSaltar = false;
}

        if (_cuerpoRigido2D.linearVelocity.y < 0)
        
        {
            _cuerpoRigido2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (_multiplicadorCaida - 1f) * Time.fixedDeltaTime;
        }

        // Limitar la velocidad horizontal
        float velocidadX = Mathf.Clamp(_cuerpoRigido2D.linearVelocity.x, -_velocidadMaxima, _velocidadMaxima);
        _cuerpoRigido2D.linearVelocity = new Vector2(velocidadX, _cuerpoRigido2D.linearVelocity.y);
    }
}