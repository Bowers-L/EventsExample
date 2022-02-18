using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DvaBombDelegates : MonoBehaviour
{
    public class BombEventArgs : System.EventArgs
    {
        //This is what we pass to the subscribers of the event.
        public Vector3 pos;
        public float radius;
    }
    //public delegate void BombGoBoomEvent(Vector3 pos, float radius);
    //public static BombGoBoomEvent bombGoBoomEvent;
    public static event System.EventHandler<BombEventArgs> bombGoBoomEvent;
    //public UnityAction<Vector3, float> bombGoBoomAction;

    public float bombRadius;

    public void DetonateBomb()
    {
        bombGoBoomEvent.Invoke(this, new BombEventArgs { pos = transform.position, radius = bombRadius });
        //bombGoBoomAction.Invoke(transform.position, bombRadius);
    }

}