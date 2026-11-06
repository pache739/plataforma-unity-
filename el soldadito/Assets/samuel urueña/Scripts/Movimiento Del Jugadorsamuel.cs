using UnityEngine;

public class MovimientoJugadoruru : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _velocidadMaxima = 5f;

    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private DetectorSueloUru DetectorSuelouru;

    [SerializeField] private float _multiplicadorCaida = 3f;
    [SerializeField] private float _multiplicadorSaltoCorto = 2f;

    private Animator _animador;
    private SpriteRenderer _sprite;

    private bool _quiereSaltar;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (DetectorSuelouru != null &&
            Input.GetKeyDown(KeyCode.W) &&
            DetectorSuelouru.estaEnSuelo)
        {
            _quiereSaltar = true;
        }

        bool caminando =
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D);

        if (_animador != null)
        {
            _animador.SetBool("caminando", caminando);
        }

        if (_sprite != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _sprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _sprite.flipX = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_cuerpoRigido2D == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _cuerpoRigido2D.AddForce(Vector2.right * _force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _cuerpoRigido2D.AddForce(Vector2.left * _force);
        }

        if (!Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.D) &&
            DetectorSuelouru != null &&
            DetectorSuelouru.estaEnSuelo)
        {
            _cuerpoRigido2D.linearVelocity = new Vector2(
                0,
                _cuerpoRigido2D.linearVelocity.y
            );
        }

        if (_quiereSaltar)
        {
            if (DetectorSuelouru != null &&
                DetectorSuelouru.estaEnSuelo)
            {
                _cuerpoRigido2D.AddForce(
                    Vector2.up * _fuerzaSalto,
                    ForceMode2D.Impulse
                );
            }

            _quiereSaltar = false;
        }

        if (_cuerpoRigido2D.linearVelocity.y < 0)
        {
            _cuerpoRigido2D.linearVelocity +=
                Vector2.up *
                Physics2D.gravity.y *
                (_multiplicadorCaida - 1f) *
                Time.fixedDeltaTime;
        }
        else if (_cuerpoRigido2D.linearVelocity.y > 0 &&
                 !Input.GetKey(KeyCode.W))
        {
            _cuerpoRigido2D.linearVelocity +=
                Vector2.up *
                Physics2D.gravity.y *
                (_multiplicadorSaltoCorto - 1f) *
                Time.fixedDeltaTime;
        }

        float velocidadX = Mathf.Clamp(
            _cuerpoRigido2D.linearVelocity.x,
            -_velocidadMaxima,
            _velocidadMaxima
        );

        _cuerpoRigido2D.linearVelocity = new Vector2(
            velocidadX,
            _cuerpoRigido2D.linearVelocity.y
        );
    }
}