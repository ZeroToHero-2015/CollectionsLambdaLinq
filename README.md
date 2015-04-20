1. Yield
============

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
============

### 2.1 IEnumerator&lt;T&gt; ###
* The **IEnumerator&lt;T&gt;** interface has properties and methods for
  enumerating a collection of T elements.
* Properties:

  ```
  T Current { get; }
  //Returns the element at the current position in the collection
  ```
* Methods:

  ```
  bool MoveNext()
  //Advances the current position to the next element. Returns "true" if the
  //position was advanced, "false" if there is no next element.
  ```

  ```
  void Reset()
  //Sets the enumerator position to -1 (initial position)
  ```
* Any changes made to the collection while it is enumerated invalidate the
  current enumerator and cause an exception to be thrown when calling MoveNext or Reset.
* More info: [IEnumerator&lt;T&gt;](https://msdn.microsoft.com/en-us/library/78dfe2yb.aspx)

###2.2 IEnumerable&lt;T&gt;###
* Exposes an **enumerator** to iterate over a collection of T.
* Collections that implement **IEnumerable<T>** can be enumerated by
  using the **foreach** statement.
* Methods:

  ```
  IEnumerator<T> GetEnumerator()
  //Returns the enumerator for iterating the list
  ```
* More info: [IEnumerable&lt;T&gt;](https://msdn.microsoft.com/en-us/library/9eekhta0.aspx)


3. Collection&lt;T&gt;
============
* Base class for generic collections.
* **Main use: Does not have a lot of implemented functionalities, but offers possibilities for
  customization via overriding basic methods in subclasses.**
* Items can be accessed using the built-in [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
* More info, properties and methods: [Collection&lt;T&gt;](https://msdn.microsoft.com/en-us/library/ms132397%28v=vs.110%29.aspx)


4. List&lt;T&gt;
============
* Provides methods to search, sort, and manipulate lists.
* Items can be accessed using the [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
* **Main use: Not suitable for customizing and extending; but performs better than most generic collections
  and contains a lot of build-in functionalities such as search, sort and list operations.**
* Can be sorted using a custom **[Comparer&lt;T&gt;](https://msdn.microsoft.com/en-us/library/8ehhxeaf.aspx)**,
  or without one, if the items implement **[IComparable](https://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx)**
* More info, properties and methods: [List&lt;T&gt;](https://msdn.microsoft.com/en-us/library/6sh2ey19.aspx)


5. Dictionary&lt;TKey, TValue&gt;
============
* A collection of **unique** keys and values corresponding to those keys.
* Each element in the Dictionary is a [KeyValuePair&lt;TKey, TValue&gt;](https://msdn.microsoft.com/en-us/library/5tbh8a42%28v=vs.110%29.aspx)
  struct.
* Values can be retrieved using the keys, simalrly to using an [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx).
  Example:
  
  ```
  var valueToGet = dictionary[key];
  ```
* **Main use: Storing values that need to be retrieved quickly based on a key. Retrieving a
  value using the key is very fast, because the Dictionary is implemented as a hash table
  (search speed depends on the hashing algorithm of the TKey type).**
* Key and value lists can be iterated through independently, each list being a generic IEnumerable.
* Adding an existing key, or trying to retrieve the value of a key that is not present in the
  Dictionary will result in an **Exception** being thrown.
* More info, properties and methods: [Dictionary&lt;TKey, TValue&gt;](https://msdn.microsoft.com/en-us/library/xfhwa508.aspx)


Extra (for home)
============
1. Add an [indexer](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx) to the `BandsEnumerable`
   class and print the items using the index.
2. Implement the [IComparable](https://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx)
   interface in the `Band` class. Sort a List&lt;Band&gt;, so you get the same result as when
   using the `BasicBandsComparer`, but without using a Comparer (you will make use of the parameterless
   Sort() method of the list).
