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

        var cf = new ConditionalField()
        {
            FieldIfTrue = Enum.Parse<Field>(arr[1]),
            FieldIfFalse = Enum.Parse<Field>(arr[2])
        };

        cf.CondionalCreteria =
            arr.Length == 4 && arr[3] == "1"
            ? CondionalCreteria.Status
            : CondionalCreteria.Category;

        if (cf.CondionalCreteria == CondionalCreteria.Category)
            cf.ExpectedCategory = arr[0];
        else
            cf.ExpectedStatus = arr[0];

        return cf;

    }

    public override void Write(Utf8JsonWriter writer, ConditionalField cf, JsonSerializerOptions options)
    {
        if (cf.CondionalCreteria == CondionalCreteria.Category)
            writer.WriteStringValue(string.Format("{0};{1};{2};0",
            cf.ExpectedCategory, (int)cf.FieldIfTrue, (int)cf.FieldIfFalse));
        else
            writer.WriteStringValue(string.Format("{0};{1};{2};1",
            cf.ExpectedStatus, (int)cf.FieldIfTrue, (int)cf.FieldIfFalse));
    }

    //public override void Write(
    //    Utf8JsonWriter writer,
    //    ConditionalField cf,
    //    JsonSerializerOptions options) =>
    //        writer.WriteStringValue(string.Format("{0};{1};{2}",
    //        cf.ExpectedCategory, (int)cf.FieldIfTrue, (int)cf.FieldIfFalse));
}
