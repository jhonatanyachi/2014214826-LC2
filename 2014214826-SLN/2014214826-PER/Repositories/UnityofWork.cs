using _2014214826_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.Repositories
{
    public class UnityofWork : IUnityofWork
    {
        private readonly EnsambladoraDbContext _Context;
        private static UnityofWork _Intance;
        private static readonly object _Lock = new object();

        public IAsientoRepository Asientos { get; private set; }
        public IAutomovilRepository Automoviles { get; private set; }
        public IBusRepository Buses { get; private set; }
        public ICarroRepository Carros { get; private set; }
        public ICinturonRepository Cinturones { get; private set; }
        public IEnsambladoraRepository Ensambladoras { get; private set; }
        public ILlantaRepository Llantas { get; private set; }
        public IParabrisasRepository Parabrisas { get; private set; }
        public IPropietarioRepository Propietarios { get; private set; }
        public IVolanteRepository Volantes { get; private set; }
        public UnityofWork()
        {
            _Context = new EnsambladoraDbContext();

            Asientos = new AsientoRepository(_Context);
            Automoviles = new AutomovilRepository(_Context);
            Buses = new BusRepository(_Context);
            Carros = new CarroRepository(_Context);
            Cinturones = new CinturonRepository(_Context);
            Ensambladoras = new EnsambladoraRepository(_Context);
            Llantas = new LlantaRepository(_Context);
            Parabrisas = new ParabrisasRepository(_Context);
            Propietarios = new PropietarioRepository(_Context);
            Volantes = new VolanteRepository(_Context);
        }
        public static UnityofWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Intance == null)
                        _Intance = new UnityofWork();
                }

                return _Intance;
           }
            
        }
        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
           return _Context.SaveChanges();
        }
    }
}
