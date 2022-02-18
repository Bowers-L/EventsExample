using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void Start()
    {
        //DvaBombDelegates.bombGoBoomEvent += BombExplodedHandler;
        DvaBombDelegates.bombGoBoomEvent += BombExplodedHandler;
    }

    public void OnDestroy()
    {
        //DvaBombDelegates.bombGoBoomEvent -= BombExplodedHandler;
    }

    public void Die()
    {
        Debug.Log("Bleh");
    }

    //Unity Events
    public void BombExplodedHandler(DvaBombEvents.BombEventArgs args)
    {
        if ((transform.position - args.pos).magnitude < args.radius)
        {
            Die();
        }
    }

    //C# Delegates
    public void BombExplodedHandler(object sender, DvaBombDelegates.BombEventArgs e)
    {
        if ((transform.position - e.pos).magnitude < e.radius)
        {
            Die();
        }
    }

    //Unity Actions
    public void BombExplodedHandler(Vector3 pos, float radius)
    {
        if ((transform.position - pos).magnitude < radius)
        {
            Die();
        }
    }
}
