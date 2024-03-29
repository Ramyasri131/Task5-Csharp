using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.RegularExpressions;

//to modify employee data present in employee-data.json file

public class toChangeEmployeeData
{
    //to edit employee data present in employee-data file
    public void editEmployeeInEmployeeData()
    {
        string employeeJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json");
        if (employeeJsonData == "")
        {
            Console.WriteLine("DataBase is Empty");
        }
        else
        {
            List<EmployeeData> loadedEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
            Console.WriteLine("Enter Employee Id To Edit");
            string enteredEmpId = Console.ReadLine().ToUpper();
            bool isEmployeePresent = false;
            foreach (var employee in loadedEmployees)
            {
                if (employee.empId == enteredEmpId)
                {
                    isEmployeePresent = true;
                    Console.WriteLine("Field to edit");
                    foreach (var item in employeeDetailsLabelList.employeeDataLabels)
                    {
                        Console.WriteLine(item.Key + " " + item.Value);
                    }
                    Console.WriteLine("Enter Opttion");
                    int selectedOption = int.Parse(Console.ReadLine());
                    string label = employeeDetailsLabelList.employeeDataLabels[selectedOption];
                    Validation validator = new Validation();
                    string dataToEdit = "";
                    if (label == "location" || label == "jobTitle" || label == "department" || label == "project")
                    {
                        if (label == "location")
                        {
                            dataToEdit = validator.selectValidDetails(label, loactionList.locations);
                        }
                        else if (label == "jobTitle")
                        {
                            dataToEdit = validator.selectValidDetails(label, roleList.roles);
                        }
                        else if (label == "department")
                        {
                            dataToEdit = validator.selectValidDetails(label, departmentList.departments);
                        }
                        else if (label == "project")
                        {
                            dataToEdit = validator.selectValidDetails(label, projectList.projects);
                        }
                    }
                    else
                    {
                        dataToEdit = validator.getValidDetails(label);
                    }
                    List<Action<EmployeeData, string>> chageEnteredData = new List<Action<EmployeeData, string>>
                    {
                        (item, dataToEdit) => item.firstName = dataToEdit,
                        (item, dataToEdit) => item.lastName = dataToEdit,
                        (item, dataToEdit) => item.email = dataToEdit,
                        (item, dataToEdit) => item.mobileNumber = dataToEdit,
                        (item, dataToEdit) => item.dateOfBirth = dataToEdit,
                        (item, dataToEdit) => item.dateOfJoin = dataToEdit,
                        (item, dataToEdit) => item.location = dataToEdit,
                        (item, dataToEdit) => item.jobTitle = dataToEdit,
                        (item, dataToEdit) => item.department = dataToEdit,
                        (item, dataToEdit) => item.manager = dataToEdit,
                        (item, dataToEdit) => item.project = dataToEdit
                    };
                    foreach (var item in loadedEmployees)
                    {
                        if (item.empId == enteredEmpId)
                        {
                            chageEnteredData[selectedOption - 1](item,dataToEdit);
                        }

                    }
                    string json = JsonSerializer.Serialize(loadedEmployees);
                    File.WriteAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json", json);
                }

            }
            if (!isEmployeePresent)
            {
                Console.WriteLine("No Employee with entered employee id");
                Console.WriteLine();
            }

        }

    }

