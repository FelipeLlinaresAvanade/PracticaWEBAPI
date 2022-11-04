using Beca.ViviendaInfo.API.Entities;

namespace Beca.ViviendaInfo.API.Services
{
    public interface IViviendaInfoRepository
    {
        Task<IEnumerable<Vivienda>> GetViviendasAsync();
        Task<(IEnumerable<Vivienda>, PaginationMetadata)> GetViviendasAsync(int pageSize, int pageNumber);
        Task<Vivienda?> GetViviendaAsync(int viviendaId, bool includeReservas);
        Task<(IEnumerable<Vivienda>,int)> GetViviendasAsync(string name);
        Task<IEnumerable<Reserva>> GetReservasParaViviendaAsync(int viviendaId);
        Task<Reserva> GetReservaParaViviendaAsync(int viviendaId, int reservaId);
        Task<bool> ViviendaExistsAsync(int viviendaId);
        Task AddReservaParaViviendaAsync(int viviendaId, Reserva reserva);
        Task<bool> SaveChangesAsync();

        void DeleteReserva(Reserva reserva);

    }
}