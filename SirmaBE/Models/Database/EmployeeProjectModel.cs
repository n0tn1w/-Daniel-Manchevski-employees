namespace SirmaBE.Models.Database
{
    public class EmployeeProjectModel
    {
        public Guid Id { get; set; }

        public int EmpID { get; set; }

        public int ProjectID { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
