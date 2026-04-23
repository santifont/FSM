using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeIA : MonoBehaviour
{
    KamikazeEstado FSM;
    public GameObject jugador;
    public GameObject bala;
    public int fuerzaBala = 1000;
    public bool disparo = false;
    public GameObject enemigoCercano;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        FSM = new KamikazeEsperar(); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.InicializarFSM(gameObject, jugador);

    }
       

    // Update is called once per frame
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
            Debug.Log(" --------- KAMIKAZE DISPARANDO ---------");
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER: " + other.gameObject.name);
       if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
