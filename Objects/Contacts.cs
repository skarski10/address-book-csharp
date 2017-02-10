using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<Address> _addresss;
    private List<Number> _numbers;

    public Contact(string contactName, string contactAddress, int contactNumber)
    {
      _name = contactName;
      _instances.Add(this);
      _id = instances.Count;
      _addresses = new List<Adress>{};
      _numbers = new List<Number>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public List<Address> GetAddress()
    {
      return _addresses;
    }
    public void AddAddress(Address adress)
    {
      _addresses.Add(address);
    }

    public List<Number> GetNumber()
    {
      return _numbers;
    }
    public void AddNumber(Number number)
    {
      _numbers.Add(number);
    }

    public static List<Contact> GetAll()
    {
      return _instances;
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
