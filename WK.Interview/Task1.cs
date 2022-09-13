/*
   TODO
   Przetestuj metodę Task1.CreateEmployee(...) kompletnie.
   Pamiętaj o testach na sukces oraz wszelkie przypadki generujące błędy.
   Pamiętaj o upewnieniu się, że w testowych wywołaniach metod zostały użyte odpowiednio dobrane argumenty. Tj. czy nie są zbyt ogólne, co mogłoby spowodować niekompletne przetestowanie metody.
*/

namespace WK.Interview
{
    public class Task1
    {
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IEmployeeRepository _employeeRepository;

        public Task1(IEmployeeFactory employeeFactory, IEmployeeRepository employeeRepository)
        {
            _employeeFactory = employeeFactory;
            _employeeRepository = employeeRepository;
        }

        public Guid CreateEmployee(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Value cannot be null or empty", nameof(lastName));

            var employee = _employeeFactory.Create(lastName);
            _employeeRepository.Insert(employee);

            return employee.Id;
        }
    }

    public interface IEmployeeFactory
    {
        IEmployee Create(string lastName);
    }
    public interface IEmployeeRepository
    {
        void Insert(IEmployee employee);
    }
    public interface IEmployee
    {
        Guid Id { get; }
    }
}