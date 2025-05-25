using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP_2laba.Models
{
    public class ExpertiseDepartment
    {
        [DisplayName("ID отдела")]
        public int Id { get; set; }

        [DisplayName("Название отдела")]
        public string Name { get; set; }

        [DisplayName("ФИО руководителя")]
        public string HeadFullName { get; set; }

        [DisplayName("Количество сотрудников")]
        public int EmployeeCount { get; set; }

        [DisplayName("Дата основания")]
        [DataType(DataType.Date)]
        public DateTime FoundationDate { get; set; }

        [DisplayName("Email отдела")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
} 