using System.Text;
using System.Text.Json;

namespace Alerting;

public class Formatter
{
    public IList<ConditionalField> ConditionalFields {get;set;}

    public static Formatter GetFormatter(string conf)
    {
        return JsonSerializer.Deserialize<Formatter>(conf);
    }

    public string FormatAlert(Alert alert)
    {
        StringBuilder sb = new StringBuilder();
        var listOfFields = ConditionalFields.Select(cf => alert.GetFieldValue(cf.GetField(alert)));
        sb.AppendJoin(';', listOfFields);

        return sb.ToString();
    }
}
