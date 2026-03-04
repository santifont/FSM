using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class EnemigoIA: MonoBehaviour
{
    Estado FSM;
    public GameObject jugador;

    void Start()
    {
        jugador = GameObject.Find("Jugador");
        FSM = new Vigilar(); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.InicializarFSM(gameObject, jugador);
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
}