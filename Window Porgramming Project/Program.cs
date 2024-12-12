namespace Window_Porgramming_Project {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("학번: 20223633    이름: 이데르잡할랑 (IDERJAVKHLAN)");
            Console.WriteLine("================= Project for Window Programming =================");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            ManagementSystem managementSystem = new ManagementSystem();
            managementSystem.Run();
        }
    }
}