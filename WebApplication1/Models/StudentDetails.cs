using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }

        public int SId { get; set; }
        
        public string StudentName { get; set; }
        
        public string StudentNumber { get; set; }
      
        public string AdmissionDate { get; set; }
       
        public string SchoolCode { get; set; }
                                    
        public string AcedmicDay { get; set; }
               
        public string Class { get; set; }       
        public string Comment { get; set; }
        
        public string Address { get; set; }
        public string Mobile { get; set; }
       
        public string SchoolTime { get; set; }

        public string Email { get; set; }
        
    }
}
