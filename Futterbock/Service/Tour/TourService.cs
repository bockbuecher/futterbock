using Futterbock.Context;
using Futterbock.Model;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Futterbock.Service.TourService
{
    public class TourService : ITourService
    {

        private readonly FutterbockContext _context;
        private readonly ILogger<TourService> _logger;

        public TourService(FutterbockContext context, ILogger<TourService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<bool> CreateTour(Tour tour, CancellationToken token)
        {
            if (tour != null)
            {
                _context.Tour.Add(tour);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                _logger.LogError($"Tour can't be created");
                return false;
            }
        }

        public async Task<bool> RemoveTour(int tourID, CancellationToken token)
        {
            Tour tour = await GetTour(tourID);

            if (tour != null)
            {
                _context.Tour.Remove(tour);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<Tour> SearchTour(int tourID, CancellationToken token)
        {
            Tour tour = await GetTour(tourID);

            if (tour != null)
            {
                return tour;
            }
            else
            {
                _logger.LogError($"Cannot Find Tour with {nameof(tourID)} {tourID}");
                return null;
            }

        }

        public async Task<bool> UpdateTour(int tourID, Tour tour, CancellationToken token)
        {
            Tour tmpTour = await GetTour(tourID);

            if (tour != null)
            {
                tmpTour.Name = tour.Name;
                tmpTour.Startdate = tour.Startdate;
                tmpTour.EndDate = tour.EndDate;
                tmpTour.Startmeal = tour.Startmeal;
                tmpTour.Endmeal = tour.Endmeal;

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                _logger.LogError($"Cannot Find Tour with {nameof(tourID)} {tourID}");
                return false;
            }
        }



        private async Task<Tour> GetTour(int tourID)
        {
            return await _context.Tour.FirstOrDefaultAsync(x => x.Id == tourID);
        }
    }
}
