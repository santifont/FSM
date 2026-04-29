using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject jugador;
    private Vector3 difference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        difference = jugador.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            jugador.transform.position.x, 20,
            (jugador.transform.position.z - 10));

        if (jugador.transform.position.z < -24)
        {
            transform.position = new Vector3(
            jugador.transform.position.x, 20, -34);

            transform.LookAt(jugador.transform);
        }
    }
}
