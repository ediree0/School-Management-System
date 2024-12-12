namespace Window_Porgramming_Project {
    public class Lesson {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public double Grade { get; set; }
        public Lesson(string id, string name, int credit, double grade) {
            Id = id;
            Name = name;
            Credit = credit;
            Grade = grade;
        }
    }
}
