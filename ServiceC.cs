namespace EventBusStuff; 

public class ServiceC {
  private readonly IEventBus _eventBus;

  public ServiceC(IEventBus eventBus) {
    _eventBus = eventBus;
    _eventBus.RegisterHandler(EventType.EVENT2, HandleEvent2);
    _eventBus.RegisterHandler(EventType.EVENT3, HandleEvent3, 0);
  }
  
  public async Task<object[]> FireEvent1() {
    return await _eventBus.FireEvent(EventType.EVENT1);
  }
  
  private async Task<object?> HandleEvent2(object? payload = null) {
    Console.WriteLine("Service C - Event 2");
    return null;
  }
  
  private async Task<object?> HandleEvent3(object? payload = null) {
    Console.WriteLine($"Service C - Event 3 :: {(string) payload!}");
    return null;
  }
}
