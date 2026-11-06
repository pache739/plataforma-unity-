using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
  
    public void CargarEscena(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void pausareljuego()
    {
        Time.timeScale = 0;
    }

    public void Reanudareljuego()
    {
        Time.timeScale = 1;
    }

}