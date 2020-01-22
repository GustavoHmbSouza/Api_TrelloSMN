using Domain.Entities;

namespace Domain.Membro
{
    public interface IMembroRepository
    {
        MembroCs Get(string idMembro);
    }
}
