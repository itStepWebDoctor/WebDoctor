using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDoctor.Models
{
    public class ClientRecording
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Дата приёма")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Время приёма")]
        public TimeSpan Time { get; set; }
        [Required]
        [Display(Name = "Категория врача")]
        public string Specialisation { get; set; }
        [Required]
        [Display(Name = "Имя врача")]
        public string DoctorName { get; set; }
        [Display(Name = "Дополнительная информация")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Статус приёма")]
        public bool Status { get; set; }
        [Display(Name = "Имя клиента")]
        public string ClientName { get; set; }
        [Display(Name = "Диагноз")]
        public string Diagnos { get; set; }
    }
}