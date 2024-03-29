using System.Runtime.CompilerServices;
//to display the options
class DisplayOptions
{
    public void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1.Employee Management");
        Console.WriteLine("2.Role Management ");
        Console.WriteLine("3.Exit");
        bool runApplication = true;
        while (runApplication)
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice:");
            int selectedOption = int.Parse(Console.ReadLine());
            if (selectedOption == 1)
            {
                DisplayEmployeeManagementMenu();

            }
            else if (selectedOption == 2)
            {
                DisplayRoleManagementMenu();

            }
            else if (selectedOption == 3)
            {
                Console.WriteLine("Exit");
            }
            runApplication = false;

        }
    }
    public void DisplayEmployeeManagementMenu()
    {
        Console.WriteLine("Employee Management");
        Console.WriteLine("1.Add employee ");
        Console.WriteLine("2.Display all  ");
        Console.WriteLine("3.Display one ");
        Console.WriteLine("4.Edit employee ");
        Console.WriteLine("5.Delete Employee");
        Console.WriteLine("6.Go Back ");
        Console.WriteLine();
        Console.Write("Enter Your Choice:");
        int selectedTask = int.Parse(Console.ReadLine());
        OnSelectingOption selectOptions = new OnSelectingOption();
        if (selectedTask == 1)
        {
            selectOptions.OnSelectAddEmployee();
            DisplayEmployeeManagementMenu();
        }
        else if (selectedTask == 2)
        {
            selectOptions.OnDisplayAll();
            DisplayEmployeeManagementMenu();

        }
        else if (selectedTask == 3)
        {
            selectOptions.onSelectDisplayOne();
            DisplayEmployeeManagementMenu();
        }
        else if (selectedTask == 4)
        {
            selectOptions.onSelectEditEmployee();
            DisplayEmployeeManagementMenu();
        }
        else if (selectedTask == 5)
        {
            selectOptions.onSelectDeleteEmployee();
            DisplayEmployeeManagementMenu();
        }
        else if (selectedTask == 6)
        {
            DisplayMainMenu();

        }

    }
    public void DisplayRoleManagementMenu()
    {
        Console.WriteLine("Role Management");
        Console.WriteLine("1.Add role\r\n2.Display all\r\n3.Go Back ");
        Console.WriteLine();
        Console.Write("Enter Your Choice:");
        int selectedTask = int.Parse(Console.ReadLine());
        if (selectedTask == 1)
        {
            OnSelectingOption selectOptions = new OnSelectingOption();
            selectOptions.onSelectAddRole();
            DisplayRoleManagementMenu();
        }
        if (selectedTask == 2)
        {
            OnSelectingOption selectOptions = new OnSelectingOption();
            selectOptions.onSelectDisplayAllRole();
            DisplayRoleManagementMenu();
        }
        if (selectedTask == 3)
        {
            DisplayMainMenu();
        }

    }
}