using UnityEngine;

public class PistoleroIA : MonoBehaviour
{
    PistoleroEstado FSM;
    public GameObject jugador;
    public GameObject bala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        FSM = new PistoleroVigilar(); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.InicializarFSM(gameObject, jugador);
    }

    // Update is called once per frame
    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
}