    //to add new data into employee file
    public void addEmployeeDate()
    {
        string employeeJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json");
        while (true)
        {
            bool inValidDetails = true;
            string empId = "";
            while (inValidDetails)
            {
                Validation valid = new Validation();
                Console.WriteLine("Enter Employee Id");
                empId = Console.ReadLine();
                empId = empId!.ToUpper();
                string PrefixOfEmpId = empId.Substring(0, 2);
                string SufixOfEmpId = "";
                valid.isValid(empId, "Employee Id", out inValidDetails);
                if (PrefixOfEmpId != "TZ" || !int.TryParse(empId.Substring(2), out _))
                {
                    Console.WriteLine("Enter Valid Employee Id");
                    inValidDetails = true;
                }
                else
                {
                    SufixOfEmpId = empId.Substring(2);
                    if (SufixOfEmpId.Length != 4)
                    {
                        Console.WriteLine("Enter Valid Employee Id");
                        inValidDetails = true;
                    }
                    else
                    {
                        if (employeeJsonData != "")
                        {
                            List<EmployeeData> getEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
                            foreach (var item in getEmployees)
                            {
                                if (item.empId == empId)
                                {
                                    Console.WriteLine("Employee already present");
                                    inValidDetails = true;
                                }
                            }

                        }

                    }
                }
            }
            Validation validator = new Validation();
            string firstName = validator.getValidDetails("firstName");
            string lastName = validator.getValidDetails("lastName");
            string dateOfBirth = validator.getValidDetails("dateOfBirth");
            string email = validator.getValidDetails("email");
            string mobileNumber = validator.getValidDetails("mobileNumber");
            string dateOfJoin = validator.getValidDetails("dateOfJoin");
            string location = validator.selectValidDetails("location", loactionList.locations);
            string jobTitle = validator.selectValidDetails("jobTitle", roleList.roles);
            string department = validator.selectValidDetails("department", departmentList.departments);
            string manager = validator.selectValidDetails("Manager", managerList.managers);
            string project = validator.selectValidDetails("Project", projectList.projects);
            EmployeeData employeeInput = new EmployeeData()
            {
                empId = empId,
                firstName = firstName,
                lastName = lastName,
                dateOfBirth = dateOfBirth,
                email = email,
                mobileNumber = mobileNumber,
                dateOfJoin = dateOfJoin,
                location = location,
                jobTitle = jobTitle,
                department = department,
                manager = manager,
                project = project
            };
            List<EmployeeData> loadedEmployees;
            if (employeeJsonData == "")
            {
                loadedEmployees = new List<EmployeeData>();
            }
            else
            {
                loadedEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
            }
            loadedEmployees.Add(employeeInput);
            string json = JsonSerializer.Serialize(loadedEmployees);
            File.WriteAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json", json);
            return;
        }

    }

    public void DeleteEmployee()
    {
        string employeeJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json");

        if (employeeJsonData == "")
        {
            Console.WriteLine("DataBase is Empty");
            Console.WriteLine();
        }
        else
        {
            List<EmployeeData> loadedEmployees;
            if (employeeJsonData != "")
            {
                loadedEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
            }
            else
            {
                loadedEmployees = new List<EmployeeData>();
            }
            Console.WriteLine("Enter employee Id to delete");
            string enteredEmpId = Console.ReadLine().ToUpper();
            bool isEmployeePresent = false;
            foreach (var item in loadedEmployees)
            {
                if (item.empId == enteredEmpId)
                {
                    loadedEmployees.Remove(item);
                    isEmployeePresent = true;
                    break;
                }
            }
            if (!isEmployeePresent)
            {
                Console.WriteLine("Employee not present");
                Console.WriteLine();
            }
            string json = JsonSerializer.Serialize(loadedEmployees);
            File.WriteAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json", json);

        }
    }

    public void DisplayEmployeeDetails(EmployeeData item)
    {
        Console.WriteLine();
        Console.WriteLine("Employee Id: " + item.empId);
        Console.WriteLine("FirstName : " + item.firstName);
        Console.WriteLine("Last Name: " + item.lastName);
        Console.WriteLine("Date of birth: " + item.dateOfBirth);
        Console.WriteLine("Email: " + item.email);
        Console.WriteLine("Mobile Number: " + item.mobileNumber);
        Console.WriteLine("Date of Join: " + item.dateOfJoin);
        Console.WriteLine("Location: " + item.location);
        Console.WriteLine("Job tiltle: " + item.jobTitle);
        Console.WriteLine("Department: " + item.department);
        Console.WriteLine("Manager: " + item.manager);
        Console.WriteLine("Project: " + item.project);
        Console.WriteLine("==================================");
    }
}


//to change data present in role-data.json file
public class toChangeRoleData
{
    public void addRole()
    {
        string roleJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\role-data.json");
        Validation validator = new Validation();
        string roleName = validator.selectValidDetails("jobTitle", roleList.roles);
        string department = validator.selectValidDetails("department", departmentList.departments);
        Console.WriteLine("Enter Description");
        string description = Console.ReadLine();
        string location = validator.selectValidDetails("location", loactionList.locations);
        RoleData roleInput = new RoleData()
        {
            roleName = roleName,
            location = location,
            department = department,
            description = description
        };
        List<RoleData> inputRoleData = JsonSerializer.Deserialize<List<RoleData>>(roleJsonData);
        inputRoleData.Add(roleInput);
        string inputTojson = JsonSerializer.Serialize(inputRoleData);
        File.WriteAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\role-data.json", inputTojson);
    }

    public void displayRoles()
    {
        string roleJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\role-data.json");
        List<RoleData> inputRoleData = JsonSerializer.Deserialize<List<RoleData>>(roleJsonData);
        foreach (var item in inputRoleData)
        {
            Console.WriteLine("Employee Id: " + item.roleName);
            Console.WriteLine("Location: " + item.location);
            Console.WriteLine("Department: " + item.department);
            Console.WriteLine("Description: " + item.description);
            Console.WriteLine("============================");
        }
    }
}


