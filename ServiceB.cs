namespace EventBusStuff; 

public class ServiceB {
  private readonly IEventBus _eventBus;

  public ServiceB(IEventBus eventBus) {
    _eventBus = eventBus;
    _eventBus.RegisterHandler(EventType.EVENT1, HandleEvent1);
    _eventBus.RegisterHandler(EventType.EVENT2, HandleEvent2);
  }
  
  public async Task<object[]> FireEvent3() {
    return await _eventBus.FireEvent(EventType.EVENT3, "EVENT 3 PAYLOAD");
  }

  private async Task<object?> HandleEvent1(object? payload = null) {
    Console.WriteLine("Service B - Event 1");
    return null;
  }

  private async Task<object?> HandleEvent2(object? payload = null) {
    Console.WriteLine("Service B - Event 2");
    return null;
  }
}
