using System.Collections.Generic;

namespace Dio.series.Interfaces
{
    public interface IRepository
    {
       List<T> Lista();
       T RetornaPorId(int id);
       void Insere(T entidade);
       void Exclui(int id);
       void Atualiza(int id, T entidade);
       int ProximoId();   
    }

    public class T
    {
    }
}