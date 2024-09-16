namespace Student_Managment.Aplication.Dtos;

public class CreateExamDto
{
    public DateTime ExamDate { get; set; }
    public int LessonId { get; set; }
    public int StudentId { get; set; }
}
