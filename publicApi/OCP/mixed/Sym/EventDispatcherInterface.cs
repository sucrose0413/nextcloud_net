﻿using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCP.Sym
{

    /**
     * The EventDispatcherInterface is the central point of Symfony's event listener system.
     * Listeners are registered on the manager and events are dispatched through the
     * manager.
     *
     * @author Bernhard Schussek <bschussek@gmail.com>
     *
     * @api
     */
    public interface EventDispatcherInterface
    {
        /**
         * Dispatches an event to all registered listeners.
         *
         * @param string $eventName The name of the event to dispatch. The name of
         *                          the event is the name of the method that is
         *                          invoked on listeners.
         * @param Event $event The event to pass to the event handlers/listeners.
         *                          If not supplied, an empty Event instance is created.
         *
         * @return Event
         *
         * @api
         */
        ext.Event dispatch(string eventName, ext.Event eventp = null);

    /**
     * Adds an event listener that listens on the specified events.
     *
     * @param string   $eventName The event to listen on
     * @param callable $listener  The listener
     * @param integer  $priority  The higher this value, the earlier an event
     *                            listener will be triggered in the chain (defaults to 0)
     *
     * @api
     */
    void addListener(string eventName, ext.Event listener, int priority = 0);

        /**
         * Adds an event subscriber.
         *
         * The subscriber is asked for all the events he is
         * interested in and added as a listener for these events.
         *
         * @param EventSubscriberInterface $subscriber The subscriber.
         *
         * @api
         */
        void addSubscriber(ext.Event subscriber);

        /**
         * Removes an event listener from the specified events.
         *
         * @param string|array $eventName The event(s) to remove a listener from
         * @param callable     $listener  The listener to remove
         */
        void removeListener(string eventName, ext.Event listener);

        /**
         * Removes an event subscriber.
         *
         * @param EventSubscriberInterface $subscriber The subscriber
         */
        void removeSubscriber(ext.Event subscriber);

        /**
         * Gets the listeners of a specific event or all listeners.
         *
         * @param string $eventName The name of the event
         *
         * @return array The event listeners for the specified event, or all event listeners by event name
         */
        PhpArray getListeners(string eventName = null);

        /**
         * Checks whether an event has any registered listeners.
         *
         * @param string $eventName The name of the event
         *
         * @return Boolean true if the specified event has any listeners, false otherwise
         */
        bool hasListeners(string eventName = null);
    }

}
