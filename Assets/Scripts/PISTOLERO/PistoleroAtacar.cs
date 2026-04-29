using UnityEngine;
using UnityEngine.AI;

public class PistoleroAtacar : PistoleroEstado
{
    public PistoleroAtacar() : base()
    {
        Debug.Log("Pistolero Atacar");
        nombre = ESTADO.ATACAR;
    }

    public override void Entrar()
    {
        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.red;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
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

    }
}
