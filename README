This repository contains the source for a ReSharper macro which can be used when creating ReSharper live templates.  It replaces occurences of a capital letter in a string with an underscore and the equivalent lowercase letter.  For example, it will replace TestFixtureVariableExpansionMacro with test_fixture_variable_expansion_macro.

The source shows an example of how to declare a macro parameter.  These can be used when generating your template to introduce a reference to a variable. In particular see the implementation of the Parameters property which is declared on the IMacro interface.  Also, note the syntax of the ShortDescription attribute.  The placeholder {#0:another variable} is replaced by ReSharper at runtime and allows the user choose the relevant variable by clicking on a link.

The code has only been tested with version 6.1 of ReSharper but should work without modification with other versions.  It is written in C# using .NET 4.0 and the project was created in Visual Studio 2010.

For deployment, simply copy the assembly into a subfolder of the ReSharper Plugins directory.  If you accepted the defaults when installing ReSharper the Plugins directory could be something like c:\Program Files (x86)\JetBrains\ReSharper\v6.1\Bin\Plugins
