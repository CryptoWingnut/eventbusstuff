namespace EventBusStuff;

public static class Program {
  private static EventBus? _eventBus;
  private static ServiceA? _serviceA;
  private static ServiceB? _serviceB;
  private static ServiceC? _serviceC;
  
  public static async Task Main() {
    _eventBus = new();
    _serviceA = new(_eventBus);
    _serviceB = new(_eventBus);
    _serviceC = new(_eventBus);

    var resultsA = await _serviceA.FireEvent2();
    var resultsB = await _serviceB.FireEvent3();
    var resultsC = await _serviceC.FireEvent1();
    
    if (resultsA.Length > 0) Console.WriteLine($"ResultsA : {string.Join(':', resultsA)}");
    if (resultsB.Length > 0) Console.WriteLine($"ResultsB : {string.Join(':', resultsB)}");
    if (resultsC.Length > 0) Console.WriteLine($"ResultsC : {string.Join(':', resultsC)}");
  }
}