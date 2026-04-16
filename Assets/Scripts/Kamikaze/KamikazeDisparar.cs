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

        agente.GetComponent<Renderer>().material.color = Color.green;
        agente.GetComponent<NavMeshAgent>().isStopped = true;
        agente.GetComponent<KamikazeIA>().disparo = true;
        agente.GetComponent<KamikazeIA>().EmpezarAtaque();
    }

    public override void Actualizar()
    {
        //agente.GetComponent<Transform>().LookAt(enemigoCercano.transform.position);
        /*if (!RangoPersecucion())
        {
            siguienteEstado = new KamikazeSeguir();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }*/
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
