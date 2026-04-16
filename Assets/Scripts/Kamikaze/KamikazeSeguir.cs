using UnityEngine;
using UnityEngine.AI;

public class KamikazeSeguir : KamikazeEstado
{
    public KamikazeSeguir() : base()
    {
        Debug.Log("KAMIKAZE SEGUIR");
        nombre = ESTADO.SEGUIR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondriamos la animación de andar, calcular los puntos por los que patrulla, etc...
        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.darkGreen;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
    }

    public override void Actualizar()
    {

        // TODO EL RATO SIGUIENDO AL JUGAR

        agente.GetComponent<NavMeshAgent>().SetDestination(jugador.transform.position);
        agente.GetComponent<Transform>().LookAt(jugador.transform.position);
        
        /*
        if (!EstaCercaJugador())
        {
            siguienteEstado = new KamikazeEsperar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
        else if (RangoPersecucion())
        {
            siguienteEstado = new KamikazeEsperar();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
        */
    }




}
