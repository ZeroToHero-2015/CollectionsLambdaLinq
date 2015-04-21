Collections
============

1. Yield
--------

* Used inside a **method** or a **get** statement.
* Allows returning an **iterator** (which can be iterated step by step)
  without the need for an additional class to handle the enumeration.
* Syntax:

  ```csharp
  yield return valueToReturn;
  ```
* When execution reaches an **yield** statement, the current value of
  the iterator is returned, and the iterator state is memorized.
  When the method is called again, the next element is returned.
* **Iterators** can be iterated using a **foreach** loop.
* More info: [yield](https://msdn.microsoft.com/en-us/library/9k7k7cf0.aspx),
  [iterators](https://msdn.microsoft.com/en-us/library/dscyy5s0.aspx)


2. IEnumerator&lt;T&gt;, IEnumerable&lt;T&gt;
--------

### 2.1 IEnumerator&lt;T&gt; ###
* The **IEnumerator&lt;T&gt;** interface has properties and methods for
  enumerating a collection of T elements.
* Properties:

  ```csharp
  //Returns the element at the current position in the collection
  T Current { get; }
  ```
* Methods:

  ```csharp
  //Advances the current position to the next element. Returns "true" if the
  //position was advanced, "false" if there is no next element.
  bool MoveNext()
  ```

  ```csharp
  //Sets the enumerator position to -1 (initial position)
  void Reset()
  ```
* Any changes made to the collection while it is enumerated invalidate the
  current enumerator and cause an exception to be thrown when calling MoveNext or Reset.
* More info: [IEnumerator&lt;T&gt;](https://msdn.microsoft.com/en-us/library/78dfe2yb.aspx)

###2.2 IEnumerable&lt;T&gt;###
* Exposes an **enumerator** to iterate over a collection of T.
* Collections that implement **IEnumerable<T>** can be enumerated by
  using the **foreach** statement.
* Methods:

  ```csharp
  //Returns the enumerator for iterating the list
  IEnumerator<T> GetEnumerator()
  ```
* More info: [IEnumerable&lt;T&gt;](https://msdn.microsoft.com/en-us/library/9eekhta0.aspx)


3. Collection&lt;T&gt;
--------
* Base class for generic collections.
* **Main use: Does not have a lot of implemented functionalities, but offers possibilities for
  customization via overriding basic methods in subclasses.**
* Items can be accessed using the built-in [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
* More info, properties and methods: [Collection&lt;T&gt;](https://msdn.microsoft.com/en-us/library/ms132397%28v=vs.110%29.aspx)


4. List&lt;T&gt;
--------
* Provides methods to search, sort, and manipulate lists.
* Items can be accessed using the [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
* **Main use: Not suitable for customizing and extending; but performs better than most generic collections
  and contains a lot of build-in functionalities such as search, sort and list operations.**
* Can be sorted using a custom **[Comparer&lt;T&gt;](https://msdn.microsoft.com/en-us/library/8ehhxeaf.aspx)**,
  or without one, if the items implement **[IComparable](https://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx)**
* More info, properties and methods: [List&lt;T&gt;](https://msdn.microsoft.com/en-us/library/6sh2ey19.aspx)


5. Dictionary&lt;TKey, TValue&gt;
--------
* A collection of **unique** keys and values corresponding to those keys.
* Each element in the Dictionary is a [KeyValuePair&lt;TKey, TValue&gt;](https://msdn.microsoft.com/en-us/library/5tbh8a42%28v=vs.110%29.aspx)
  struct.
* Values can be retrieved using the keys, similarly to using an [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
  Example:

  ```csharp
  var valueToGet = dictionary[key];
  ```
* **Main use: Storing values that need to be retrieved quickly based on a key. Retrieving a
  value using the key is very fast, because the Dictionary is implemented as a hash table
  (search speed depends on the hashing algorithm of the TKey type).**
* Key and value lists can be iterated through independently, each list being a generic IEnumerable.
* Adding an existing key, or trying to retrieve the value of a key that is not present in the
  Dictionary will result in an **Exception** being thrown.
* More info, properties and methods: [Dictionary&lt;TKey, TValue&gt;](https://msdn.microsoft.com/en-us/library/xfhwa508.aspx)


Collections - Extra (for home)
--------
1. Add an [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx) to the `BandsEnumerable`
   class and print the items using the index.
2. Implement the [IComparable](https://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx)
   interface in the `Band` class. Sort a List&lt;Band&gt;, so you get the same result as when
   using the `BasicBandsComparer`, but without using a Comparer (you will make use of the parameterless
   Sort() method of the list).
3. Any leftover //TODOs from the project.


--------
Lambda Expressions, Delegates and Anonymous Functions
===================

##Delegates
###What is a Delegate?
* A **delegate** is a type which  holds the method(s) reference in an object.
* A **delegate** is a type that represents references to methods with a particular parameter list and return type.
* A type safe function pointer. (similar with C/C++ function pointers, but type safe)

###Syntax
``` csharp
public delegate double PerformCalculation(double x, double y);
```

###When do you use a delegate?
* **Delegates** are used to pass methods as arguments to other methods.
* You can use it as a callback to an event.

###How do you create it?
* In order to create a delegate you can associate its instance with any method with a compatible signature and return type.

###Advantages
* Encapsulating the method's call from caller
* Used to call a method asynchronously
* Dynamic binding

###Example
```csharp
public delegate double PerformCalculation(double val1, double val2);
class DelegateExample
{
  static double fn_Sum(double val1, double val2)
  {
      return val1 + val2;
  }

  static double fn_Product(double val1, double val2)
  {
      return val1 * val2;
  }

  static void ExecuteFunction(PerformCalculation function, double param1, double param2)
  {
      double result = function(param1, param2);
      Console.WriteLine(result);
  }

  static void Main(string[] args)
  {
      // Create Delegate instances
      PerformCalculation sum_Function = new PerformCalculation(fn_Sum);
      PerformCalculation prod_Function = new PerformCalculation(fn_Product);

      double val1 = 2.0, val2 = 3.0;

      //Call sum function
      double sum_result = sum_Function(val1, val2);
      Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

      //Call product function
      double prod_result = prod_Function(val1, val2);
      Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

      //Using sum_function reference
      Console.Write("{0} + {1} = ", val1, val2);
      ExecuteFunction(sum_Function, val1, val2);

      //Using product_function reference
      Console.Write("{0} * {1} = ", val1, val2);
      ExecuteFunction(prod_Function, val1, val2);
  }
}
```
-------
##Func Delegates
* Encapsulates a method that has N parameters  (N from [0, 16]) and **returns a value** of a specific type

###Syntax
``` csharp
/**
 * Syntax of a Func delegate which has two parameters
 * @in T1 : type of the first parameter
 * @in T2: type of the second parameter
 * @out TResult: type of the return value of the method
 */

public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
```

###Advantage
* You don't have to declare the signature of the delegate.
* There is no need to explicitly create a **Func** delegate instance (you can just pass the method name, and the compiler will bind it dynamically).

###Example
```csharp
class FuncDelegateExample
{
    static double fn_Sum(double val1, double val2)
    {
        return val1 + val2;
    }

    static double fn_Product(double val1, double val2)
    {
        return val1 * val2;
    }

    static double fn_Diff(double val1, double val2)
    {
        return val1 - val2;
    }

    static void ExecuteFunctionUsingFunc(Func<double, double, double> function, double param1, double param2)
    {
        double result = function(param1, param2);
        Console.WriteLine(result);
    }

    static void Main(string[] args)
    {
        //Create Func Delegate instances
        Func<double, double, double> sum_Function = new Func<double, double, double>(fn_Sum);
        Func<double, double, double> prod_Function = new Func<double, double, double>(fn_Product);

        double val1 = 2.0, val2 = 3.0;

        //Call sum function
        double sum_result = sum_Function(val1, val2);
        Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

        //Call product function
        double prod_result = prod_Function(val1, val2);
        Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

        //Using sum_function reference
        Console.Write("{0} + {1} = ", val1, val2);
        ExecuteFunctionUsingFunc(sum_Function, val1, val2);

        //Using product_function reference
        Console.Write("{0} * {1} = ", val1, val2);
        ExecuteFunctionUsingFunc(prod_Function, val1, val2);

        //Omitting the explicit creation of Func instance
        Console.Write("{0} - {1} = ", val1, val2);
        ExecuteFunctionUsingFunc(fn_Diff, val1, val2);
    }
}
```

----------

##Action Delegates
* Similar with Func delegate but it **does not return a value**.

###Syntax
``` csharp
/**
 * Syntax of a Action delegate which has two parameters
 * @in T1 : type of the first parameter
 * @in T2: type of the second parameter
 */

public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
```

---------
##Anonymous functions
* Anonymous methods let you declare a method body without giving it a name.
* Can be used to pass a code block as a delegate parameter.
* Cannot be called explicitly.
* Anonymous methods enable you to omit the parameter list.

###Syntax
```csharp
delegate(in T1, in T2)
{
  //code block
}
```

###Usage
```csharp
Function<double, double, double> maxFunction = delegate(double var1, double var2)
                                              {
                                                if (var1 > var2)
                                                  return var1;
                                                else
                                                  return var2;
                                              }
```
###Advantage
* Reduce the coding overhead in instantiating delegates (you don't have to create a separate method).
* Are more flexible than lambda expressions.

###Example
```csharp
public delegate double PerformCalculation(double val1, double val2);
class AnonymousExample
{
    static void ExecuteFunctionUsingFunc(Func<double, double, double> function, double param1, double param2)
    {
        double result = function(param1, param2);
        Console.WriteLine(result);
    }

    static void ExecuteFunction(PerformCalculation function, double param1, double param2)
    {
        double result = function(param1, param2);
        Console.WriteLine(result);
    }

    static void Main(string[] args)
        //Create a Func Delegate instance
        Func<double, double, double> sum_Function = delegate(double var1, double var2)
                                                    {
                                                      return var1 + var2;
                                                    };

        //Create a Delegate instance
        PerformCalculation prod_Function = delegate(double var1, double var2)
                                            {
                                                return var1 * var2;
                                            };

        double val1 = 1.0, val2 = 5.0;

        //Call sum function
        double sum_result = sum_Function(val1, val2);
        Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

        //Call product function
        double prod_result = prod_Function(val1, val2);
        Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

        //Using sum_function reference
        Console.Write("{0} + {1} = ", val1, val2);
        ExecuteFunctionUsingFunc(sum_Function, val1, val2);

        //Using product_function reference
        Console.Write("{0} * {1} = ", val1, val2);
        ExecuteFunction(prod_Function, val1, val2);
    }
}
```
