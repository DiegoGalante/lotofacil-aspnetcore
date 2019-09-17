using LoteriaFacil.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Validations
{
    public class UpdatePersonCommandValidation : PersonValidation<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidation()
        {
            ValidateId();
            ValidateName();
            //ValidateRegisterDate();
            ValidateEmail();
            ValidateActive();
        }
    }
}
