using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SoldadoDisparar : SoldadoEstado
{
    public SoldadoDisparar() : base()
    {
        Debug.Log("DISPARAR");
        nombre = ESTADO.ATACAR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondríamos la animación de disparar, o lo que sea...
        base.Entrar();

        agente.GetComponent<Renderer>().material.color = Color.red;
        agente.GetComponent<NavMeshAgent>().isStopped = true;
        agente.GetComponent<SoldadoIA>().EmpezarAtaque();
    }

    public override void Actualizar()
    {
        agente.GetComponent<Transform>().LookAt(jugador.transform.position);
        if (!RangoPersecucion())
        {
            siguienteEstado = new SoldadoPerseguir();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de disparar, o lo que sea...
        base.Salir();
        agente.GetComponent<SoldadoIA>().DetenerAtaque();
    }

    public bool PuedeAtacar()
    {
        // ...
        return false; // El NPC NO ESTÁ lo suficientemente cerca para atacar al jugador.
    }
}