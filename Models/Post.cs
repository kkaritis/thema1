public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PostedAt { get; set; }
    public List<string> Categories { get; set; }
    public string UserId { get; set; } // Το Id του χρήστη που έκανε τη δημοσίευση

    // Κατασκευαστής
    public Post()
    {
        Categories = new List<string>();
    }
}
