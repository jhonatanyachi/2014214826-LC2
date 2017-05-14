using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT.IRepositories
{
    public interface IUnityofWork : IDisposable
    {
        IAsientoRepository Asientos { get; }
        IAutomovilRepository Automoviles { get; }
        IBusRepository Buses { get; }
        ICarroRepository Carros { get; }
        ICinturonRepository Cinturones { get; }
        IEnsambladoraRepository Ensambladoras { get; }
        ILlantaRepository Llantas { get; }
        IParabrisasRepository Parabrisas { get; }
        IPropietarioRepository Propietarios { get; }
        IVolanteRepository Volantes { get; }

        int SaveChanges();

    }
}
