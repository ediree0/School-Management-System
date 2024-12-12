using System.Text.Json;

namespace Window_Porgramming_Project {
    class ManagementSystem {
        private string input;
        private readonly string studentsfilepath = "./students.json";
        private List<Student> students;
        private Menu menu = new();
        public ManagementSystem() { }
        public void Run() {
            students = LoadStudentsFromJsonFile(studentsfilepath);
            bool exit = false;
            while (exit == false) {
                Console.Clear();
                menu.ShowMenu();
                input = Console.ReadLine();
                switch (input) {
                    case ("1"):
                        StudentMenu();
                        break;
                    case ("2"):
                        AddStudent();
                        break;
                    case ("3"):
                        ListAllStudents();
                        break;
                    case ("4"):
                        RemoveStudent();
                        break;
                    case ("0"):
                        SaveStudentsToJsonFile(students, studentsfilepath);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void SaveStudentsToJsonFile(List<Student> students, string filePath) {
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
        private List<Student> LoadStudentsFromJsonFile(string filePath) {
            if (File.Exists(filePath)) {
                string jsonString = File.ReadAllText(filePath);
                List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonString);
                return students;
            }
            else {
                Console.WriteLine("File not found.");
                return new List<Student>();
            }
        }
        private void AddStudent() {
            Console.WriteLine("======================= Adding new student =======================");

            Console.Write("Enter ID: ");
            string id = Console.ReadLine();

            if (StudentIdExists(id)) {
                Console.WriteLine($"Student with the same id {id} already exist. Try different ID");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Student student = new Student(id, name, 0);
            students.Add(student);
            student.DisplayStudentInfo();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ListAllStudents() {
            if (students.Count == 0) {
                Console.WriteLine("There is no student");
            }
            else {
                int i = 0;
                foreach (Student student in students) {
                    Console.WriteLine($"[{i}]=========================");
                    student.DisplayStudentInfo();
                    Console.WriteLine();
                    i++;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void RemoveStudent() {
            if (students.Count == 0) {
                Console.WriteLine("There is no student");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter your student ID of the student to remove: ");
            string studentId = Console.ReadLine();
            var student = students.Find(s => s.Id == studentId);
            if (student == null) {
                Console.WriteLine($"There is no student with the ID {studentId}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else {
                students.Remove(student);
                Console.WriteLine("Student Removed...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private bool StudentIdExists(string id) {
            var student = students.Find(s => s.Id == id);
            if (student == null) return false;
            return true;
        }
        private void StudentMenu() {
            if (students.Count == 0) {
                Console.WriteLine("There is no student");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            bool exit = false;
            Console.Write("Enter your student ID: ");
            string studentId = Console.ReadLine();
            var student = students.Find(s => s.Id == studentId);
            if (student == null) {
                exit = true;
                Console.WriteLine($"There is no student with the ID {studentId}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            while (exit == false) {
                Console.Clear();
                menu.ShowStudentMenu(student);
                input = Console.ReadLine();
                switch (input) {
                    case ("1"):
                        AddLesson(student);
                        break;
                    case ("2"):
                        student.DisplayAllLessons();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case ("3"):
                        RemoveLesson(student);
                        break;
                    case ("4"):
                        EditStudentId(student);
                        break;
                    case ("5"):
                        EditStudentName(student);
                        break;
                    case ("6"):
                        student.CalculateGpa();
                        break;
                    case ("0"):
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddLesson(Student student) {
            Console.WriteLine("======================= Adding new lesson ========================");

            Console.Write("Enter Lesson ID: ");
            string id = Console.ReadLine();

            if (student.LessonIdExists(id)) {
                Console.WriteLine($"Lesson with the ID {id} already exist");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Lesson name: ");
            string name = Console.ReadLine();
            try {
                Console.Write("Enter Lesson credit: ");
                int credit = int.Parse(Console.ReadLine());
                Console.Write("Enter Lesson grade: ");
                double grade = double.Parse(Console.ReadLine());

                student.AddLesson(id, name, credit, grade);

                Console.WriteLine("Lesson added...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e) {
                Console.WriteLine("Error Occured.");
            }
        }
        private void RemoveLesson(Student student) {
            Console.WriteLine("======================== Removing lesson =========================");

            Console.Write("Enter Lesson ID to remove: ");
            string id = Console.ReadLine();
            student.RemoveLessonById(id);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void EditStudentId(Student student) {
            Console.WriteLine("========================== Editing Name ===========================");
            Console.Write("Enter new ID: ");
            string id = Console.ReadLine();

            if (StudentIdExists(id)) {
                Console.WriteLine($"Student with the same id {id} already exist. Try different ID");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            student.ChangeId(id);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void EditStudentName(Student student) {
            Console.WriteLine("=========================== Editing ID ============================");
            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            student.ChangeName(name);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
