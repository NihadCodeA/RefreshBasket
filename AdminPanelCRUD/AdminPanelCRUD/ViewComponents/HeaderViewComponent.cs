
using AdminPanelCRUD.Models;
using Newtonsoft.Json;

namespace AdminPanelCRUD.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly PustokContext _context;
		public HeaderViewComponent(PustokContext context) 
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
            //List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();
            //List<CheckoutItemViewModel> checkoutItems = new List<CheckoutItemViewModel>();
            //CheckoutItemViewModel checkoutItem = null;
            //string basketItemStr = HttpContext.Request.Cookies["BasketItems"];

            //if (basketItemStr != null)
            //{
            //    basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemStr);

            //    foreach (var item in basketItems)
            //    {
            //        checkoutItem = new CheckoutItemViewModel
            //        {
            //            Book = _context.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == item.BookId),
            //            Count = item.Count,
            //        };
            //        checkoutItems.Add(checkoutItem);
            //    }
            //}
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();
            string basketItemStr = HttpContext.Request.Cookies["BasketItems"];

            if (basketItemStr != null)
            {
                basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemStr);
            }
            return View(await Task.FromResult(basketItems));
        }
	}
}
