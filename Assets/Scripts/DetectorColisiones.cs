using UnityEngine;

public class DetectorColisiones : MonoBehaviour
{
    public SistemaVerguenza sistemaVerguenza; // Arrastrar aquí el Manager

    void OnCollisionEnter(Collision collision)
    {
        // Si lo que toqué tiene la etiqueta "NPC"
        if (collision.gameObject.CompareTag("NPC"))
        {
            sistemaVerguenza.AumentarVerguenza();

            // Opcional: Empujar un poco al jugador hacia atrás (Rebote)
            // GetComponent<Rigidbody>().AddForce(Vector3.back * 200);
        }
    }
}