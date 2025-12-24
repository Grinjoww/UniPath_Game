using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Buscamos el componente físico automáticamente
    }

    void Update()
    {
        // Leemos las teclas (WASD o Flechas)
        float horizontal = Input.GetAxis("Horizontal"); // A - D
        float vertical = Input.GetAxis("Vertical");     // W - S

        // Creamos el vector de movimiento
        Vector3 movimiento = new Vector3(horizontal, 0, vertical);

        // Movemos el personaje
        // Usamos MovePosition para respetar la física
        Vector3 nuevaPosicion = transform.position + (movimiento * velocidad * Time.deltaTime);
        rb.MovePosition(nuevaPosicion);
    }
}
