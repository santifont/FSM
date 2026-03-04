using UnityEngine;
using UnityEngine.AI;

public class Perseguir : Estado
{
    public Perseguir() : base()
    {
        Debug.Log("PERSEGUIR");
        nombre = ESTADO.PERSEGUIR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondriamos la animación de andar, calcular los puntos por los que patrulla, etc...

        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.yellow;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
    }

    public override void Actualizar()
    {
        agente.GetComponent<NavMeshAgent>().SetDestination(jugador.transform.position);

        if (!EstaCercaJugador())
        {
            siguienteEstado = new Vigilar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
        else if (RangoPersecucion())
        {
            siguienteEstado = new Atacar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
    }
}
