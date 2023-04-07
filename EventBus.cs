using System.Diagnostics;

namespace EventBusStuff; 

public sealed class EventBus : IEventBus {
  private readonly List<IEventBus.EventHandler> _event1Handlers = new();
  private readonly List<IEventBus.EventHandler> _event2Handlers = new();
  private readonly List<IEventBus.EventHandler> _event3Handlers = new();

  public void RegisterHandler(EventType type, IEventBus.EventHandler handler, int? priority = null) {
    switch (type) {
      case EventType.EVENT1:
        if (priority != null && _event1Handlers.Count > priority) _event1Handlers.Insert((int) priority, handler);
        else _event1Handlers.Add(handler);
        break;
      
      case EventType.EVENT2:
        if (priority != null && _event2Handlers.Count > priority) _event2Handlers.Insert((int) priority, handler);
        else _event2Handlers.Add(handler);
        break;
      
      case EventType.EVENT3:
        if (priority != null && _event3Handlers.Count > priority) _event3Handlers.Insert((int) priority, handler);
        else _event3Handlers.Add(handler);
        break;
    }
  }

  public async Task<object[]> FireEvent(EventType type, object? payload = null) {
    var results = new List<object>();
    
    var handlers = type switch {
      EventType.EVENT1 => _event1Handlers,
      EventType.EVENT2 => _event2Handlers,
      EventType.EVENT3 => _event3Handlers,
      _ => throw new UnreachableException("Somehow we sent an event type that doesnt exist in the enum")
    };
    
    foreach (var handler in handlers) {
      var result = await handler(payload);
      if (result != null) results.Add(result);
    }

    return results.ToArray();
  }
}
