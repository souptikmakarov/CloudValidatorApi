using System;
using System.Collections.Generic;
using System.Text;

namespace TwelveFactor.Core.Enums
{
    public enum Application
    {
        Dotnet = 0,
        Java,
        NodeJs
    }

    public enum Condition
    {
        ContainsAny,
        NotContainsAny,
        ContainsAll,
        NotContainsAll,
        StartsWith,
        EndsWith,
        RegEx,
        SearchOnlyIn,
        Exactly,
        CaseSenitive
    }

    public enum Factor
    {
        Logs,
        Config,
        Backing,
        Dependencies
    }

    public enum RuleType
    {
        Include,
        Exclude
    }
}
