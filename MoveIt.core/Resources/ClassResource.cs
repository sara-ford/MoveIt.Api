namespace MoveIt.Core.Resources
{
    public class ClassResource
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentRegistrations { get; set; }
    }
}