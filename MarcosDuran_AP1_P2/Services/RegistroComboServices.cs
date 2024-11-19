using MarcosDuran_AP1_P2.DAL;
using MarcosDuran_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;


namespace MarcosDuran_AP1_P2.Services
{
    public class RegistroComboServices(IDbContextFactory<Context> DbFactory)
    {
        private readonly Context _context;
        public async Task<bool> Existe(int RegistroComboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.RegistroCombo.AnyAsync(c => c.ComboId == RegistroComboId);
          
        }

        public async Task<bool> Modificar(RegistroCombo registroCombo)
        {
        }

        public async Task<bool> Guardar(RegistroCombo registroCombo)
        {

        }

        public async Task<bool> Eliminar(int ComboId)
        {

        }

        public async Task<Registro> Buscar(int CombooId)
        {

        }
        public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
        {

        }
