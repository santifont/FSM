using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Constructor para VIGILAR
public class Vigilar : Estado
{
    public Vigilar() : base()
    {
        Debug.Log("VIGILAR");
        nombre = ESTADO.VIGILAR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondriamos la animación de andar, calcular los puntos por los que patrulla, etc...

        base.Entrar();
        agente.GetComponent<Renderer>().material.color = Color.green;
        agente.GetComponent<NavMeshAgent>().isStopped = true;
    }

    public override void Actualizar()
    {
        // Le decimos que se vaya moviendo y patrullando...

        if (EstaCercaJugador())
        {
            siguienteEstado = new Perseguir();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
    }

    public override void Salir()
    {
        // Le resetear�amos la animaci�n de andar, o lo que sea...
        base.Salir();
    }

    // Puede el NPC ver el jugador?
    
}

