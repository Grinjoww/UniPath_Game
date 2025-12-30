using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Transform objetivo; // Aquí pondremos al Player
    private Vector3 distancia; // La separación entre cámara y jugador

    void Start()
    {
        // Al darle Play, calculamos la distancia que pusiste en el Paso 1
        distancia = transform.position - objetivo.position;
    }

    void LateUpdate()
    {
        // Movemos la cámara a la posición del jugador + la distancia original
        transform.position = objetivo.position + distancia;
    }
}