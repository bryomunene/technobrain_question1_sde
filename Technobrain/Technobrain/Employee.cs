using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technobrain
{
    public class Employee
    {
        public string employeeNo { get; set;}
        public string managerNo { get; set; }
        public Int32 employeeSalary { get; set; }

        List<Employee> staff = new List<Employee>();

        public void GenerateList()
        {
            staff.Add(new Employee { employeeNo = "employee4", managerNo = "employee2", employeeSalary = 2500 });
            staff.Add(new Employee { employeeNo = "employee3", managerNo = "employee1", employeeSalary = 1800 });
            staff.Add(new Employee { employeeNo = "employee1", managerNo = "", employeeSalary = 1000 });
            staff.Add(new Employee { employeeNo = "employee5", managerNo = "employee1", employeeSalary = 1500 });
            staff.Add(new Employee { employeeNo = "employee2", managerNo = "employee1", employeeSalary = 1500 });
        }

        public Int32[] validateSalariesAreValidIntegers()
        {
            GenerateList();

            Int32 salary; Int32 n = 0;
            Int32[] employeeSalary = new Int32[staff.Count()];

            foreach(var st in staff)
            {
                employeeSalary[n] = st.employeeSalary;
                salary = st.employeeSalary;
                n++;
            }
            staff.Clear();
            return employeeSalary;
        }

        public void generateMenu()
        {
            Int32 choice;
            Employee emp = new Employee();

            while (true)
            {
                Console.WriteLine("1. Display List Collection");
                Console.WriteLine("2. Validate Salaries are valid Integers");
                Console.WriteLine("3. One Employee reports to only one manager");
                Console.WriteLine("4. Salary Budget of Manager");
                Console.WriteLine("5. Validate only one CEO");
                Console.WriteLine("6. No Manager that is not an employee");
                Console.WriteLine("7. No Circular Reference");
                Console.WriteLine("10. Quit");

                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 10)
                {
                    break;
                }


                switch (choice)
                {
                    case 1:
                        emp.GenerateList();
                        break;
                    case 2:
                        emp.validateSalariesAreValidIntegers();
                        break;
                    case 3:
                        emp.validateEmployeeReportsToOneManager();
                        break;
                    case 4:
                        emp.salaryBudgetOfManagers();
                        break;
                    case 5:
                        emp.validateOnlyOneCEO();
                        break;
                    case 6:
                        emp.noManagerThatIsNotAnEmployee();
                        break;
                    case 7:
                        emp.noCircularReference();
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Exiting");
        }

        public Int32[] salaryBudgetOfManagers()
        {
                GenerateList();

                Int32 TotalSalaryBudget = 0;
                var usersGroupedByManager = staff.GroupBy(user => user.managerNo);

                Int32[] salaryBudget = new Int32[usersGroupedByManager.Count()];
                Int32 k = 0;
                foreach(var group in usersGroupedByManager)
                { 

                    if(group.Key != "")
                    {
                        Console.WriteLine("Salary Budget of Manager: " + group.Key);
                        var objEmp = staff.Find(x => (x.employeeNo == group.Key));
                        foreach (var user in group)
                        {
                            TotalSalaryBudget += user.employeeSalary;
                        }
                        
                        Console.WriteLine(TotalSalaryBudget + objEmp.employeeSalary);
                        salaryBudget[k] = (TotalSalaryBudget + objEmp.employeeSalary);
                        TotalSalaryBudget = 0;
                        k++;
                    }
                }
                staff.Clear();
                return salaryBudget;
        }

        public bool[] validateEmployeeReportsToOneManager()
        {
            GenerateList();

            var manEmpNo = ""; var manEmpNo1 = "";
            var EmpNos = (from t in staff where t.employeeNo != "" select t.employeeNo).ToArray();

            bool[] result = new bool[EmpNos.Count()];
            int k = 0;
            foreach (var empNo in EmpNos)
            {
                manEmpNo = staff.Where(o => o.employeeNo == empNo).Select(x => x.managerNo).FirstOrDefault();
                manEmpNo1 = staff.Where(o => o.employeeNo == empNo).Select(x => x.managerNo).LastOrDefault();

                if(manEmpNo != manEmpNo1)
                {
                    result[k] = false;
                }
                else
                {
                    result[k] = true;
                }
                k++;
            }
            staff.Clear();
            return result;
        }

        public Int32 validateOnlyOneCEO()
        {
            GenerateList();
            Int32 noOfCEO = staff.Where(s => s.managerNo == "").Count();
            staff.Clear();
            return noOfCEO;
        }

        public bool[] noCircularReference()
        {
            GenerateList();
            var manager1 = ""; var manager2 = "";

            var managerEmpNos = (from t in staff where t.managerNo != "" select t.managerNo).ToArray();
            var EmpNos = (from t in staff where t.employeeNo != "" select t.employeeNo).ToArray();

            bool[] man = new bool[EmpNos.Length];
            Int32 k = 0;
            foreach(var emp in EmpNos)
            {
                manager1 = staff.Where(o => o.employeeNo == emp).Select(x => x.managerNo).FirstOrDefault();
                manager2 = staff.Where(o => o.employeeNo == manager1).Select(x => x.managerNo).FirstOrDefault();
                if (manager2 == emp)
                {
                    man[k] = false;
                }
                else
                {
                    man[k] = true;
                }
                k++;
            }
            staff.Clear();
            return man;
        }

        public string[] noManagerThatIsNotAnEmployee()
        {
            GenerateList();

            var managerEmpNos = (from t in staff where t.managerNo != "" select t.managerNo).Distinct().ToArray();
            var EmpNos = (from t in staff where t.employeeNo != "" select t.employeeNo).Distinct().ToArray();

            string[] manager = new string[managerEmpNos.Length];
            for (int i = 0; i < EmpNos.Length; i++)
            {
                for (Int32 z = 0; z < managerEmpNos.Count();z++)
                {
                    if ((EmpNos[i]).Contains(managerEmpNos[z]))
                    {
                        manager[z] = managerEmpNos[z];
                    }
                }               
            }
            staff.Clear();
            return manager;
        }

    }

}
