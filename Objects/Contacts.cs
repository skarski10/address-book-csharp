using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private string _address;
    private int _number;
    private int _id;

    public string GetName()
    {
      return _name;
    }

    public string GetAddress()
    {
      return _address;
    }

    public int GetNumber()
    {
      return _number;
    }

    public int GetId()
    {
      return _id;
    }

    public static void Clear()
   {
     _instances.Clear();
   }

    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
