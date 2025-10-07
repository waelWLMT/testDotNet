using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerting
{
    public class CategoryConditionalField : ConditionalField
    {
        public string ExpectedCategory { get; set; }        
        public override Field GetField(Alert alert)
        {
            // On teste si la catégorie attendue est présente dans la liste des catégories de l'alerte
            if (alert.Categories.Split(";").Any(s => string.Equals(s, ExpectedCategory, StringComparison.OrdinalIgnoreCase)))
                return FieldIfTrue;

            return FieldIfFalse;
        }
    }    
}
