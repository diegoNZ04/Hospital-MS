namespace Hospital_Management.Models
{
    public class Nurse : Employee
    {
        public List<Room> Rooms { get; } = [];
    }
}