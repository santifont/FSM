using UnityEngine;
using UnityEngine.AI;

public class PistoleroPerseguir : PistoleroEstado
{
    public PistoleroPerseguir() : base()
    {
        Debug.Log("Pistolero Perseguir");
        nombre = ESTADO.PERSEGUIR;
    }

    public override void Entrar()
    {
        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.yellow;
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
