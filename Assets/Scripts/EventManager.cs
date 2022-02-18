using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Beam.Events
{
    /*
     * The purpose of this class is to hold instances to events and operate on those instances.
     * There are several advantages of using this manager:
     * 
     * 1. It is easier to find and use events since senders that invoke or receivers that listen to events
     * only need to know the event type rather than have a reference to the event instance.
     * 
     * 2. It further decouples senders from receivers since neither of them are responsible for 
     * holding the instance of the event. In fact, neither of them have to worry about if this instance exists
     * because the manager takes care of that.
     * 
     * 3. It enforces an invariant that only one instance of each event type exists.
     */
    public sealed class EventManager
    {
        #region Singleton Pattern
        //This code is meant to ensure that only one EventManager ever exists at runtime.
        //There are multiple ways to do this, as seen here: https://csharpindepth.com/Articles/Singleton
        //DON'T USE THIS CODE WITH MONO BEHAVIOUR! (see alternative example in GameManager.cs)

        //visible Instance to everyone else
        public static EventManager Instance { get { return SingletonImp._instance; } }

        //The instance is instantiated on the first access to SingletonImp._instance. This is called lazy initialization.
        //https://docs.microsoft.com/en-us/dotnet/framework/performance/lazy-initialization
        private class SingletonImp
        {
            static SingletonImp() { }

            //internal b/c if it was private, the outside class wouldn't be able to access it.
            internal static readonly EventManager _instance = new EventManager();
        }

        #endregion

        private Dictionary<System.Type, UnityEventBase> eventDict;

        //private constructor ensures other code cannot instantiate this object.
        private EventManager()
        {
            eventDict = new Dictionary<System.Type, UnityEventBase>();
        }

        public static void StartListening<UnityEventDerived>(UnityAction listener) where UnityEventDerived : UnityEvent, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.AddListener(listener);
        }

        public static void StartListening<UnityEventDerived, T0>(UnityAction<T0> listener) where UnityEventDerived : UnityEvent<T0>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.AddListener(listener);
        }

        public static void StartListening<UnityEventDerived, T0, T1>(UnityAction<T0, T1> listener) where UnityEventDerived : UnityEvent<T0, T1>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.AddListener(listener);
        }

        public static void StartListening<UnityEventDerived, T0, T1, T2>(UnityAction<T0, T1, T2> listener) where UnityEventDerived : UnityEvent<T0, T1, T2>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.AddListener(listener);
        }

        public static void StartListening<UnityEventDerived, T0, T1, T2, T3>(UnityAction<T0, T1, T2, T3> listener) where UnityEventDerived : UnityEvent<T0, T1, T2, T3>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.AddListener(listener);
        }

        public static void StopListening<UnityEventDerived>(UnityAction listener) where UnityEventDerived : UnityEvent
        {
            UnityEventDerived uEvent = Instance.verifyEventInDict<UnityEventDerived>();
            if (uEvent != null)
            {
                uEvent.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning("Listener" + listener.ToString() +
                        " did not stop listening to event: " + typeof(UnityEventDerived).ToString() +
                        "because this event doesn't exist yet.");
            }

        }

        public static void StopListening<UnityEventDerived, T0>(UnityAction<T0> listener) where UnityEventDerived : UnityEvent<T0>
        {
            UnityEventDerived uEvent = Instance.verifyEventInDict<UnityEventDerived>();
            if (uEvent != null)
            {
                uEvent.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning("Listener" + listener.ToString() +
                        " did not stop listening to event: " + typeof(UnityEventDerived).ToString() +
                        "because this event doesn't exist yet.");
            }

        }

        public static void StopListening<UnityEventDerived, T0, T1>(UnityAction<T0, T1> listener) where UnityEventDerived : UnityEvent<T0, T1>
        {
            UnityEventDerived uEvent = Instance.verifyEventInDict<UnityEventDerived>();
            if (uEvent != null)
            {
                uEvent.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning("Listener" + listener.ToString() +
                        " did not stop listening to event: " + typeof(UnityEventDerived).ToString() +
                        "because this event doesn't exist yet.");
            }

        }

        public static void StopListening<UnityEventDerived, T0, T1, T2>(UnityAction<T0, T1, T2> listener) where UnityEventDerived : UnityEvent<T0, T1, T2>
        {
            UnityEventDerived uEvent = Instance.verifyEventInDict<UnityEventDerived>();
            if (uEvent != null)
            {
                uEvent.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning("Listener" + listener.ToString() +
                        " did not stop listening to event: " + typeof(UnityEventDerived).ToString() +
                        "because this event doesn't exist yet.");
            }

        }

        public static void StopListening<UnityEventDerived, T0, T1, T2, T3>(UnityAction<T0, T1, T2, T3> listener) where UnityEventDerived : UnityEvent<T0, T1, T2, T3>
        {
            UnityEventDerived uEvent = Instance.verifyEventInDict<UnityEventDerived>();
            if (uEvent != null)
            {
                uEvent.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning("Listener" + listener.ToString() +
                        " did not stop listening to event: " + typeof(UnityEventDerived).ToString() +
                        "because this event doesn't exist yet.");
            }

        }

        public static void InvokeEvent<UnityEventDerived>() where UnityEventDerived : UnityEvent, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.Invoke();
        }

        public static void InvokeEvent<UnityEventDerived, T0>(T0 arg0) where UnityEventDerived : UnityEvent<T0>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.Invoke(arg0);
        }

        public static void InvokeEvent<UnityEventDerived, T0, T1>(T0 arg0, T1 arg1) where UnityEventDerived : UnityEvent<T0, T1>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.Invoke(arg0, arg1);
        }

        public static void InvokeEvent<UnityEventDerived, T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2) where UnityEventDerived : UnityEvent<T0, T1, T2>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.Invoke(arg0, arg1, arg2);
        }
        public static void InvokeEvent<UnityEventDerived, T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3) where UnityEventDerived : UnityEvent<T0, T1, T2, T3>, new()
        {
            UnityEventDerived uEvent = Instance.verifyCreateEventInDict<UnityEventDerived>();
            uEvent.Invoke(arg0, arg1, arg2, arg3);
        }

        //Verifies that an event exists, creates it if it doesn't, and returns the event
        private UnityEventDerived verifyCreateEventInDict<UnityEventDerived>() where UnityEventDerived : UnityEventBase, new()
        {
            UnityEventDerived uEvent = verifyEventInDict<UnityEventDerived>();
            if (uEvent == null)
            {
                uEvent = new UnityEventDerived();
                eventDict.Add(typeof(UnityEventDerived), uEvent);
            }

            return uEvent;
        }

        //Verifies that an event exists, and returns it if it exists, otherwise returns null.
        private UnityEventDerived verifyEventInDict<UnityEventDerived>() where UnityEventDerived : UnityEventBase
        {
            UnityEventBase uEvent = null;
            if (eventDict.TryGetValue(typeof(UnityEventDerived), out uEvent))
            {

                //Event Manager enforces the invariant that uEvent matches the type in the dictionary, so this cast should always succeed.
                Debug.AssertFormat(uEvent as UnityEventDerived != null, "Error: Value retrieved from dictionary did not match type given in key. This should never happen.");
                return uEvent as UnityEventDerived;
            }

            return null;
        }
    }
}