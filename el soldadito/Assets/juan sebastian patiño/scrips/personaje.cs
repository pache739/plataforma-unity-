using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _velocidadMovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private float _force = 10f;
    private Animator _animador;

    private bool _puedeSaltar = true;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
        _animador = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) //derecha
        {
            _cuerpoRigido2D.AddForce(Vector2.right * _force);
        }

        if (Input.GetKey(KeyCode.A)) //izquierda
        {
            _cuerpoRigido2D.AddForce(Vector2.left * _force);
        }

        bool caminando = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        _animador.SetBool("caminando", caminando);

        if (Input.GetKeyDown(KeyCode.W) && _puedeSaltar) //arriba
        {
            _cuerpoRigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);

            _puedeSaltar = false;
        }

    }


}

