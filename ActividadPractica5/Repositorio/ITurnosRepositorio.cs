using ActividadPractica5.Modelos;

namespace ActividadPractica5.Repositorio
{
    public interface ITurnosRepositorio
    {
        List<TTurno> GetALL(int id, string fecha, string hora, string cliente);
        bool Crear(TTurno turno);
        bool Actualizar(int id, TTurno turnoActualizado);
        bool BajaTurnos(int id);
    }
}
