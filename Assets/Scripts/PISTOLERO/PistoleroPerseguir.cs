using UnityEngine;
using UnityEngine.AI;

public class PistoleroPerseguir : PistoleroEstado
{
    private GameObject pistolero;
    public PistoleroPerseguir() : base()
    {
        Debug.Log("PISTOLERO PERSIGUIENDO");
        nombre = ESTADO.PERSEGUIR;
    }

    public override void Entrar()
    {
        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.yellow;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
        pistolero = GameObject.Find("Pistolero");
    }

    public override void Actualizar()
    {
        agente.GetComponent<NavMeshAgent>().SetDestination(jugador.transform.position);
        agente.GetComponent<Transform>().LookAt(jugador.transform.position);

        if (!JugadorEstaCerca())
        {
            siguienteEstado = new PistoleroVigilar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR;
        }

        if (pistolero.GetComponent<PistoleroIA>().raycasthit)
        {
            siguienteEstado = new PistoleroAtacar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR;
        }
    }
}
