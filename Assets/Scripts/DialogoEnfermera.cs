using UnityEngine;
using TMPro; // Necesario para textos HD

public class DialogoEnfermera : MonoBehaviour
{
    [Header("Conexiones UI")]
    public GameObject panelDialogo;       // La caja negra
    public TextMeshProUGUI textoPantalla; // El texto de adentro
    public GameObject minijuegoCanvas;    // El panel del minijuego (aguja)

    [Header("Guion")]
    public string[] frases; // Aquí escribiremos el diálogo

    private int indice = 0;
    private bool hablando = false;

    void Update()
    {
        // Si estamos hablando y presionas click o espacio...
        if (hablando && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            SiguienteFrase();
        }
    }

    public void IniciarCharla()
    {
        hablando = true;
        panelDialogo.SetActive(true); // Mostrar caja
        indice = 0;
        textoPantalla.text = frases[indice]; // Mostrar primera frase
    }

    void SiguienteFrase()
    {
        indice++; // Avanzar contador

        if (indice < frases.Length)
        {
            textoPantalla.text = frases[indice]; // Mostrar siguiente frase
        }
        else
        {
            CerrarDialogo(); // Se acabaron las frases
        }
    }

    void CerrarDialogo()
    {
        hablando = false;
        panelDialogo.SetActive(false); // Ocultar caja
        Debug.Log("💉 Fin de la charla. ¡A SUFRIR CON LA AGUJA!");
        minijuegoCanvas.SetActive(true); // <--- AQUÍ ARRANCA EL MINIJUEGO
    }
}