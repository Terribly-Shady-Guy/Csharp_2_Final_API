# **Details of the project:**

## **Main API data access portion prompt:**

Think of the first example as if you were working for the state of Minnesota, and
you were tasked with creating a public facing API for the for the theoretical MinnState DMV Mobile App
to make calls to.
  1. DMV and law enforcement personnel should be able to look up drivers based on name, social
  security number, license plate number.
  2. DMV personnel should be able to add new drivers and vehicles
  3. Only law enforcement service personnel should be able to add infractions to drivers
  4. Both DMV and law enforcement personnel must be authorized prior to making API calls that
  expose sensitive data.

## **Problem Solving Portion:**

The API is to have a route that solves the following problem:
Given an input of type List<KeyValuePair<string, string>> with n elements, add the values into a
Dictionary<string, string>. Note that the input will be as follows: [{“key”, “value”}, ... ]. In a list of key
value pairs, we can have ambiguous keys, however in a dictionary, we cannot have ambiguous keys. I
want the first instance of the key to be stored in the dictionary, and all future instances to not be added
to the main dictionary, but instead to another dictionary containing the key and number of instances of
that key in the input if and only if the key has showed up more than once in the target input.
List<Dictionary<string,string>> is to be returned. The first list item is to be the dictionary that contains
the parsed input, and the second list item is to be the dictionary that contains the keys that showed up
more than once, and the number of occurrences.

Solution is handled on ProblemController.cs
