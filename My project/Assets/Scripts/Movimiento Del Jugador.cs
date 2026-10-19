using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _velocidadMaxima = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] public DetectorSuelo detectorSuelo;
    private Animator _animador;


    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
    }

    private void Update()
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

        bool caminando = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        _animador.SetBool("caminando", caminando);

        // Salto
        
       if (Input.GetKeyDown(KeyCode.W) && detectorSuelo.estaEnSuelo)
      
      {
        _cuerpoRigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);
      }

        
    }

    
}