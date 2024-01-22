namespace ASPNetCore6SystemIO.Services
{
    using ASPNetCore6SystemIO.ViewModels;

    public interface ILottoService
    {
        LottoViewModel Lottoing(int min, int max);
    }
}
