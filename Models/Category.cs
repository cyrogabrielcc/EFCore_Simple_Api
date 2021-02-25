using System.ComponentModel.DataAnnotations;
 
namespace EFTest.Models
{
    public class Category
    {
        [Key] // sinalizar como chave
        public int Id { get; set; } //Id da Categoria

        // a partir daqui serão setadas questões de inserção de dados

        [Required(ErrorMessage = "O campo de título é obrigatório!")]
        [MaxLength(60, ErrorMessage="+60 é inválido")]
        [MinLength(3, ErrorMessage="-3 é inválido")]
        public string Title { get; set; } //declaração do título


    }
}