using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _velocidadMovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private float _force = 10f;
    [SerializeField] private DetectorSuelo _detectorSuelo;

    private Animator _animador;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _cuerpoRigido2D.AddForce(Vector2.right * _force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _cuerpoRigido2D.AddForce(Vector2.left * _force);
        }

        bool caminando = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        _animador.SetBool("caminando", caminando);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("PRESIONÉ W");
            Debug.Log("¿Estoy en el suelo?: " + _detectorSuelo.estaEnSuelo);

            if (_detectorSuelo.estaEnSuelo)
            {
                Debug.Log("VOY A SALTAR");

                _cuerpoRigido2D.AddForce(
                    Vector2.up * _force,
                    ForceMode2D.Impulse
                );
            }
        }
    }
}
