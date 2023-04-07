namespace EventBusStuff; 

public sealed class ServiceA {
  private readonly IEventBus _eventBus;
  
  public ServiceA(IEventBus eventBus) {
    _eventBus = eventBus;
    _eventBus.RegisterHandler(EventType.EVENT1, HandleEvent1);
    _eventBus.RegisterHandler(EventType.EVENT3, HandleEvent3);
  }

  public async Task<object[]> FireEvent2() {
    return await _eventBus.FireEvent(EventType.EVENT2);
  }
  
  private async Task<object?> HandleEvent1(object? payload = null) {
    Console.WriteLine("Service A - Event 1");
    return "Service A - Event 1 - Response";
  }
  
  private async Task<object?> HandleEvent3(object? payload = null) {
    Console.WriteLine($"Service A - Event 3 :: {(string) payload!}");
    return null;
  }
}
