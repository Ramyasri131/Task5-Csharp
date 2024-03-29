
public static class departmentList
{
    public static Dictionary<int, string> departments = new Dictionary<int, string>
    {
        {1,"PE" },
        { 2,"QA" },
        {3,"Marketing" }
    };

}

public static class projectList
{
    public static Dictionary<int, string> projects = new Dictionary<int, string>
    {
        {1,"Project1" },
        { 2,"Project2" },
        {3,"Project3" }
    };
}

public static class managerList
{
    public static Dictionary<int, string> managers = new Dictionary<int, string>
    {
        {1,"Sandeep" },
        { 2,"Siva" },
        {3,"Shashank" }
    };
}

public static class loactionList
{
    public static Dictionary<int, string> locations = new Dictionary<int, string>
    {
         {1,"Hyderabad" },
        { 2,"Banglore" },
        {3,"Vizag" }
    };
}

public static class roleList
{
    public static Dictionary<int, string> roles = new Dictionary<int, string>
    {
         {1,"Manager" },
        { 2,"Lead" },
        {3,"Intern" }
    };
}
public class employeeDetailsLabelList
{
    public static Dictionary<int, string> employeeDataLabels = new Dictionary<int, string>
    {
        {1,"firstName" },
        {2,"lastName" },
        {3,"email" },
        {4,"mobileNumber" },
        {5, "dateOfBirth" },
        {6,"dateOfJoin" },
        {7,"location" },
        {8,"jobTitle" },
        {9,"department" },
        {10,"manager" },
        {11,"project" }
    };
}
//class to store employee data 
public class EmployeeData
{
    public string empId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string mobileNumber { get; set; }
    public string dateOfBirth { get; set; }
    public string dateOfJoin { get; set; }
    public string location { get; set; }
    public string jobTitle { get; set; }
    public string department { get; set; }
    public string manager { get; set; }
    public string project { get; set; }
}


//class to store role data
public class RoleData
{
    public string roleName { get; set; }
    public string location { get; set; }
    public string department { get; set; }
    public string description { get; set; }
}








