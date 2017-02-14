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
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Get["/add_contact"] = _ => {
        return View["new_contact_form.cshtml"];
      };

      Post["/"] = _ => {
        Contact newContact = new Contact(Request.Form["contact-name"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Get["/contact/{id}"] = parameters => {
//         Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
//         List<Address> contactAddresses = selectedContact.GetAddress();
//         List<Number> contactNumber = selectedContact.GetNumber();
//         model.Add("contact", selectedContact);
//         model.Add("address", contactAddresses);
//         model.Add("number", contactNumber);
        return View["contact.cshtml", selectedContact];
      };

      Get["/contact/{id}/address/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> allAddresses = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("address", allAddresses);
        return View["new_address_form.cshtml", model];
      };
      Get["/contact/{id}/number/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Number> allNumbers = selectedContact.GetNumber();
        model.Add("contact", selectedContact);
        model.Add("number", allNumbers);
        return View["new_number_form.cshtml", model];
      };

//       Post["/contact"] = _ => {
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
//         List<Address> contactAddress = selectedContact.GetAddress();
//         string addressEntered = Request.Form["contact-address"];
//         Address newAddress = new Address(addressEntered);
//         contactAddress.Add(newAddress);
//         model.Add("contact", selectedContact);
//         model.Add("address", contactAddress);
//         return View["contact.cshtml", model];
//       };

//       Get["/contact/numbers"] = _ => {
//         List<Number> allNumbers = Number.GetAll();
//         return View["contact_number.cshtml", allNumbers];
//       };
      Post["/contact"] = _ => {
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        List<Address> contactAddress = selectedContact.GetAddress();
        List<Number> contactNumber = selectedContact.GetNumber();
        string addressEntered = Request.Form["contact-address"];
        string numberEntered = Request.Form["contact-number"];
        Address newAddress = new Address(addressEntered);
        Number newNumber = new Number(numberEntered);
        contactAddress.Add(newAddress);
        contactNumber.Add(newNumber);
        return View["contact.cshtml", selectedContact];
      };
    }
  }
}
