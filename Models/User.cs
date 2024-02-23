public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // Άλλα πεδία που μπορείτε να προσθέσετε όπως όνομα, επώνυμο κλπ.

    // Λίστα με τις προσωπικές επαφές του χρήστη
    public List<User> Contacts { get; set; }

    public User()
    {
        Contacts = new List<User>();
    }
}
