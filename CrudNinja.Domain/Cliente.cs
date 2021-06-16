

namespace CrudNinja.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        /*[Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "É necessário ser um {0} válido")]*/
        public string Email { get; set; }
        public string Aldeia { get; set; }

    }

    
}