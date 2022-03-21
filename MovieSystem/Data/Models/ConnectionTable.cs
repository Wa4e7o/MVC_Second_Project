namespace MovieSystem.Data.Models
{
    public class ConnectionTable
    {
        // This is a connection table between Actor and Movie. Because there relation is many to many.

        public int ActorId { get; set; }
        public Actior Actior { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
