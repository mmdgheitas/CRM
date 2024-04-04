using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ITimeCardService
    {
        List<TimeCardEnt> ListAllTimeCards();
        Task<List<TimeCardEnt>> ListAllTimeCardsAsync();
        bool DeleteTimeCard(long id);
        TimeCardEnt TimeCardDetails(long id);
        bool AddTimeCard(TimeCardEnt item);
        Task<bool> AddTimeCardAsync(TimeCardEnt item);
        bool EditTimeCard(TimeCardEnt item);
        Task<bool> EditTimeCardAsync(TimeCardEnt item);
        TimeCardEnt GetCurrentTime(string userId);
        Task<TimeCardEnt> GetCurrentTimeAsync(string userId);
        Task<DateTime?> GetLastLoginTimeAsync(string userId);

        DateTime? GetLastTimeHasntLunch(string userId);

    }
}
