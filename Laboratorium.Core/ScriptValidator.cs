using System.Collections.Generic;
using System.Linq;

namespace Laboratorium.Core
{
    public class ScriptValidator
    {
        public List<string> FindInvalidCode(string script)
        {
            if (script == null)
            {
                return new List<string>();
            }

            var patterns = new List<string>
            {
                "open",
                "#r",
                "#I",
                "#load",
                "#help",
                "#quit"
            };

            return (from pattern in patterns
                where script.Contains(pattern)
                select $"\"{pattern}\" - недопустима€ дл€ использовани€ конструкци€").ToList();
        }
    }
}