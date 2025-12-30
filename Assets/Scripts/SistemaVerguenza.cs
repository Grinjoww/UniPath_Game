using UnityEngine;
using UnityEngine.UI;

public class SistemaVerguenza : MonoBehaviour
{
    [Header("UI")]
    public Image barraRelleno;

    [Header("Configuración")]
    public float verguenzaActual = 0;
    public float verguenzaMaxima = 100;
    public float subidaPorChoque = 10f; // Cuánto sube al chocar
    public float bajadaPorTiempo = 2f;  // Se calma si no choca (opcional)

    private bool zaidaEncontrada = false; // Para saber si Zaida ya nos ayudó

    void Update()
    {
        // Opcional: La vergüenza baja lento si no pasa nada (para que no sea imposible)
        if (verguenzaActual > 0)
        {
            barraRelleno.fillAmount = verguenzaActual / verguenzaMaxima;
        }
        ActualizarBarra();
    }

    // Esta función la llamará el Jugador cuando choque
    public void AumentarVerguenza()
    {
        if (zaidaEncontrada) return; // Si estás con Zaida, eres inmune (Modo Fácil)

        verguenzaActual += subidaPorChoque;
        Debug.Log("😳 ¡QUÉ VERGÜENZA! Chocaste a alguien.");

        if (verguenzaActual >= verguenzaMaxima)
        {
            verguenzaActual = verguenzaMaxima;
            Debug.Log("💀 GAME OVER SOCIAL - Te escondiste en el baño.");
            // Aquí luego reiniciamos el nivel
        }
        ActualizarBarra();
    }

    public void ActivarModoZaida()
    {
        zaidaEncontrada = true;
        verguenzaActual = 0; // Se te quita la vergüenza
        Debug.Log("✨ Zaida te ayuda. Ya no sube la vergüenza.");
    }

    void ActualizarBarra()
    {
        barraRelleno.fillAmount = verguenzaActual / verguenzaMaxima;
    }
}