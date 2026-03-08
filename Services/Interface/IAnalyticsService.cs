using WebApplication2.ViewModels.Analytics;
using WebApplication2.ViewModels.Dashboard;

namespace WebApplication2.Services.Interface
{
    public interface IAnalyticsService
    {
        Task<AnalyticsViewModel> GetAnalyticsAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<DashboardViewModel> GetDashboardDataAsync(int businessId);
        Task<List<TopProductViewModel>> GetTopSellingProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5);
        Task<List<TopProductViewModel>> GetMostProfitableProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5);
        Task<List<TopProductViewModel>> GetLowStockProductsAsync(int businessId);
        Task<List<ChartDataPoint>> GetRevenueByDayAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<List<CategorySalesData>> GetSalesByCategoryAsync(int businessId, DateTime startDate, DateTime endDate);
    }
}
