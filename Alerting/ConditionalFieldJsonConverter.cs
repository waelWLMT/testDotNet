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

        var exectedCategory = arr[0];
        var fieldIfTrue = Enum.Parse<Field>(arr[1]);
        var fieldIfFalse = Enum.Parse<Field>(arr[2]);

        var cf = new ConditionalField()
        {
            ExpectedCategory = exectedCategory,
            FieldIfTrue = fieldIfTrue,
            FieldIfFalse = fieldIfFalse
        };

        return cf;



        /* old code from test not so readable
            return new ConditionalField() { 
                ExpectedCategory = arr[0],
                FieldIfTrue = Enum.Parse<Field>(arr[1]),
                FieldIfFalse = Enum.Parse<Field>(arr[2])
            };
        */
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConditionalField cf,
        JsonSerializerOptions options) =>
            writer.WriteStringValue(string.Format("{0};{1};{2}",
            cf.ExpectedCategory, (int)cf.FieldIfTrue, (int)cf.FieldIfFalse));
}
