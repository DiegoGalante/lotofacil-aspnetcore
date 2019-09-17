using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class UpdatePerson_LotteryCommandValidation : Person_LotteryValidation<UpdatePerson_LotteryCommand>
    {
        public UpdatePerson_LotteryCommandValidation()
        {
            ValidateId();
            ValidateLottery();
            ValidatePerson();
            ValidateConcurse();
            ValidateGame();
            ValidateHits();
            ValidateGame_Checked();
            //ValidateGame_Register();
            ValidateTicket_Amount();
        }
    }
}
