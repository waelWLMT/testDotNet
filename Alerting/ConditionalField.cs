using System.Text.Json.Serialization;

namespace Alerting;


[JsonConverter(typeof(ConditionalFieldJsonConverter))]
public abstract class ConditionalField : IConditionlField
{   
    public Field FieldIfTrue { get; set; }
    public Field FieldIfFalse { get; set; }
    public abstract Field GetField(Alert alert);
}

