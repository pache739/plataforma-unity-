using UnityEngine;

public class ObstaculoMortal : MonoBehaviour
{
        [SerializeField] private UIManager _uiManager;
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            _uiManager.RestarFillAmount(0.1f);
        }
    }
}
