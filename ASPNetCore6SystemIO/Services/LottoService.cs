namespace ASPNetCore6SystemIO.Services
{
    using ASPNetCore6SystemIO.ViewModels;
    using ASPNetCore6SystemIO.Wrapper;
    using System.IO.Abstractions;
    using System.Runtime.InteropServices;

    public class LottoService : ILottoService
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IFileSystem _fileSystem;

        public LottoService(IRandomGenerator randomGenerator, IDateTimeProvider dateTimeProvider, IFileSystem fileSystem) 
        {
            _randomGenerator = randomGenerator;
            _dateTimeProvider = dateTimeProvider;
            _fileSystem = fileSystem;
        }

        public LottoViewModel Lottoing(int min, int max)
        {

            var result = new LottoViewModel();

            // -----------------------
            // 檢核1: 是否為每個月 5 日
            // -----------------------
            var now = _dateTimeProvider.GetCurrentTime();
            if (now.Day != 5)
            {
                result.Sponsor = string.Empty;
                result.YourNumber = -1;
                result.Message = "非每個月5日, 不開獎";
                return result;
            }

            // -----------------------
            // 檢核2: 主辦人員是否已按下[開始]按鈕
            // -----------------------
            // 註: 這裡有可能會出現一些 Exception, 例如: FileNotFoundException
            var sponsor = string.Empty;
            try
            {
                sponsor = _fileSystem.File.ReadAllText("Extras/startup.txt");
            }
            catch (Exception)
            {
                result.Sponsor = sponsor;
                result.YourNumber = -2;
                result.Message = "主辦人員尚未按下[開始]按鈕";
                return result;
            }

            // Random(min, max): 含下界, 不含上界
            var yourNumber = _randomGenerator.Next(min, max);
            // 只要餘數是 9, 就代表中獎
            var message = (yourNumber % 10 == 9) ? "恭喜中獎" : "再接再厲";
            result.Sponsor = sponsor;
            result.YourNumber = yourNumber;
            result.Message = message;

            return result;
        }
    }
}
