using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class UpdatePersonLotteryCommandValidation : PersonLotteryValidation<UpdatePersonLotteryCommand>
    {
        public UpdatePersonLotteryCommandValidation()
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
