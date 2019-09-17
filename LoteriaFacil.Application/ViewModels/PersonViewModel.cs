using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoteriaFacil.Application.ViewModels
{
    public class PersonViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Nome")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(150)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "A Senha é obrigatório")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Data do registro é obrigatório")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de Registro")]
        public DateTime DtRegister { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }
    }
}
