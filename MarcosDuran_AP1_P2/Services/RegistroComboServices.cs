using MarcosDuran_AP1_P2.Components.Pages.RegistroPages;
using MarcosDuran_AP1_P2.DAL;
using MarcosDuran_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Insertar(RegistroCombo registroCombo)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();

            foreach (var combo in registroCombo.registroComboDetalle)
            {
                var articulo = await BuscarArticulos(combo.ArticuloId);

                if (articulo != null)
                {
                    if (articulo.Existencia < combo.Cantidad)
                    {
                        return false;
                    }
                    articulo.Existencia -= combo.Cantidad;
                    _context.Articulos.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                else
                {

                    return false;
                }
            }
            _context.RegistroCombo.Add(registroCombo);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Modificar(RegistroCombo registroCombo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            contexto.Update(registroCombo);
            return await contexto.SaveChangesAsync() > 0;
        }


        public async Task<bool> Guardar(RegistroCombo registroCombo)
        {
            if (!await Existe(registroCombo.ComboId))
            {
                return await Insertar(registroCombo);
            }
            else
                return await Modificar(registroCombo);
        }


        public async Task<bool> Eliminar(int ComboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var detalles = await BuscarRegistroComboDetalle(ComboId);

            foreach (var detalle in detalles)
            {
                var articulo = await BuscarArticulos(detalle.ArticuloId);
                if (articulo != null)
                {
                    articulo.Existencia += detalle.Cantidad;
                    await ActualizarArticulo(articulo);
                }
            }
            var cobro = await _context.RegistroCombo
                        .Include(c => c.registroComboDetalle)
                        .FirstOrDefaultAsync(c => c.ComboId == ComboId);

            if (cobro == null) return false;

            _context.RegistroComboDetalle.RemoveRange(cobro.registroComboDetalle);
            _context.RegistroCombo.Remove(cobro);

            var cantidad = await _context.SaveChangesAsync();
            return cantidad > 0;
        }


        public async Task<bool> EliminarDetalle(int detalleId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            if (await ExisteDetalle(detalleId))
            {
                var comboDetalle = await _context.RegistroComboDetalle.FirstOrDefaultAsync(c => c.DetalleId == detalleId);

                var articulo = await _context.Articulos.FindAsync(comboDetalle.ArticuloId);

                if (articulo is null)
                {
                    return false;
                }
                else
                {
                    articulo.Existencia += comboDetalle.Cantidad;
                    _context.Articulos.Update(articulo);
                }
                _context.RegistroComboDetalle.Remove(comboDetalle);
            }

            else
            {
                var combos = await _context.RegistroComboDetalle.FirstOrDefaultAsync(c => c.DetalleId == detalleId);

                if (combos is null)
                {
                    return false;
                }

                _context.RegistroComboDetalle.Remove(combos);
            }

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Articulos> BuscarArticulos(int id)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ArticuloId == id);
        }


        public async Task<bool> ActualizarArticulo(Articulos articulo)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            _context.Articulos.Update(articulo);
            return await _context
                .SaveChangesAsync() > 0;
        }


        public async Task<RegistroCombo> Buscar(int ComboId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.RegistroCombo
                .Include(c => c.registroComboDetalle)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ComboId == ComboId);
        }


        public async Task<List<RegistroCombo>> Listar(Expression<Func<RegistroCombo, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.RegistroCombo
                .Include(c => c.registroComboDetalle)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<Articulos>> GetArticulos()
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.Articulos
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<RegistroComboDetalle>> BuscarRegistroComboDetalle(int comboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.RegistroComboDetalle
                .Include(a => a.Articulos)
                .Where(t => t.ComboId == comboId)
                 .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<RegistroComboDetalle>> ListarComboDetalle(int comboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var cotizacionDetalle = await _context.RegistroComboDetalle
                .Where(d => d.ComboId == comboId)
                .ToListAsync();

            return cotizacionDetalle;
        }


        private async Task<bool> ExisteDetalle(int detalleId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.RegistroComboDetalle.AnyAsync(ed => ed.DetalleId == detalleId);
        }
    }
}