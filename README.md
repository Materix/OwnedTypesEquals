# OwnedTypesEquals

Reproduction repository for https://github.com/aspnet/EntityFrameworkCore/issues/10030

Problem with overriden equals in owned entity which was initialized in onwer type.

Tests that cover four situation:

- Equals and initializer (https://github.com/Materix/OwnedTypesEquals/tree/master/OwnedTypesEquals/EqualsInitializer)
- Only initializer (https://github.com/Materix/OwnedTypesEquals/tree/master/OwnedTypesEquals/Initializer)
- Only Equals (https://github.com/Materix/OwnedTypesEquals/tree/master/OwnedTypesEquals/Equals)
- None of the above (https://github.com/Materix/OwnedTypesEquals/tree/master/OwnedTypesEquals/Nothing)

Each case was organized as follow:
DataContext.cs | DbContext for this case
DataContextCreator.cs | Helper class for creating DataContext with in memory provider
DataContextTest.cs | Test class
Entity.cs | Owner type
TransliteratedString.cs | Owned type

## Results

 .| Added default owned value | Added default owned value and filled when acquired | Added filled default owned value | Added filled new owned value 
--- | --- | --- | --- | ---
Equals and initializer | Exception | Exception | Good | Good
Only initializer | Good | Good | Good | Good
Only Equals | Good (new instance) | Good (new instance) | Same case as next | Good
None of the above | Good (new instance) | Good (new instance) | Same case as next | Good
