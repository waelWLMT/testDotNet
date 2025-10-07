using System.Text.Json.Serialization;

namespace Alerting;

/// <summary>
/// Champ conditionné sur la présence d'une catégorie 
/// précise dans la liste des catégories d'une alerte
/// </summary>
[JsonConverter(typeof(ConditionalFieldJsonConverter))] 
public class ConditionalField
{
    public string ExpectedCategory {get;set;}

    public Field FieldIfTrue {get;set;}

    public Field FieldIfFalse {get;set;}

    public Field GetField(Alert alert)
    {
        if(alert.Categories
            .Split(";")
            .Any(s => string.Equals(s, ExpectedCategory)))
        {
            return FieldIfTrue;
        }
        else
            return FieldIfFalse;
    }
}
