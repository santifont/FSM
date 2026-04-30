using UnityEngine;
using UnityEngine.AI;

public class PistoleroAtacar : PistoleroEstado
{
    private GameObject pistolero;
    public PistoleroAtacar() : base()
    {
        Debug.Log("PISTOLERO ATACANDO");
        nombre = ESTADO.ATACAR;
    }

    public override void Entrar()
    {
        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.red;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
        pistolero = GameObject.Find("Pistolero");
        pistolero.GetComponent<PistoleroIA>().shooting = true;
        pistolero.GetComponent<PistoleroIA>().ActivarDisparos();
    }

    public override void Actualizar()
    {
        agente.GetComponent<NavMeshAgent>().SetDestination(jugador.transform.position);
        agente.GetComponent<Transform>().LookAt(jugador.transform.position);

        if (!JugadorEstaCerca() || pistolero.GetComponent<PistoleroIA>().raycasthit == false)
        {
            pistolero.GetComponent<PistoleroIA>().shooting = false;
            siguienteEstado = new PistoleroVigilar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR;
        }
    }
}
