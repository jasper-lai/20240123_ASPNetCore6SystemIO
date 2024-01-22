namespace ASPNetCore6SystemIO.Services
{
    using ASPNetCore6SystemIO.ViewModels;
    using ASPNetCore6SystemIO.Wrapper;
    using System.Runtime.InteropServices;

    public class LottoService : ILottoService
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IDateTimeProvider _dateTimeProvider;

        public LottoService(IRandomGenerator randomGenerator, IDateTimeProvider dateTimeProvider) 
        {
            _randomGenerator = randomGenerator;
            _dateTimeProvider = dateTimeProvider;
        }

        public LottoViewModel Lottoing(int min, int max)
        {

            var result = new LottoViewModel();
            var now = _dateTimeProvider.GetCurrentTime();

            if (now.Day != 5)
            {
                result.YourNumber = -1;
                result.Message = "非每個月5日, 不開獎";
                return result;
            }

            // Random(min, max): 含下界, 不含上界
            var yourNumber = _randomGenerator.Next(min, max);
            // 只要餘數是 9, 就代表中獎
            var message = (yourNumber % 10 == 9) ? "恭喜中獎" : "再接再厲";

            result.YourNumber = yourNumber;
            result.Message = message;

            return result;
        }
    }
}
