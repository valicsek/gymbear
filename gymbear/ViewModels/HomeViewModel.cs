using System;
namespace gymbear.ViewModels
{
    public class HomeViewModel
    {
        public string Day
        {
            get
            {
                return DateTime.Now.ToString("dddd");
            }
        }

        public HomeViewModel()
        {
        }
    }
}
