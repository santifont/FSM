//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeDisparar : KamikazeEstado
{
    public KamikazeDisparar() : base()
    {
        Debug.Log("Kamikaze Disparar");
        nombre = ESTADO.ATACAR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondríamos la animación de disparar, o lo que sea...
        base.Entrar();

        agente.GetComponent<Renderer>().material.color = Color.black;
        agente.GetComponent<NavMeshAgent>().isStopped = false;
        agente.GetComponent<KamikazeIA>().disparo = true;
        agente.GetComponent<NavMeshAgent>().stoppingDistance = 0;
        agente.GetComponent<Transform>().localScale = agente.GetComponent<Transform>().localScale / 2;
        
    }

    public override void Actualizar()
    {
        /*
        if (!RangoPersecucion())
        {
            siguienteEstado = new KamikazeSeguir();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
        */

       agente.GetComponent<NavMeshAgent>().SetDestination(agente.GetComponent<KamikazeIA>().enemigoCercano.transform.position);
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de disparar, o lo que sea...
        base.Salir();
        agente.GetComponent<KamikazeIA>().DetenerAtaque();
    }

    public bool PuedeAtacar()
    {
        // ...
        return false; // El NPC NO ESTÁ lo suficientemente cerca para atacar al jugador.
    }
}
