using System.ComponentModel.DataAnnotations;

namespace ContactsAdm.Models
{
    public class ContactModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;}
    }
}
