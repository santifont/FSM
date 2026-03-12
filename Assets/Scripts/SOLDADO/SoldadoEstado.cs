using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoEstado
{
    protected GameObject agente;
    protected GameObject jugador;

    public void InicializarFSM(GameObject _enemigo, GameObject _jugador)
    {
        // Enlazar bien al GO que gobierna la maquina de estados;
        agente  = _enemigo;
        jugador = _jugador;
    }

        // 'ESTADOS' que tiene el NPC
    public enum ESTADO
    {
        VIGILAR, ATACAR, PERSEGUIR
    };

    // 'EVENTOS' - En que parte nos encontramos del estado
    public enum EVENTO
    {
        ENTRAR, ACTUALIZAR, SALIR
    };

    public    ESTADO nombre; // Para guardar el nombre del estado
    protected EVENTO faseActual; // Para guardar la fase en la que nos encontramos
    protected SoldadoEstado siguienteEstado; // El estado que se EJECUTARÁ A CONTINUACIÓN del estado actual

    // Constructor
    public SoldadoEstado()
    {

    }

    // Las fases de cada estado
    public virtual void Entrar()     { faseActual = EVENTO.ACTUALIZAR; } // La primera fase que se ejecuta cuando cambiamos de estado. El siguiente estado debería ser "actualizar".
    public virtual void Actualizar() { faseActual = EVENTO.ACTUALIZAR; } // Una vez estas en ACTUALIZAR, te quedas en ACTUALIZAR hasta que quieras cambiar de estado.
    public virtual void Salir()      { faseActual = EVENTO.SALIR; } // La fase de SALIR es la última antes de cambiar de ESTADO, aquí deberiamos limpiar lo que haga falta.

    // Este es la función a la que llamaremos para que el NPC inicie la máquina de estados. Vincula los EVENTOS con las funciones que ejecuta cada uno
    public SoldadoEstado Procesar()
    {
        if (faseActual == EVENTO.ENTRAR) Entrar();
        if (faseActual == EVENTO.ACTUALIZAR) Actualizar();
        if (faseActual == EVENTO.SALIR)
        {
            Salir();
            return siguienteEstado; // IMPORTANTE: Aquí hacemos el cambio de estado.
        }
        return this; // Si no salimos por el return de arriba, seguimos en el mismo estado.
    }
    protected bool EstaCercaJugador()
    {
        Vector3 posJugador = GameObject.Find("Jugador").transform.position;
        Vector3 posEnemigo = agente.transform.position;
        float distancia = Vector3.Distance(posJugador, posEnemigo);
        int distanciaINT = Mathf.FloorToInt(distancia);
        //Debug.Log(distanciaINT + " metros");

        if (distancia < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
        // ...        
        //return false; // DE MOMENTO NO
    }

    protected bool RangoPersecucion()
    {
        Vector3 posJugador = GameObject.Find("Jugador").transform.position;
        Vector3 posEnemigo = agente.transform.position;
        float distancia = Vector3.Distance(posJugador, posEnemigo);
        int distanciaINT = Mathf.FloorToInt(distancia);

        if (distancia < 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

