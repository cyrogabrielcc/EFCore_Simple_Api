using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        //------------------valores da descrição-----------------
        [MaxLength(1024, ErrorMessage = "Até 1024 caracteres!")]
        public string Description { get; set; }
        //valores da descrição

        // ----------------valores do preço---------------
        [Required(ErrorMessage="O preço é obrigatório")]
        [Range(1,int.MaxValue, ErrorMessage= "Deve ser maior que zero")]
        // o range é setado para que o valor automaticamente se inicie maior que zero, impossibilitando a inserção de valores muito baixos;
        public decimal Price { get; set; }
        //valores do preço

        //----------------categoria-------------------
        [Required(ErrorMessage="A categoria é obrigatória")]
        [Range(1,int.MaxValue, ErrorMessage= "Deve ser maior que zero")]
        public int CategoryId { get; set; }
        //categoria

        public Category Category { get; set; }
    }
}