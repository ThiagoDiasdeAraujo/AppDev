namespace Formulier2.Data
{
    public class DepartmentRepository
    {
        private List<Department> _departments;

        public DepartmentRepository()
        {
            _departments = Initialize();
        }

        private List<Department> Initialize()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "IT" });
            list.Add(new Department { Id = 2, Name = "HR" });
            list.Add(new Department { Id = 3, Name = "Finance" });

            return list;
        }

        public List<Department> GetAll()
        {
            return _departments;
        }
    }
}

