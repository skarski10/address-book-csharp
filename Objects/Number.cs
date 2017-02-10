using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Number
  {
    private static List<Number> _instances = new List<Number> {};
    private int _number;
    private int _id;

    public Number(int contactNumber)
    {
      _number = contactNumber;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public int GetNumber()
    {
      return _number;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Number> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Number Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
