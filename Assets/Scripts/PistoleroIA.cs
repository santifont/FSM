using System.Collections;
using UnityEngine;

public class PistoleroIA : MonoBehaviour
{
    PistoleroEstado FSM;
    public GameObject jugador;
    public GameObject bala;
    public float fuerzaBala = 100;
    public bool shooting = false;
    public bool raycasthit = false;
    public float range = 20f;
    private Vector3 direction = Vector3.forward;

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

        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                raycasthit = true;
            }
            else if (hit.collider.tag == "Wall")
            {
                raycasthit = false;
            }
        }
    }

    public void ActivarDisparos()
    {
        StartCoroutine(DispararCadaCincoSegundos());
    }

    private IEnumerator DispararCadaCincoSegundos()
    {
        while (shooting == true)
        {
            Vector3 balaspawn = transform.position + transform.forward * (1.5f);
            //GameObject balaInstanciada = Instantiate(bala, transform.position, Quaternion.identity);
            GameObject balaInstanciada = Instantiate(bala, balaspawn, Quaternion.identity);
            balaInstanciada.GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaBala, ForceMode.Impulse);
            Debug.Log(" --------- PISTOLEROS DISPARANDO ---------");
            yield return new WaitForSeconds(5f);
        }
    }
}
