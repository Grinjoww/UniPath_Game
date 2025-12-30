using UnityEngine;

public class Meta : MonoBehaviour
{
    public DialogoEnfermera scriptCharla; // Conexión con el Manager

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🏥 Llegaste al dispensario.");

            // Llamamos a la función del otro script
            scriptCharla.IniciarCharla();

            // Desactivamos este trigger para que no se repita
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}