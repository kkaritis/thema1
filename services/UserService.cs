using MVC_Project.DatabaseActions.DatabaseContent;
using System;
using System.Linq;

public interface IUserService
{
    User GetUserById(int userId);
}

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetUserById(int userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
    }

    public List<User> GetUserContacts(string username)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            return new List<User>(); // Ή εδώ μπορείτε να ρίξετε μια εξαίρεση ανάλογα με τις ανάγκες σας
        }

        var userContacts = _dbContext.Messages
            .Where(m => m.SenderId == user.Id || m.ReceiverId == user.Id)
            .SelectMany(m => new[] { m.Sender, m.Receiver })
            .Where(u => u.Id != user.Id)
            .Distinct()
            .ToList();

        return userContacts;
    }

    public void AddContact(int userId, int contactId)
    {
        // Ελέγχουμε αν οι δύο χρήστες υπάρχουν στη βάση δεδομένων
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        var contact = _dbContext.Users.FirstOrDefault(u => u.Id == contactId);

        // Αν κάποιος χρήστης δεν υπάρχει, τότε δεν μπορούμε να προσθέσουμε την επαφή
        if (user == null || contact == null)
        {
            throw new Exception("One or both users do not exist.");
        }

        // Προσθέτουμε την επαφή στον πίνακα επαφών του χρήστη
        user.Contacts.Add(contact);

        // Ενημερώνουμε τη βάση δεδομένων
        _dbContext.SaveChanges();
    }

    public void RemoveContact(int userId, int contactId)
    {
        // Ελέγχουμε αν οι δύο χρήστες υπάρχουν στη βάση δεδομένων
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        var contact = _dbContext.Users.FirstOrDefault(u => u.Id == contactId);

        // Αν κάποιος χρήστης δεν υπάρχει, τότε δεν μπορούμε να αφαιρέσουμε την επαφή
        if (user == null || contact == null)
        {
            throw new Exception("One or both users do not exist.");
        }

        // Αφαιρούμε την επαφή από τον πίνακα επαφών του χρήστη
        user.Contacts.Remove(contact);

        // Ενημερώνουμε τη βάση δεδομένων
        _dbContext.SaveChanges();
    }



}
