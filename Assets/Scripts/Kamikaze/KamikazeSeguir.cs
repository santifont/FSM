using UnityEngine;
using UnityEngine.AI;

public class KamikazeSeguir : KamikazeEstado
{
    private Vector3 posJugador;

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
        enemigoCercano = null;
        distanciaEnemigo = -1;
        agente.GetComponent<Transform>().localScale = agente.GetComponent<Transform>().localScale * 2;
    }

    public override void Actualizar()
    {

        // TODO EL RATO SIGUIENDO AL JUGAR
        posJugador = jugador.transform.position;
        agente.GetComponent<NavMeshAgent>().SetDestination(jugador.transform.position);

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
        */// FUNCION --> COMPROBAR ENEMIGO CERCANO:
          // 1. ACCEDER A GameObject.Finds...
          // 2. RECORRER LA LISTA Y ELEGIR AL ENEMIGO MAS CERCANO
          // 2.1 Comparando la distancia de cada enemigo
          // 2.2 si esta mas cerca, es el nuevo enemigo cercano

        int umbral = 10;
        GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Kamikaze - Actualizar " + listaEnemigos.Length);
        

        if(enemigoCercano != null)
        {
            distanciaEnemigo = Vector3.Distance(posJugador, enemigoCercano.transform.position);
            agente.GetComponent<Transform>().LookAt(enemigoCercano.transform.position);

        }

        for (int i = 0; i < listaEnemigos.Length; i++) // recorrer lista 
        {  // si la distancia del enemigo esta dentro del umbral
            Vector3 posEnemigo = listaEnemigos[i].transform.position;
            float distancia = Vector3.Distance(posJugador, posEnemigo);
            if (distancia < umbral)
            {
                if (enemigoCercano == null)
                {
                    enemigoCercano = listaEnemigos[i];
                    distanciaEnemigo = distancia;
                    Debug.Log("ENEMIGO NULL ESTABLECIDO=" + enemigoCercano.gameObject.name);
                }
                else if (distancia < distanciaEnemigo)
                {
                    enemigoCercano = listaEnemigos[i];
                    distanciaEnemigo = distancia;
                    Debug.Log("ENEMIGO NULL REMPLAZADO=" + enemigoCercano.gameObject.name);
                }
                    // 1 -- NO HAY ENEMIGO REGISTRADO en enemigoCercano == null
                    // enemigoCercano --> rellenarlo con en enemigo sin comparar

                    // 2 -- TENEMOS YA UN ENEMIGO REGISTRADO
                    // comparar si este enemigo está más cerca
                    // que el enemigoCercano                   
            }
        }
    }




}
