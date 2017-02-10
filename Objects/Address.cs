using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Address
  {
    private static List<Address> _instances = new List<Address> {};
    private string _address;
    private int _id;

    public Address(string contactAddress)
    {
      _address = contactAddress;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetAddress()
    {
      return _address;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Address> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Address Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
