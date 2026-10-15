using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _velocidadMovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private float _force = 10f;

    private bool _puedeSaltar = true;

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.W) && _puedeSaltar)
        {
            _cuerpoRigido2D.AddForce(
                Vector2.up * _fuerzaSalto,
                ForceMode2D.Impulse
            );

            _puedeSaltar = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            _puedeSaltar = true;
        }
    }

}

