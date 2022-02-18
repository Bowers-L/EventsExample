using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DvaBombEvents : MonoBehaviour
{
    public struct BombEventArgs
    {
        //This is what we pass to the subscribers of the event.
        public Vector3 pos;
        public float radius;
    }
    //class BombEvent : UnityEvent<BombEventArgs> { }
    public static UnityEvent<BombEventArgs> bombGoBoom;

    public float bombRadius;
    public void DetonateBomb()
    {
        bombGoBoom.Invoke(new BombEventArgs { pos = transform.position, radius = bombRadius });
    }
}
