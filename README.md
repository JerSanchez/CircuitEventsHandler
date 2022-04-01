# CircuitEventsHandler

**Methods**
**OnCircuitClosedAsync**(Circuit, CancellationToken)
Invoked when a new circuit is being discarded.

**OnCircuitOpenedAsync**(Circuit, CancellationToken)
Invoked when a new circuit was established.

**OnConnectionDownAsync**(Circuit, CancellationToken)
Invoked when a connection to the client was dropped.

**OnConnectionUpAsync**(Circuit, CancellationToken) 
Invoked when a connection to the client was established. - This method is executed once initially after OnCircuitOpenedAsync(Circuit, CancellationToken) and once each for each reconnect during the lifetime of a circuit.
