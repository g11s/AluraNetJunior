using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }

        public async Task<Categoria> FirstOrCreate(string nome)
        {
            try
            {
                Categoria categoria = await dbSet.FirstOrDefaultAsync(p => p.Nome == nome);

                if (categoria == null)
                {
                    categoria = new Categoria(nome);
                    dbSet.Add(categoria);

                    await contexto.SaveChangesAsync();
                }

                return categoria;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task SaveCategorias(List<Categoria> categorias)
        {
            foreach (var categoria in categorias)
            {
                if (!dbSet.Where(p => p.Nome == categoria.Nome).Any())
                {
                    dbSet.Add(new Categoria(categoria.Nome));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }
}
