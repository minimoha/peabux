namespace PeabuxAssessment.Models
{
    public class Teacher
    {
        public long ID { get; set; }
        public string NationalIDNumber { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
