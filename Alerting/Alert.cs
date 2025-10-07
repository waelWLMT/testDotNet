namespace Alerting;

/// <summary>
/// L'alerte est une occurence d'événement sur l'installation
/// </summary>
public class Alert
{
    public string Name {get; set; }

    public string Description {get; set; }

    public string Area {get; set; }

    /// <summary>
    /// Liste des catégories de l'alerte au format "<cat1>;<cat2>;..."
    /// </summary>
    public string Categories {get; set; }

    public int Priority {get; set; }

    public Status Status {get; set; }

    public DateTime ActivationDate {get; set; }

    public DateTime AckDate {get; set; }

    public string GetFieldValue(Field field)
    {
        switch (field)
        {
            case Field.Name:
                return Name;
            case Field.Categories:
                return Categories;
            case Field.Priority:
                return Priority.ToString();
            case Field.Area:
                return Area;
            case Field.Description:
                return Description;
            case Field.ActivationDate:
                return ActivationDate.ToString("o");
            case Field.AckDate:
                return AckDate.ToString("o");
            case Field.Status:
                return Status.ToString();
            default:
                throw new InvalidOperationException("Unknown field");
        }
    }
}
