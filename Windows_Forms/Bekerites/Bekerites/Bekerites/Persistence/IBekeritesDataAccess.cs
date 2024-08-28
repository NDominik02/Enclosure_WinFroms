using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bekerites.Persistence
{
    public interface IBekeritesDataAccess
    {
        Task<BekeritesTable> LoadAsync(String path);

        Task SaveAsync(String path, BekeritesTable table);
    }
}
