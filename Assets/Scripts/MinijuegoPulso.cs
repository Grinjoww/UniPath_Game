using UnityEngine;
using UnityEngine.UI;

public class MinijuegoPulso : MonoBehaviour
{
    [Header("Arrastra aquí las cosas de la UI")]
    public RectTransform aguja;
    public RectTransform zonaSegura;
    public GameObject panelCompleto; // Aquí arrastraste tu Canvas (o Panel)

    [Header("Configuración")]
    public float velocidad = 500f;
    private bool moviendoDerecha = true;

    // --- LO NUEVO ---
    private int aciertos = 0; // Contador de victorias
    // ----------------

    void Update()
    {
        // (Esta parte del movimiento déjala igual que antes)
        float movimiento = velocidad * Time.deltaTime;
        if (moviendoDerecha)
        {
            aguja.anchoredPosition += new Vector2(movimiento, 0);
            if (aguja.anchoredPosition.x > 220) moviendoDerecha = false;
        }
        else
        {
            aguja.anchoredPosition -= new Vector2(movimiento, 0);
            if (aguja.anchoredPosition.x < -220) moviendoDerecha = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ComprobarAcierto();
        }
    }

    void ComprobarAcierto()
    {
        float distancia = Mathf.Abs(aguja.anchoredPosition.x - zonaSegura.anchoredPosition.x);

        if (distancia < 50)
        {
            // --- LÓGICA DE GANAR ---
            aciertos = aciertos + 1; // Sumamos un punto
            Debug.Log("✅ Acierto: " + aciertos);

            // Mover la zona verde para que sea difícil
            float nuevaX = Random.Range(-200, 200);
            zonaSegura.anchoredPosition = new Vector2(nuevaX, 0);
            velocidad += 200;

            // ¿Ganaste 3 veces?
            if (aciertos >= 3)
            {
                Debug.Log("🏆 ¡PRUEBA SUPERADA!");
                panelCompleto.SetActive(false); // <--- ESTO CIERRA EL JUEGO
                // Aquí podrías sumar puntos o mostrar un mensaje de victoria
            }
            // -----------------------
        }
        else
        {
            Debug.Log("❌ FALLASTE - Reiniciando");
            aciertos = 0; // Si fallas, empiezas de cero (crueldad médica)
            velocidad = 500;
        }
    }
}