using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alerting;

public class ConditionalFieldJsonConverter : JsonConverter<ConditionalField>
{
    public override ConditionalField Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        string[] arr = reader.GetString().Split(";");


        var condionalCreteria = arr.Length == 4 && arr[3] == "1"
            ? CondionalCreteria.Status
            : CondionalCreteria.Category;


        return condionalCreteria == CondionalCreteria.Category
            ? new CategoryConditionalField()
            {
                FieldIfTrue = Enum.Parse<Field>(arr[1]),
                FieldIfFalse = Enum.Parse<Field>(arr[2]),
                ExpectedCategory = arr[0]
            }
            : new StatusConditionalField()
            {
                FieldIfTrue = Enum.Parse<Field>(arr[1]),
                FieldIfFalse = Enum.Parse<Field>(arr[2]),
                ExpectedStatus = arr[0]
            };
       
    }

    public override void Write(Utf8JsonWriter writer, ConditionalField cf, JsonSerializerOptions options)
    {
        if(cf is CategoryConditionalField ccf)
        {
            writer.WriteStringValue(string.Format("{0};{1};{2};0",
            ccf.ExpectedCategory, (int)ccf.FieldIfTrue, (int)ccf.FieldIfFalse));
        }
        else if (cf is StatusConditionalField scf)
        {
            writer.WriteStringValue(string.Format("{0};{1};{2};1",
            scf.ExpectedStatus, (int)scf.FieldIfTrue, (int)scf.FieldIfFalse));
        }
        else
        {
            throw new NotSupportedException($"The type {cf.GetType().FullName} is not supported by the ConditionalFieldJsonConverter.");
        }        
    }

    
}
