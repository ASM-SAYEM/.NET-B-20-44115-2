using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ClientDTO
    {
       
        public int Id { get; set; }
        [Required]
        public string UserName {get; set;}
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(8)] 
        public string Password { get; set; }
        [Required]
        public int PhoneNumber { get; set; } 
        [Required]
        public string Type {get;set}
        
        [Required]
        public string Email {get;set}
        
       

    }
}
