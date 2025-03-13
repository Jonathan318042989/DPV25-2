using UnityEngine;
using System;
using UnityEngine.Events;

public class eventos : MonoBehaviour
{
    public Action action;
    public static eventos instance;

    public void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    public void metodo1() 
    {
        action?.Invoke();
    }

    public void suscribirEvento(Action evento)
    {
        action += evento;
    }

    public void desuscribirEvento(Action evento)
    {
        action -= evento;
    }
}