//when user selects an option
class OnSelectingOption
{
    toChangeEmployeeData employeeData = new toChangeEmployeeData();
    toChangeRoleData roleData = new toChangeRoleData();

    public void OnSelectAddEmployee()
    {
        employeeData.addEmployeeDate();
    }

    public void OnDisplayAll()
    {
        string employeeJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json");
        if (employeeJsonData == "")
        {
            Console.WriteLine("Database is empty");
        }
        else
        {
            List<EmployeeData> loadedEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
            foreach (var item in loadedEmployees)
            {
                employeeData.DisplayEmployeeDetails(item);
            }
        }

    }

    public void onSelectDisplayOne()
    {
        string employeeJsonData = File.ReadAllText("C:\\Workspace\\Tasks\\Task5-Csharp\\ConsoleApplication\\ConsoleApplication\\Data\\employee-data.json");

        if (employeeJsonData == "")
        {
            Console.WriteLine("Database is Empty");
        }
        else
        {
            List<EmployeeData> loadedEmployees = JsonSerializer.Deserialize<List<EmployeeData>>(employeeJsonData);
            Console.WriteLine("Enter Employee Id");
            string enteredEmpId = Console.ReadLine().ToUpper();
            foreach (var item in loadedEmployees)
            {
                if (item.empId == enteredEmpId)
                {
                    employeeData.DisplayEmployeeDetails(item);
                }
            }

        }

    }


    public void onSelectEditEmployee()
    {
        employeeData.editEmployeeInEmployeeData();
    }

    public void onSelectDeleteEmployee()
    {
        employeeData.DeleteEmployee();

    }

    public void onSelectAddRole()
    {
        roleData.addRole();
    }
    public void onSelectDisplayAllRole()
    {
        roleData.displayRoles();
    }

}


public class Validation
{
    public void isValid(string inputData, string labelData, out bool invalidDetails)
    {
        if (inputData.Length != 0)
        {
            invalidDetails = false;
        }
        else
        {
            invalidDetails = true;
            Console.WriteLine("Please Enter " + labelData);
        }
    }
    public string getValidDetails(string label)
    {
        bool inValidDetails = true;
        string inputData = "";
        while (inValidDetails)
        {
            Validation valid = new Validation();
            Console.WriteLine("Enter " + label);
            inputData = Console.ReadLine();
            valid.isValid(inputData, label, out inValidDetails);
            if (label == "dateOfBirth")
            {
                DateTime val;
                DateTime today = DateTime.Today;
                if (!DateTime.TryParseExact(inputData, new string[] { "dd/MM/yyyy", "MM/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out val))
                {
                    Console.WriteLine("Invalid date format. The Correct format is dd/mm/yyyy");
                    inValidDetails = true;
                }
                else
                {
                    int age = today.Year - DateTime.Parse(inputData).Year;
                    if (age < 18)
                    {
                        Console.WriteLine("Age not sufficent");
                        inValidDetails = true;
                    }
                    else
                    {
                        inValidDetails = false;
                    }
                }

            }
            if (label == "email")
            {
                Regex formatOfEmail = new Regex("^[a-zA-Z0-9._%+-]+@tezo.com$");
                if (!formatOfEmail.IsMatch(inputData))
                {
                    Console.WriteLine("Inavalid Email Format");
                    inValidDetails = true;
                }
            }
            if (label == "mobileNumber")
            {
                if (inputData.Length != 10 || int.TryParse(inputData, out _))
                {
                    Console.WriteLine("Enter 10 digits Mobile Number");
                    inValidDetails = true;
                }
                else
                {
                    inValidDetails = false;
                }
            }
            if (label == "dateOfJoin")
            {
                DateTime val;
                valid.isValid(inputData, "date of join", out inValidDetails);
                if (!DateTime.TryParseExact(inputData, new string[] { "dd/MM/yyyy", "MM/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out val))
                {
                    Console.WriteLine("Invalid date format.");
                    inValidDetails = true;
                    Console.WriteLine("Parsed date: " + inputData);
                }
                else
                {
                    inValidDetails = false;
                }
            }
        }
        return inputData;
    }

    public string selectValidDetails(string label, Dictionary<int, string> list)
    {
        Console.WriteLine("Select " + label);
        foreach (var item in list)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
        int selectedKey = int.Parse(Console.ReadLine());
        string input = list[selectedKey];
        return input;
    }
}