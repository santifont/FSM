using UnityEngine;
using UnityEngine.AI;

public class PistoleroVigilar : PistoleroEstado
{
    public PistoleroVigilar() : base()
    {
        Debug.Log("PISTOLERO VIGILAR");
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
        if (JugadorEstaCerca())
        {
            siguienteEstado = new PistoleroPerseguir();
            siguienteEstado.InicializarFSM(agente, jugador);
            faseActual = EVENTO.SALIR;
        }

    }

    public override void Salir()
    {
        // Le resetear�amos la animacion de andar, o lo que sea...
        base.Salir();
    }
}
