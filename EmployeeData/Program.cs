namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User should Enter unique name and ID 
          
            Console.WriteLine("Main Menu : \n1. Add Person \n2. View Person By ID \n3. View Person By Name \n4. Print All \n5. Delete Person By ID \n6. Delete All "+
                "\n7. Edit Person \n8 - Exit ");
          
       
            bool exit = false;
            while (!exit)
            {
                Person person = new Person();
                int option = 0;
                Console.WriteLine("Select an option: ");
                while (!int.TryParse(Console.ReadLine(), out option) || option > 8 || option < 1)
                {
                    Console.WriteLine("Enter a valid option ");
                }
                if (option == 1)
                {
                    person.Add_person();
                }
                else if (option == 2)
                {

                    person.view_person_by_ID();
                }
                else if (option == 3)
                {
                    person.view_person_by_name();
                }
                else if (option == 4)
                {
                    person.print_all_users();
                }
                else if (option == 5)
                {
                    person.delete_user_by_id();
                }
                else if (option == 6)
                {
                    person.delete_all();
                }
                else if (option == 7)
                {
                    person.edit_person();
                }
                else if (option == 8)
                {
                    exit = true;
                }
            }
         
        }
    }
}
