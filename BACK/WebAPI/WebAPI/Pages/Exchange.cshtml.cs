using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages
{
    public class ExchangeModel : PageModel
    {
        public string Message { get; set; }
        private readonly decimal currentRate = 64.1m;
        public void OnGet()
        {
            Message = "Введите сумму";
        }
        public void OnPost(int? sum)
        {
            if (sum is null or < 1000)
            {
                Message = "Передана некорректная сумма. Повторите ввод";
            }
            else
            {
                var result = sum.Value /currentRate;
                // ToString("F2") - форматирование числа: F2 - дробное число с 2 знаками после запятой
                Message = $"При обмене {sum} рублей вы получите {result.ToString("F2")}$.";
            }
        }
    }
}