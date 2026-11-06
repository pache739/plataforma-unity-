using UnityEngine;

public class PlaylistManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    [Header("Lista de canciones")]
    public AudioClip[] canciones; // Arrastra tus canciones aquí en el Inspector
    private int indiceActual = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (canciones.Length > 0)
        {
            ReproducirCancion(indiceActual);
        }
    }

    void Update()
    {
        // Si el AudioSource ya no está reproduciendo nada y hay canciones cargadas
        if (!audioSource.isPlaying && canciones.Length > 0)
        {
            // Pasa a la siguiente canción en bucle (vuelve a la primera al terminar la última)
            indiceActual = (indiceActual + 1) % canciones.Length;
            ReproducirCancion(indiceActual);
        }
    }

    void ReproducirCancion(int indice)
    {
        audioSource.clip = canciones[indice];
        audioSource.Play();
    }
}