namespace EventBusStuff; 

public interface IEventBus {
  public delegate Task<object?> EventHandler(object? payload = null);

  void RegisterHandler(EventType type, IEventBus.EventHandler handler, int? priority = null);
  Task<object[]> FireEvent(EventType type, object? payload = null);
}
