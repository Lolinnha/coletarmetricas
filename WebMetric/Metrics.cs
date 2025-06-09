using System.Diagnostics.Metrics;

public class LawHunterMetrics
{
    private readonly Counter<int> _customCounter;

    public LawHunterMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("MyApp.Custom", "1.0.0");
        _customCounter = meter.CreateCounter<int>("myapp.custom.request_count");
    }

    public void RegisterRequest(string path)
    {
        _customCounter.Add(1, new KeyValuePair<string, object?>("endpoint", path));
    }
}
