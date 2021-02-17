using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> FirstOrCreate(string nome);
        Task SaveCategorias(List<Categoria> categorias);
        IList<Categoria> GetCategorias();
    }
}