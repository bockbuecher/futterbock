using Futterbock.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Futterbock.Service.TourService
{
    public interface ITourService
    {
        public Task<bool> CreateTour(Tour tour, CancellationToken token);
        public Task<Tour?> SearchTour(int tourID, CancellationToken token);
        public Task<bool> UpdateTour(int tourID, Tour tour, CancellationToken token);
        public Task<bool> RemoveTour(int tourID, CancellationToken token);
    }
}
