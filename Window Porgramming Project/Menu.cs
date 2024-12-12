namespace Window_Porgramming_Project {
    class Menu {
        public Menu() { }
        public void ShowMenu() {
            Console.WriteLine("==================== SCHOOL MANAGEMENT SYSTEM ====================");
            Console.WriteLine("1. Student Menu");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. List all Students");
            Console.WriteLine("4. Remove Student"); 
            Console.WriteLine("0. Exit\n");
            Console.Write("> ");
        }
        public void ShowStudentMenu(Student student) {
            Console.WriteLine("========================== STUDENT MENU ==========================");
            student.DisplayStudentInfo();
            Console.WriteLine();
            Console.WriteLine("1. Add lesson"); 
            Console.WriteLine("2. List all lessons"); 
            Console.WriteLine("3. Remove Lesson"); 
            Console.WriteLine("4. Edit ID");    
            Console.WriteLine("5. Edit Name"); 
            Console.WriteLine("6. Recalculate GPA");
            Console.WriteLine("0. Back\n");
            Console.Write("> ");
        }
    }
}
