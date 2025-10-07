using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerting
{
    public interface IConditionlField
    {
        public Field GetField(Alert alert);
    }
}
