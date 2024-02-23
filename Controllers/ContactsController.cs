using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ContactsController : Controller
{
    // Υποθέτουμε ότι έχουμε μια υπηρεσία UserService που παρέχει λειτουργικότητα για τη διαχείριση των χρηστών
    private readonly UserService _userService;

    public ContactsController(UserService userService)
    {
        _userService = userService;
    }

    // Εμφανίζει τις επαφές του χρήστη
    public IActionResult Index()
    {
        var userContacts = _userService.GetUserContacts(User.Identity.Name);
        return View(userContacts);
    }

    // Προσθήκη επαφής
    [HttpPost]
    public IActionResult AddContact(int contactId)
    {
        var userId = User.Identity.Name;
        _userService.AddContact(userId, contactId);
        return RedirectToAction(nameof(Index));
    }

    // Διαγραφή επαφής
    [HttpPost]
    public IActionResult RemoveContact(int contactId)
    {
        var userId = User.Identity.Name;
        _userService.RemoveContact(userId, contactId);
        return RedirectToAction(nameof(Index));
    }
}
