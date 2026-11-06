using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public void cargarEscena(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }

    public void Pausareljuego()
    {
        Time.timeScale = 0;
    }

    public void reanudareljuego()
    {
        Time.timeScale = 1;
    }
}