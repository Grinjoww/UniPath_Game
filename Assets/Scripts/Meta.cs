using UnityEngine;

public class Meta : MonoBehaviour
{
    // 1. Creamos un hueco para arrastrar el panel del minijuego
    public GameObject pantallaMinijuego;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🏥 ¡LLEGASTE! Activando examen...");

            // 2. Encendemos el minijuego
            pantallaMinijuego.SetActive(true);

            // Opcional: Pausar el juego de fondo (para que no te muevas mientras juegas)
            // Time.timeScale = 0; 
        }
    }
}