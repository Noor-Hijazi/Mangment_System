using System.Threading.Channels;

namespace MangmentSystem
{
  
        public class Mangement
        {
            public List<Person> users;

            public Mangement()
            {
                users = new List<Person>();

                //call a function to get the first sceen
                FirstScreen();
            }


            public void FirstScreen()
            {
            string[] menuOptions = new string[]
               {
                    "Print all users",
                    "Add user",
                    "Edit user",
                    "Search user",
                    "Remove user",
                    "Exit",
               };
                Console.WriteLine("Welcome To Users Mangement System! \n");
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(i+1 +". "+menuOptions[i]);
                }

                Console.Write("Enter your menu option: ");
                bool converted = int.TryParse(Console.ReadLine(), out int option);

                if (converted)
                {
                //if number
                if (option == 1)
                {
                    PrintAll();
                }
                else if (option == 2)
                {
                    AddUser();
                }
                else if (option == 3)
                {
                    EditUser();
                }
                else if (option == 4)
                {
                    SearchUser();
                }
                else if (option == 5)
                {
                    RemoveUser();
                }
   
                if (option >= 1 && option <= menuOptions.Length - 1)
                {
                    FirstScreen();
                }
                else if (option != menuOptions.Length )
                {
                    OutputMessage("Incorrect menu choice.");
                    FirstScreen();
                }

            }
            else
                {
                    OutputMessage("Incorrect menu choice.");
                    FirstScreen();
                }

           
                
            }
  
            private void PrintAll()
            {
                StartOption("Prenting all users: ");
               if(!IsUsersEmpty()) {
                PrintingAllUsers();
                ReturnToMenu();
                }
                //using delegate
                /*users.ForEach(delegate (Person person)
                {
                    Console.WriteLine(person.ToString());

                });
            //Simple way 
            /* foreach (var person in users)
             {
                 Console.WriteLine(person.ToString());
             }*/

            //or using lamba
 
                }

            private void AddUser()
            {
                StartOption("Adding a user: ");
                var person = ReturnUser();
                if (person != null) { 
                    users.Add(person);
                    Console.WriteLine($"{Environment.NewLine}The user addition successfully with these information.");
                    //return to the menu if added the user successfully
                    ReturnToMenu();
            }
                else
                    AddUser(); 
            }

        
            private void EditUser()
            {
            //Print All users
            //input indexselection
            //edite user , seccseful message
            //go back to menu
                StartOption("Editing a user: ");

                if (!IsUsersEmpty()) {
                    PrintingAllUsers();
                    Console.Write("\nEnter index of user:");
                
                    try {
                        var indexselction = Convert.ToInt32(Console.ReadLine());
                        indexselction--;
                        if (indexselction >= 0 && indexselction <= users.Count - 1)
                        {
                            users[indexselction] = ReturnUser();
                            Console.WriteLine("Successful Edited");
                            ReturnToMenu();
                        }
                        else
                        {
                            OutputMessage("Enter a valid index.");
                            EditUser();
                        }
                        
                    }
                    catch
                    {
                        Console.WriteLine("Somthing went wrong!");
                        Thread.Sleep(1000);
                        EditUser();
                    }
            }
        }
    

            private void RemoveUser()
            {
            //check if there are users 
            //printing all users
            //input selection => index
            //selection validate => index
            //print message 
            //go back to menu

            StartOption("Removing a user");

            if (!IsUsersEmpty()) {
                PrintingAllUsers();
                Console.Write("Enter the number of user: ");
                try { 
                     var index = Convert.ToInt32(Console.ReadLine());
                    index--;
                    //     lower bound     upper bound
                    if (index >= 0 && index<=users.Count -1)
                    {
                        users.RemoveAt(index);
                        Console.WriteLine("Successful Removed");
                        ReturnToMenu();
                    }
                    else
                    {
                        OutputMessage("Enter a valid number.");
                        RemoveUser();
                    }
                }
                catch
                {
                    OutputMessage("Enter a valid number.");
                    RemoveUser();
                }
            }
            }

      
            private void SearchUser()
            {
            //check if the person in users
            //get name input => not equal null
            //loop to get the person in list 
            //output result
            //go back to menu

                StartOption("Search about the user by name: ");
            if (!IsUsersEmpty()) {
                    Console.Write("Enter name of user:");
                    string name = Console.ReadLine();
                     bool bFound = false;
                    if (!String.IsNullOrEmpty(name))
                    {

                    foreach (var person in users)
                    {
                        if (person.Name.ToLower().Contains(name.ToLower()))
                        {
                            Console.WriteLine(person.ToString());
                            bFound = true;
                            ReturnToMenu();
                        }
                    }
                    if (!bFound)
                        OutputMessage("No users found with this name");
                }
                    else
                    {
                        OutputMessage("Enter a valid name.");
                        SearchUser();
                    } 
                }
            }


        private void OutputMessage(string message)
        {

            Console.WriteLine($"{message} Try again by press <Enter>");
            Console.ReadLine();
            Console.Clear();

        }
        private void ReturnToMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Click <Enter> to Return to menu:");
            Console.ReadLine();
            Console.Clear();
            FirstScreen();
        }

        private void StartOption(string message)
        {
            Console.Clear();
            Console.WriteLine($"{message} {Environment.NewLine}");
        }

        private void PrintingAllUsers()
        {
            int i = 0;
            users.ForEach(person => Console.WriteLine(++i + "." + person.ToString()));
        }

        private Person ReturnUser()
        {
            Console.Write("Enter the user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the age of user: ");
            var isValid = int.TryParse(Console.ReadLine(), out int age);

            if (isValid)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    if (age > 0 || age < 150)
                        return new Person(name, age);

                    //if the age wrong
                    else OutputMessage("Enter a valid age.");
                }

                //if the name is null
                else OutputMessage("Enter a name.");
            }

            else //if the enter the age string 
                OutputMessage("Something went wrong.");

            return null;
        }

        private bool IsUsersEmpty()
        {
            if (users.Count == 0)
            {
                OutputMessage("There is no users");
                return true;

            }
            else
            {
                
                return false;
            }
        }



    }
}