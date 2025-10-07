using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerting
{
    public class StatusConditionalField : ConditionalField
    {
        public string ExpectedStatus { get; set; }
        public override Field GetField(Alert alert)
        {
            // On teste si le status attendue est bien le status de l'alerte
            if (string.Equals(alert.Status.ToString(), ExpectedStatus, StringComparison.OrdinalIgnoreCase))
                return FieldIfTrue;

            return FieldIfFalse;
        }
    }
}
