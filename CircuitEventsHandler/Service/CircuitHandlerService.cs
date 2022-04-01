﻿using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CircuitEventsHandler.Service
{
    public class CircuitHandlerService : CircuitHandler
    {
        public ConcurrentDictionary<string, Circuit> Circuits { get; set; }
        public event EventHandler CircuitsChanged;

        protected virtual void OnCircuitsChanged()
    => CircuitsChanged?.Invoke(this, EventArgs.Empty);

        public CircuitHandlerService()
        {
            Circuits = new ConcurrentDictionary<string, Circuit>();
        }

        public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            //User's details after initial access - Save somewhere
            //IHttpContextAccessor accessor = new HttpContextAccessor();
            //var userIdentity = accessor.HttpContext.User.Identity;
            Circuits[circuit.Id] = circuit;
            OnCircuitsChanged();
            return base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuit circuitRemoved;
            Circuits.TryRemove(circuit.Id, out circuitRemoved);
            OnCircuitsChanged();
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionDownAsync(circuit, cancellationToken);
        }

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionUpAsync(circuit, cancellationToken);
        }
    }
}
