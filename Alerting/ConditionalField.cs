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
    public string ExpectedStatus {get;set;}
    public CondionalCreteria CondionalCreteria { get; set; }
    public Field FieldIfTrue {get;set;}
    public Field FieldIfFalse {get;set;}
    public Field GetField(Alert alert)
    {
        // On teste si la catégorie attendue est présente dans la liste des catégories de l'alerte
        if (CondionalCreteria.Category == CondionalCreteria && alert.Categories.Split(";").Any(s => string.Equals(s, ExpectedCategory)))
            return FieldIfTrue;

        // On teste si le status attendue est bien le status de l'alerte
        if (CondionalCreteria.Status == CondionalCreteria && string.Equals(alert.Status.ToString(), ExpectedStatus))
            return FieldIfTrue;

        return FieldIfFalse;

        
    }
}
