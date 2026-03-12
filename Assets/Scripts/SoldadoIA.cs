using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class SoldadoIA: MonoBehaviour
{
    SoldadoEstado FSM;
    public GameObject jugador;
    public GameObject bala;
    public int fuerzaBala = 5;

    void Start()
    {
        jugador = GameObject.Find("Jugador");
        FSM = new SoldadoVigilar(); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.InicializarFSM(gameObject, jugador);


        StartCoroutine(CorrutinaAtaque());
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }

    public void EmpezarAtaque()
    {
        StartCoroutine(CorrutinaAtaque());
    }

    public void DetenerAtaque()
    {
        StopAllCoroutines();
    }

    private IEnumerator CorrutinaAtaque()
    {
        while (true)
        {
            GameObject balaInstanciada = Instantiate(bala, transform.position, Quaternion.identity);
            balaInstanciada.GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaBala, ForceMode.Impulse);
            Debug.Log(" --------- SOLDADO DISPARANDO ---------");
            yield return new WaitForSeconds(2f);

            //int e = 100 + 100;
        }
    }
}