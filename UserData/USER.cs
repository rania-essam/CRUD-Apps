using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_OOP_project
{
    internal class USER
    {
        // create properties to take inputs from user 

        public string Name{ get;  set; }
        public string Email { get; set; }
        public string phonenumber { get; set; }


        public void ADD_User(List<USER>list)
        {
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Email : ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone_number : ");
            string Phone_number = Console.ReadLine();



            //initialize an object by using object intializer 
            USER ob = new USER
            {
                Name = name,
                Email = email,
                phonenumber = Phone_number
            };

            list.Add(ob);

            Console.WriteLine($" Information You Intered ");
            Console.WriteLine($" name : {ob.Name} \nemail : {ob.Email} \nphone_number : {ob.phonenumber}");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
        public void Update_User(List<USER>list)
        {

            Console.WriteLine("PLease Enter the Phone_number of person that you want to UPdate ");
            string phone_number = Console.ReadLine();
            //check if this phone_number exist in any object of the list or not
            //and if the digit exists  return the object with  this number
            USER founduser = list.FirstOrDefault(ob => ob.phonenumber == phone_number);
            bool found = false;
            if(founduser != null)
            {
                
                Console.WriteLine($"1-Edit Name \n2-Edit Email \n3- Edit Phone_number ");
                int choice;
                string num = Console.ReadLine();
                if(int.TryParse(num,out choice))
                {
                    if(choice==1)
                    {
                        found = true;
                        Console.WriteLine("Enter The new_name ");
                        string new_name = Console.ReadLine();
                        founduser.Name = new_name;

                    }
                    else if (choice == 2)
                    {
                        found = true;
                        Console.WriteLine("Enter The new_Email");
                        string new_email = Console.ReadLine();
                        founduser.Email = new_email;
                    }
                    else if(choice==3)
                    {
                        found = true;
                        Console.WriteLine("Enter The new_phonenumber");
                        string new_phonenumber = Console.ReadLine();
                        founduser.phonenumber = new_phonenumber;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice  ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input ");
                }
            }
            else
            {
                Console.WriteLine("There is no user Like this ");
            }
            if (found)
            {
                Console.WriteLine("-------------------------- User’s Data After Editing -------------------------------- ");
                Console.WriteLine($" name : {founduser.Name} \nEmail: {founduser.Email} \nPhone_number : {founduser.phonenumber} ");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");


        }
        public void delete_user(List<USER>list)
        {
            Console.WriteLine("Please enter the phone_number of the person that you want to delete ");
            string num = Console.ReadLine();
            USER FoundUser=  list.FirstOrDefault(x=>x.phonenumber==num);
            if (FoundUser != null)
            {
                string name = FoundUser.Name;
                list.Remove(FoundUser);
                Console.WriteLine($"You deleted user with name {name}");
            }
            else Console.WriteLine("There is no user by this number ");
        }
        public void print_all_users(List<USER>list)
        {
            if(list.Count==0)
            {
                Console.WriteLine("------------------------------ No users to print ---------------------- ");
            }
            else
            {
                Console.WriteLine(" ---------------------------- Data of all users ------------------------- ");
            }
            int cnt = 0;
            foreach(var ob in list)
            {
                cnt++;
                Console.WriteLine($"USER {cnt} \nUser’s Name : {ob.Name} \nUser’s Email : {ob.Email} \nUser’s phone_number : {ob.phonenumber}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");

        }

    }
}
