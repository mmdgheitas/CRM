

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class PageViewStatisticsEnt : EntityBase<long>
    {
        public string? FullName { get; set; }
        public string? IP { get; set; }
        public string?  PageName { get; set; }
        public string?  PageID { get; set; }
        public PageViewType Type { get; set; }
        public DateTime Date { get; set; }
    }
    public class PageViewStatisticsViewModel 
    {
        public string  FullName { get; set; }
        public string  IP { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public string PageID { get; set; }
        public PageViewType Type { get; set; }
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public int Count { get; set; }
    }
    public enum PageViewType
    {
        Page = 1,
        HomeTabs = 2,
    }
}