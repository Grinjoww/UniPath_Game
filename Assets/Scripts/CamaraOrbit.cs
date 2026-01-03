using UnityEngine;

public class CamaraOrbit : MonoBehaviour
{
    public Transform objetivo; // A quién perseguimos (Jaime)
    public float distancia = 5.0f; // Qué tan lejos está la cámara
    public float sensibilidad = 2.0f; // Qué tan rápido gira el mouse

    private float rotacionX = 0.0f;
    private float rotacionY = 0.0f;

    void Start()
    {
        // Opcional: Bloquea el cursor en el centro de la pantalla para que no moleste
        // Cursor.lockState = CursorLockMode.Locked; 

        // Guardamos la rotación inicial
        Vector3 rot = transform.localEulerAngles;
        rotacionX = rot.x;
        rotacionY = rot.y;
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Leemos el movimiento del mouse
            rotacionX += Input.GetAxis("Mouse X") * sensibilidad;
            rotacionY -= Input.GetAxis("Mouse Y") * sensibilidad;

            // Limitamos que no pueda dar vueltas locas de arriba a abajo
            rotacionY = Mathf.Clamp(rotacionY, -10f, 60f);

            // Calculamos la rotación y posición
            Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0);
            Vector3 posicion = rotacion * new Vector3(0.0f, 0.0f, -distancia) + objetivo.position;

            // Aplicamos los cambios a la cámara
            transform.rotation = rotacion;
            transform.position = posicion;
        }
    }
}