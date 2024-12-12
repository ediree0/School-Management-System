namespace Window_Porgramming_Project {
    public class Student {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Gpa { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public Student(string id, string name, double gpa) {
            Id = id;
            Name = name;
            Gpa = gpa;
        }
        public void DisplayStudentInfo() {
            Console.WriteLine($"ID:\t{Id}");
            Console.WriteLine($"Name:\t{Name}");
            Console.WriteLine($"GPA:\t{Gpa:F1}");
        }
        public void ChangeId(string newId) {
            Id = newId;
            Console.WriteLine("ID changed.");
        }
        public void ChangeName(string newName) {
            Name = newName;
            Console.WriteLine("Name changed.");
        }
        public void AddLesson(string id, string name, int credit, double grade) {

            Lesson lesson = new Lesson(id, name, credit, grade);
            Lessons.Add(lesson);
        }
        public void DisplayAllLessons() {
            if (Lessons.Count == 0) {
                Console.WriteLine("No lessons found...");
                return;
            }
            int i = 0;
            foreach (Lesson lesson in Lessons) {
                Console.WriteLine($"[{i}]=========================");
                Console.WriteLine($"Lesson ID:\t{lesson.Id}");
                Console.WriteLine($"Lesson Name:\t{lesson.Name}");
                Console.WriteLine($"Lesson Credit:\t{lesson.Credit}");
                Console.WriteLine($"Lesson Grade:\t{lesson.Grade}\n");
            }
        }
        public void RemoveLessonById(string id) {
            var lesson = Lessons.Find(l => l.Id == id);
            if (lesson == null) {
                Console.WriteLine($"Lesson with the ID {id} not found");
                return;
            }
            Lessons.Remove(lesson);
            Console.WriteLine($"Lesson with the ID {id} removed");
        }
        public void CalculateGpa() {
            double totalCredits = 0;
            double totalWeightedGrades = 0;
            foreach (var lesson in Lessons) {
                totalCredits += lesson.Credit;
                totalWeightedGrades += lesson.Grade * lesson.Credit;
            }
            Gpa = totalCredits > 0 ? totalWeightedGrades / totalCredits : 0;
        }
        public bool LessonIdExists(string id) {
            var lesson = Lessons.Find(l => l.Id == id);
            if (lesson == null) return false;
            return true;
        }
    }
}
