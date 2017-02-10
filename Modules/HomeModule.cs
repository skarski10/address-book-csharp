using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contacts> allcontacts = Contact.GetAll();
        return View["index.cshtml"];
      };

      Get["/add_contact"] = _ => {
        return View["new_contact_form.cshtml"];
      };

      Post["/"] = _ => {
        Contact newContact = newContact(Request.Form)
        List<Contact> allContacts = Contact.GetAll();
        return View["/"];
      };

      Get["/contact/{id}"] = parameters => {
        Dictionay<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> contactAddresses = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("addresses", contactAddresses);
        return View["contact.cshtml"];
      };

      Get["/contact/{id}/address/new"] = parameters => {
        Dictionay<string, object> model = new Dictionay<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> allAddresses = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("address", allAddresses);
        return View["new_address_form.cshtml"];
      };

      Get["/contact/{id}/number/new"] = parameters => {
        Dictionay<string, object> model = new Dictionay<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> allNumbers = selectedContact.GetNumber();
        model.Add("contact", selectedContact);
        model.Add("address", allNumbers);
        return View["new_number_form.cshtml"];
      };

      Post["/contact"] = _ => {
        Dictionay<string, object> model = new Dictionay<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        List<Address> contactAddress = selectedContact.GetAddress();
        List<Number> contactNumber = selectedContact.GetNumber();
        string addressEntered = Request.Form["contact-address"];
        string numberEntered = Request.Form["contact-number"];
        Address newAddress = new Address(addressEntered);
        Number newNumber = new Number(numberEntered);
        contactAddress.Add(newAddress);
        contactNumber.Add(newNumber);
        model.Add("contact", selectedContact);
        model.Add("address", contactAdress);
        model.Add("number", contactNumber);
        return View["/contact"];
      };
    }
  }
}
