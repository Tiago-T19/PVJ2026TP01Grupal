using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed; // Velocidad en la que se mueve el jugador
    [SerializeField] private float runSpeed; // Velocidad para correr
    private Vector3 dir = Vector3.zero; // Direccion empieza en 0

    [Header("Salto")]
    private Rigidbody rb; // Rigidbody
    [SerializeField] private float jumpForce; // Fuerza de salto

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Busca en componente
    }

    void Update()
    {
        // MOVIMIENTO
        // Entradas
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Direccion
        dir = new Vector3(h, 0, v);

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; // Si aprieta shift corre, si no camina

        Vector3 mover = dir.normalized * speed * Time.deltaTime;
        transform.Translate(mover, Space.Self); // Se mueve con el eje local (Space.Self)

        // SALTO
        if (Input.GetKeyDown(KeyCode.Space)) //Al precionar espacio
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Toma impulso hacia arriba
        }
    }
}
