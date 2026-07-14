using System.ComponentModel.DataAnnotations;

namespace PontosTuristicos.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a descrição")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a localização")]
        public string Localizacao { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe o estado")]
        public string Estado { get; set; } = string.Empty;


        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}