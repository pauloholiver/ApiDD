using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("Cat_Id")]
        public int Id { get; set; }

        [Column("Title")]
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
    }
}