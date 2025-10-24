
namespace CRUD_OOP_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //create List of objects ( Object == User)

            List<USER> users = new List<USER>();

            int choice;

            while (true)
            {

                Console.WriteLine($" 1 - Add_user \n 2 - Update_User \n 3 - Delete_User \n 4 - Print_all_users ");
                Console.WriteLine("----------------- Please Select A choice 1 , 2 , 3 or 4");
                string input = Console.ReadLine();

                //create user of the class
                USER user = new USER();
                if (int.TryParse(input, out choice))
                {
                    if (choice == 1)
                    {
                        //pass list to add data in it 
                        user.ADD_User(users);
                    }
                    else if(choice == 2)
                    {
                        user.Update_User(users);
                    }
                    else if(choice == 3)
                    {
                        user.delete_user(users);
                    }
                    else if(choice == 4 )
                    {
                        user.print_all_users(users);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice ");
                    }
                }
                else
                {
                    Console.WriteLine("------------------ Not a Valid Input ------------------------------------- ");
                }

            }
        }
    
    }
}