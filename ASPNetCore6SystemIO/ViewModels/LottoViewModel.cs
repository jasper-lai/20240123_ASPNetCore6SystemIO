namespace ASPNetCore6SystemIO.ViewModels
{
    public class LottoViewModel
    {

        // 主辦人姓名
        public string Sponsor { get; set; } = string.Empty;

        // 抽到的號碼
        public int YourNumber { get; set; }

        // 回應訊息
        public string Message { get; set; } = string.Empty;
    }
}
