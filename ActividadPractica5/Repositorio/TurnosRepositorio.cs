using ActividadPractica5.Modelos;
using Microsoft.IdentityModel.Tokens;

namespace ActividadPractica5.Repositorio
{
    public class TurnosRepositorio : ITurnosRepositorio
    {
        private turnos_dbContext _contexto;
        public TurnosRepositorio(turnos_dbContext contexto)
        {
            _contexto = contexto;
        }

        public bool Actualizar(int id, TTurno turnoActualizado)
        {
           var turnos=_contexto.TTurnos.Find(id);
            if(turnos != null)
            {
                turnos.Hora = turnoActualizado.Hora;
                turnos.Cliente = turnoActualizado.Cliente;
                turnos.Fecha = turnoActualizado.Fecha;
                turnos.Estado = turnoActualizado.Estado;

                _contexto.TTurnos.Update(turnos);

            }
            return _contexto.SaveChanges() > 0;
        }

        public bool BajaTurnos(int id)
        {
            var turnos= _contexto.TTurnos.Find(id);
            if(turnos != null)
            {
                turnos.Estado = false;
                _contexto.TTurnos.Update(turnos);
            }
            return _contexto.SaveChanges() < 0; 
        }

        public bool Crear(TTurno turno)
        {
            _contexto.TTurnos.Add(turno);
            return _contexto.SaveChanges() == 1;
        }

        public List<TTurno> GetALL(int id, string fecha, string hora, string cliente)
        {
            return _contexto.TTurnos.Where(x => x.Id==id || id==-1 && x.Fecha==fecha || x.Fecha.Contains(fecha) && x.Hora==hora || x.Hora.Contains(hora) && x.Cliente==cliente || x.Cliente.Contains(cliente)).ToList();
        }
    }
}
