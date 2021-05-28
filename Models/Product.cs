using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("Cat_Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [Range(0.1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}