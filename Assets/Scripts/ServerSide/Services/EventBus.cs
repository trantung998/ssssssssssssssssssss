using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServerSide.Services
{
    /// <summary>
    /// Prototype for subscribers action.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public delegate void EventHandler<T>(T eventData);
    
    /// <summary>
    /// EventBus implementation.
    /// </summary>
    public sealed class EventBus
    {
        const int MaxCallDepth = 5;

        readonly Dictionary<Type, Delegate> _events = new Dictionary<Type, Delegate>(32);

        int _eventsInCall;

        /// <summary>
        /// Subscribe callback to be raised on specific event.
        /// </summary>
        /// <param name="customEventAction">Callback.</param>
        public void Subscribe<T>(EventHandler<T> customEventAction)
        {
            if (customEventAction != null)
            {
                var eventType = typeof(T);
                Delegate rawList;
                _events.TryGetValue(eventType, out rawList);
                _events[eventType] = (rawList as EventHandler<T>) + customEventAction;
            }
        }

        /// <summary>
        /// Unsubscribe callback.
        /// </summary>
        /// <param name="customEventAction">Event action.</param>
        /// <param name="keepEvent">GC optimization - clear only callback list and keep event for future use.</param>
        public void Unsubscribe<T>(EventHandler<T> customEventAction, bool keepEvent = false)
        {
            if (customEventAction != null)
            {
                var eventType = typeof(T);
                Delegate rawList;
                if (_events.TryGetValue(eventType, out rawList))
                {
                    var list = (rawList as EventHandler<T>) - customEventAction;
                    if (list == null && !keepEvent)
                    {
                        _events.Remove(eventType);
                    }
                    else
                    {
                        _events[eventType] = list;
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribe all callbacks from event.
        /// </summary>
        /// <param name="keepEvent">GC optimization - clear only callback list and keep event for future use.</param>
        public void UnsubscribeAll<T>(bool keepEvent = false)
        {
            var eventType = typeof(T);
            Delegate rawList;
            if (_events.TryGetValue(eventType, out rawList))
            {
                if (keepEvent)
                {
                    _events[eventType] = null;
                }
                else
                {
                    _events.Remove(eventType);
                }
            }
        }

        /// <summary>
        /// Unsubscribe all listeneres and clear all events.
        /// </summary>
        public void UnsubscribeAndClearAllEvents()
        {
            _events.Clear();
        }

        /// <summary>
        /// Publish event.
        /// </summary>
        /// <param name="eventMessage">Event message.</param>
        public void Publish<T>(T eventMessage)
        {
            if (_eventsInCall >= MaxCallDepth)
            {
#if UNITY_EDITOR
                Debug.LogError ("Max call depth reached");
#endif
                return;
            }

            var eventType = typeof(T);
            Delegate rawList;
            _events.TryGetValue(eventType, out rawList);
            var list = rawList as EventHandler<T>;
            if (list != null)
            {
                _eventsInCall++;
                list(eventMessage);


                _eventsInCall--;
            }
        }
    }
}