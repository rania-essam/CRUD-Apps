
using System;

namespace ConsoleApp2
{
  
    internal class Person
    {
        static int counter = 1; // for unique id
        static Dictionary<string, int> names = new Dictionary<string, int>(); // to ensure that names is unique
        static Dictionary<int, int> ID_exist = new Dictionary<int, int>();
        static List<Person> persons = new List<Person>(); // to store all persons 

        // ----------------------- [ All data of person ]--------------------------------------
        public int ID;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set // validate that the name consists of aplphapetic-chars 
            {
                bool valid = false;
                while (!valid)
                {
                    
                    int i;
                    for( i = 0; i < (int)value.Length; i++)
                    {
                        if (value[i] >= 'a' && value[i] <= 'z' || value[i] >= 'A' && value[i] <= 'Z') continue;
                        else break;
                    }
                    
                    if (i == (int)value.Length )
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter valid Value");
                        value = Console.ReadLine();
                    }
                }

                name = value;
            }
        }
        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                bool valid = false;
                while (!valid)
                {

                    int i;
                    for (i = 0; i < (int)value.Length; i++)
                    {
                        if (value[i] >= 'a' && value[i] <= 'z' || value[i] >= 'A' && value[i] <= 'Z') continue;
                        else break;
                    }
                    if (i == (int)value.Length)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter valid Value");
                        value = Console.ReadLine();
                    }
                }
                city = value;
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                bool valid = false;
                if (age >= 1 && age <= 100)
                {
                    age = value;
                }
                int urage = 0;
                while (value < 1 || value > 100) // to validate that range of age is correct 
                {
                    Console.WriteLine("Please Enter a valid Age ");
                    int.TryParse(Console.ReadLine(), out value);
                }
                age = value;
                
            }
        }
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                bool find = false;
                while (!find)
                {
                    int i;
                    for (i = 0; i < value.Length; i++)
                    {
                        if (value[i] >= '0' && value[i] <= '9') continue;
                        else break;
                    }
                    if (i == value.Length) find = true;
                    else
                    {
                        Console.WriteLine("PLease Enter a valid Phone number ");
                        value = Console.ReadLine();
                    }
                    phone = value;
                }
            }
        }
    

        //------------------------------------[ Adding new person]----------------------------------------
        public void Add_person()
        {


            Console.WriteLine("==========================================  Adding person  ====================================================");
            this.ID = counter; // ID 
            ID_exist[counter] = 1;
            Console.WriteLine("Enter your Info ");
            Console.WriteLine("1 -  Name : ");
            string Namee = Console.ReadLine();
          
            while (names.ContainsKey(Namee))
            {
                Console.WriteLine("Value should be unique please enter another value : ");
                Namee = Console.ReadLine();
            }
            this.Name = Namee;
            names[Namee] = 1; // unique names
            //-----------------------------------------------------
            Console.WriteLine("2 - Age");
            int ur_age;
            while (!int.TryParse(Console.ReadLine(), out ur_age)) // to validate that the input is string that can be converted to int
            {
                Console.WriteLine("Please Enter A valid value");
            }
            this.Age = ur_age;
            //--------------------------------------------------------
            Console.WriteLine("3 - City  ");
            this.City = Console.ReadLine();
            //------------------------------------------------------
            Console.WriteLine("4 - phone ");
            this.Phone = Console.ReadLine();

            Console.WriteLine($"--------------- Your Unique ID : {counter++} -------------------------------");
            Console.WriteLine($"=============================================================================");

            persons.Add(this);
        }

        //--------------------------------- [ Show data ] ----------------------------------------
        public void view_person_by_ID()
        {
            Console.WriteLine("Please Enter ID of person you want to view ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) && !ID_exist.ContainsKey(id))
            {
                Console.WriteLine(" Enter a valid number ");

            }
            
            Person person = persons.FirstOrDefault(ob => ob.ID == id);
            Console.WriteLine(person.ID);
            
            Console.WriteLine($"============================== Data of User {person.ID} ============================= ");
            Console.WriteLine($"1 - Name : {person.Name} ");
            Console.WriteLine($"2 - Age  : {person.Age} ");
            Console.WriteLine($"3 - City : {person.City} ");
            Console.WriteLine($"4 - Phone : {person.Phone} ");
        }

     
       public  void view_person_by_name()
        {
            Console.WriteLine("Please Enter Name of person you want to view ");
            string name = Console.ReadLine();
            while (!names.ContainsKey(name))
            {
                Console.WriteLine(" Enter a valid number ");
                name = Console.ReadLine();

            }
            Person person = persons.FirstOrDefault(p => p.Name  == name );

            Console.WriteLine($"============================== Data of User {person.ID}  ============================= ");
            Console.WriteLine($"1 - Name : {person.Name} ");
            Console.WriteLine($"2 - Age  : {person.Age} ");
            Console.WriteLine($"3 - City : {person.City} ");
            Console.WriteLine($"4 - Phone : {person.Phone} ");
        }
        public void view_person()
        {
            Console.WriteLine($"============================== Data of User {this.ID}  ============================= ");
            Console.WriteLine($"1 - Name : {this.Name} ");
            Console.WriteLine($"1 - Age  : {this.Age} ");
            Console.WriteLine($"1 - City : {this.City} ");
            Console.WriteLine($"1 - Phone : {this.Phone} ");
        }
        public void print_all_users()
        {
            foreach (Person person in persons) person.view_person();
        }
        //--------------------------------[ Delete ] ----------------------------------
        public void delete_user_by_id()
        {
            Console.WriteLine("Please Enter ID of person you want to Delete");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) && !ID_exist.ContainsKey(id))
            {
                Console.WriteLine(" Enter a valid number ");

            }
            Person person = persons.FirstOrDefault(p => p.ID == id);
            persons.Remove(person);
               
          
        }
        public void delete_user_by_name()
        {
            Console.WriteLine("Please Enter Name of person you want to Delete ");
            string namee = Console.ReadLine();
            while (!names.ContainsKey(namee))
            {
                Console.WriteLine(" Enter a valid number ");
                namee = Console.ReadLine();

            }
            Person person = persons.FirstOrDefault(p => p.Name == namee);
            persons.Remove(person);
        }
        public void delete_all()
        {
            persons.Clear();
            Console.WriteLine("All Data Removed . ");
        }

        //---------------------------- [Edit ] --------------------------------
        
        public void edit_person()
        {
            Console.WriteLine("Please Enter ID of person you want to edit ");
            int id = 0;
            while(!int.TryParse(Console.ReadLine(), out id) && !ID_exist.ContainsKey(id))
            {
                Console.WriteLine(" Enter a valid number ");
                
            }
            Person p = persons.FirstOrDefault(p => p.ID == id);

            Console.WriteLine("1 - Name , 2 - Age , 3 - City , 4 - Phone ");
            Console.WriteLine(" Select the item you want to edit ");
            int option;
            while(!int.TryParse(Console.ReadLine(), out option ) || option < 1 || option > 4)
            {
                Console.WriteLine("Please  Enter a valid Option ");
            }
          
            if (option == 1) 
            {
                Console.WriteLine("Enter the New_Name");
                string Namee = Console.ReadLine();

                while (names.ContainsKey(Namee))
                {
                    Console.WriteLine("Value should be unique please enter another value : ");
                    Namee = Console.ReadLine();
                }
                p.Name = Namee;
            }
            else if(option == 2)
            {
                Console.WriteLine("Enter the New_Age");
                int ur_age;
                while (!int.TryParse(Console.ReadLine(), out ur_age)) // to validate that the input is string that can be converted to int
                {
                    Console.WriteLine("Please Enter A valid value");
                }
                p.Age = ur_age;
            }
            else if(option == 3)
            {
                Console.WriteLine("Enter the New_City");
                p.City = Console.ReadLine();
            }
            else if(option == 4)
            {
                Console.WriteLine("Enter the New_Phone");
                p.phone = Console.ReadLine();
            }

        }
     
        
    


      


    }
}
