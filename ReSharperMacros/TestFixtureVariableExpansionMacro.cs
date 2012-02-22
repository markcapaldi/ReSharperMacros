using System;
using System.Collections.Generic;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace Mark.Capaldi.ResharperMacros
{
    /// <summary>
    /// Implements a ReSharper macro that can be used when defining a
    /// ReSharper template.  I use it when writing BDD-style tests to
    /// insert a type name into the fixture name by replacing capital
    /// letters with an underscore followed by the lowercase equivalent.
    /// For example, it will replace <see cref="TestFixtureVariableExpansionMacro" />
    /// with test_fixture_variable_expansion_macro.
    /// </summary>
    [Macro("Mark.Capaldi.ResharperMacros.TestFixtureVariableExpansionMacro",
        ShortDescription = "Value of {#0:another variable} with capital letters replaced with an underscore and a lower case letter.",
        LongDescription = "Modifies the value of a variable by replacing any capital letters with an underscore followed by a lower case letter.")]
    public class TestFixtureVariableExpansionMacro : IMacro
    {
        public string GetPlaceholder(IDocument document)
        {
            return "a";
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            return false;
        }

        public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return null;
        }

        public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
        {
            if (arguments.Count != 1)
            {
                return null;
            }

            return PerformReplacement(arguments[0]);
        }

        public ParameterInfo[] Parameters
        {
            get { return new[] { new ParameterInfo(ParameterType.VariableReference) };}
        }

        /// <summary>
        /// Examines a string of characters and replaces any capital letters with an underscore
        /// followed by the lowercase equivalent.
        /// </summary>
        /// <param name="text">The string of characters to perform the replacement on.</param>
        /// <returns>A string with capital letters replaced by an underscore followed by the lowercase equivalent.</returns>
        private static string PerformReplacement(string text)
        {
            var newText = string.Empty;

            if (text.Length > 0)
            {
                foreach (var character in text)
                {
                    if (Char.IsUpper(character))
                    {
                        newText += string.Format("_{0}", Char.ToLower(character));
                    }
                    else
                    {
                        newText += character;
                    }
                } 
            }

            return newText;
        }
    }
}
