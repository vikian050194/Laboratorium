using System;
using System.Collections.Generic;
using System.Linq;
using Laboratorium.Core.Containers;

namespace Laboratorium.Core.Managers
{
    public class OutputManager
    {
        private List<Rule> _rules;

        public OutputManager()
        {
            _rules = new List<Rule>();
        }

        public Packet Process(string script, string result, string errors)
        {
            var packet = new Packet
            {
                IsError = errors.Length != 0
            };

            if (packet.IsError)
            {
                packet.Result = errors.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                _rules.Add(new Rule { From = "System.Numerics.", To = "", RuleAction = Action.ReplaceWord });
                _rules.Add(new Rule { From = "->\r\n", To = "-> ", RuleAction = Action.ReplaceWord });
                _rules.Add(new Rule { From = ":\r\n", To = ": ", RuleAction = Action.ReplaceWord });
                packet.Result = Process(result).Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                _rules.Add(new Rule { From = "--> Referenced", To = "", RuleAction = Action.RemoveLine });
                _rules.Add(new Rule { From = "> ", To = "", RuleAction = Action.RemoveLine });
                packet.Result = Process(packet.Result);
            }

            return packet;
        }

        private List<string> Process(List<string> lines)
        {
            var result = new List<string>();

            foreach (var line in lines)
            {
                result.Add(Process(line));
            }

            result = result.Where(l => !string.IsNullOrEmpty(l)).ToList();
            return result;
        }

        private string Process(string line)
        {
            var result = line;

            foreach (var rule in _rules)
            {
                result = ApplyRule(result, rule);
            }

            return result;
        }

        private string ApplyRule(string line, Rule rule)
        {
            switch (rule.RuleAction)
            {
                case Action.ReplaceWord:
                    return line.Replace(rule.From, rule.To);
                case Action.RemoveLine:
                    if (line.IndexOf(rule.From) == 0)
                    {
                        return string.Empty;
                    }
                    return line;
                default:
                    return string.Empty;
            }
        }
    }
}