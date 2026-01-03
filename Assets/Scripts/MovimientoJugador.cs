using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 5f;
    public float velocidadRotacion = 10f; // <--- NUEVO: Para que gire suave
    public Animator animadorJaime;

    [Header("Sistema de Vergüenza")]
    public Slider barraVerguenza;
    public GameObject panelDerrota;
    public float velocidadVerguenza = 20f;
    private float verguenzaActual = 0f;
    private bool estoyChocando = false;

    Rigidbody rb;
    Transform camaraTransform; // <--- NUEVO: Referencia a la cámara

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();

        // Buscamos la cámara principal automáticamente
        if (Camera.main != null) camaraTransform = Camera.main.transform;

        if (barraVerguenza != null) barraVerguenza.value = 0;
        if (panelDerrota != null) panelDerrota.SetActive(false);
    }

    void Update()
    {
        // --- 1. MOVIMIENTO INTELIGENTE (Respecto a la cámara) ---
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculamos la dirección basándonos en hacia dónde mira la cámara
        Vector3 camForward = camaraTransform.forward;
        Vector3 camRight = camaraTransform.right;

        // Anulamos la "Y" para que no intente volar ni meterse bajo tierra
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Creamos el vector de movimiento final
        Vector3 movimiento = (camForward * vertical) + (camRight * horizontal);

        // --- ANIMACIÓN Y ROTACIÓN ---
        if (animadorJaime != null)
        {
            bool seMueve = movimiento.magnitude > 0;
            animadorJaime.SetBool("caminando", seMueve);
        }

        // Si nos estamos moviendo, giramos al personaje para que mire a esa dirección
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }

        // Movemos el cuerpo
        Vector3 nuevaPosicion = transform.position + (movimiento * velocidad * Time.deltaTime);
        rb.MovePosition(nuevaPosicion);

        // --- 2. LÓGICA DE VERGÜENZA (Igual que antes) ---
        if (estoyChocando == true)
        {
            verguenzaActual += velocidadVerguenza * Time.deltaTime;
            if (barraVerguenza != null) barraVerguenza.value = verguenzaActual;

            if (verguenzaActual >= 100)
            {
                if (panelDerrota != null)
                {
                    panelDerrota.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Plane" && collision.gameObject.name != "Suelo")
        {
            estoyChocando = true;
            if (animadorJaime != null) animadorJaime.SetBool("verguenza", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        estoyChocando = false;
        if (animadorJaime != null) animadorJaime.SetBool("verguenza", false);
    }

    public void Calmarse()
    {
        verguenzaActual = 0f;
        if (barraVerguenza != null) barraVerguenza.value = 0;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}