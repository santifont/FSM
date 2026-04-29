using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(jugador.position);
    }
}
