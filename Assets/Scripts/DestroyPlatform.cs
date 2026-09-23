using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] private GameObject destroy; // Plataforma a destruir
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador DETECTADO");
            destroy.GetComponent<Renderer>().material.color = Color.black; // Cambia el color a negro
            Destroy(gameObject, 1f); // Destruye el objeto despues de 1s
        }
    }
}
