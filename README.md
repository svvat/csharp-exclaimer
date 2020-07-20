"# csharp-exclaimer" 

C# code test

interface called ICharacterReader that returns a character from a stream. An EndOfStreamException exception is thrown if there are no more characters to read. 

We have provided an interface called IOutputResult into which the results of the test can be written.

We have provided two implementation classes called DeveloperTestImplementation and DeveloperTestImplementationAsync.  Please implement your answers in one of these classes.  The two classes are broadly the same; the only difference is that the …Async version is intended to be compatible with the asynchronous features offered by languages such as C# and VB.

The assessment utilizes the NUnit unit testing framework so that you can develop your solution in a TDD fashion. You should use this mechanism to ensure that your code passes the supplied unit tests.

Please answer both questions. You should write the code in C#, but you can choose another .NET language if you are more familiar with that. Your answer must compile and run. It will be judged on the assumptions you have made and the quality of your code.

Please comment your code comprehensively, listing any assumptions and non-obvious design and implementation decisions that you make.

We advise you to read both questions before starting.

1) Implement DeveloperTestImplementation.RunQuestionOne.  This method takes an ICharacterReader interface and outputs a list of word frequencies ordered by word count and then alphabetically.   Write each result to the provided implementation of IOutputResult. For example, if the stream returns “It was the best of times, it was the worst of times” then the output will be:
it - 2
of - 2
the – 2
times - 2
was - 2
best - 1
worst – 1

2) Implement DeveloperTestImplementation.RunQuestionTwo.  This method takes an array of ICharacterReader interfaces and should perform the following operations: -

a)	Access the readers in parallel and calculate the word counts split by word
b)	Every ten seconds the code should output the current combined word counts in the same format as question one
c)	When all results have been calculated, the final combined results should be written to the provided implementation of IOutputResult in the same format as question one.
 
This assessment should take no more than 1-2 hours, but don’t worry if you don’t complete it in that time. You can continue if you wish, or you can stop and let us have what you’ve got. We use the same test for all levels of software engineer from our juniors through to our senior architects and we don’t expect everyone to have the same skills. What we’re looking for is how you write code and how you solve problems.

You should include your source code and a rough indication of how long you took. Good luck!

Restrictions
You may use any features provided by the NET framework.  Please do not use any third party packages or assemblies.
Visual Studio Solutions
The solution provided is in 2017 format and uses the unit testing framework to confirm that your answers are acceptable. You can download a free version of Visual Studio Community 2017 from Microsoft that contains all the tools necessary to complete this test.

