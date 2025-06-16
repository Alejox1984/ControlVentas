using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using DAL.Entidades;
using DAL.Interfaces;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void AddProducto(Producto producto)
        {
            const string query = @"
        INSERT INTO TProducto (
            idCompra, idStatus, idCategoria, producto, 
            preciomxO, preciomxF, preciousO, preciousF, 
            cantidad, localizadorTransportista, localizadorPlataforma, 
            fechaEEI, fechaEEF, fechaEC, imagenP
        ) VALUES (
            @idCompra, @idStatus, @idCategoria, @producto, 
            @preciomxO, @preciomxF, @preciousO, @preciousF, 
            @cantidad, @localizadorTransportista, @localizadorPlataforma, 
            @fechaEEI, @fechaEEF, @fechaEC, @imagenP
        )";

            try
            {
                // En lugar de usar un objeto anónimo con propiedades individuales,
                // usamos DynamicParameters para controlar mejor cómo se pasan los parámetros
                var parametros = new DynamicParameters();

                parametros.Add("@idCompra", producto.idCompra);
                parametros.Add("@idStatus", producto.idStatus);
                parametros.Add("@idCategoria", producto.idCategoria);
                parametros.Add("@producto", producto.producto);
                parametros.Add("@preciomxO", producto.preciomxO);
                parametros.Add("@preciomxF", producto.preciomxF);
                parametros.Add("@preciousO", producto.preciousO);
                parametros.Add("@preciousF", producto.preciousF);
                parametros.Add("@cantidad", producto.cantidad);
                parametros.Add("@localizadorTransportista", producto.localizadorTransportista);
                parametros.Add("@localizadorPlataforma", producto.localizadorPlataforma);
                parametros.Add("@fechaEEI", producto.fechaEEI);
                parametros.Add("@fechaEEF", producto.fechaEEF);
                parametros.Add("@fechaEC", producto.fechaEC);

                // Importante: Pasar el arreglo de bytes como un parámetro DbType.Binary
                parametros.Add("@imagenP", producto.imagenP, DbType.Binary);

                _dbConnection.Execute(query, parametros);
                Console.WriteLine("Query ejecutado correctamente.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                throw;
            }
        }

        public void EliminarProducto(int idProducto)
        {
            const string query = "DELETE FROM TProducto WHERE idProducto = @idProducto";
            _dbConnection.Execute(query, new { idProducto });
        }

        public void ModificarProducto(int idProducto, Producto camposActualizar)
        {
            var propiedades = camposActualizar.GetType().GetProperties();
            var parametros = new DynamicParameters();
            var updates = new System.Collections.Generic.List<string>();

            foreach (var prop in propiedades)
            {
                if (prop.Name == "idProducto") continue;

                var valor = prop.GetValue(camposActualizar);
                if (valor == null || valor.Equals(GetDefaultValue(prop.PropertyType))) continue;

                updates.Add($"{prop.Name} = @{prop.Name}");
                parametros.Add(prop.Name, valor);
            }

            if (updates.Any())
            {
                parametros.Add("idProducto", idProducto);
                string query = $"UPDATE TProducto SET {string.Join(", ", updates)} WHERE idProducto = @idProducto";
                _dbConnection.Execute(query, parametros);
            }
        }
        public void ActualizarProductoTransportista(int idProducto, decimal precio, string localizadorTransportista, int idStatus)
        {
            try
            {
                const string query = @"
            UPDATE TProducto 
            SET preciomxF = @precio,
                localizadorTransportista = @localizadorTransportista,
                idStatus = @idStatus
            WHERE idProducto = @idProducto";

                int rowsAffected = _dbConnection.Execute(query, new
                {
                    idProducto,
                    precio,
                    localizadorTransportista,
                    idStatus
                });

                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException($"No se encontró el producto con ID {idProducto}");
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Error de base de datos al actualizar transportista del producto {idProducto}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error inesperado al actualizar transportista del producto {idProducto}", ex);
            }
        }

        public List<ProductoCategoria> ListaProductosConCategoria(int id_compra)
        {
            string query = @"SELECT p.*, c.categoria AS NombreCategoria 
                    FROM TProducto p
                    JOIN TCategoria c ON p.idCategoria = c.idCategoria
                    WHERE p.idCompra = @id_compra";
            return _dbConnection.Query<ProductoCategoria>(query, new { id_compra }).ToList();
        }
        private object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        public byte[] GetOnlyImage(int productoId)
        {
            string query = "SELECT imagenP FROM TProducto WHERE idProducto = @id";

            // Creamos una nueva conexión específica para esta operación
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                connection.Open();
                return connection.ExecuteScalar<byte[]>(query, new { id = productoId });
            }
            // La conexión se cerrará automáticamente al salir del bloque using
        }
        public List<ProductoDTO> ObtenerProductosCombinados()
        {
            const string query = @"
        SELECT 
        p.idProducto, p.producto, p.preciomxO AS Precio, p.cantidad, 
        p.localizadorTransportista AS CodigoTransportista, p.localizadorPlataforma AS CodigoArticulo, p.imagenP, 
        c.nombre AS ClienteNombre, 
        cat.categoria AS Categoria, -- Añadido para recuperar el nombre de la categoría
        compra.fecha AS FechaCompra, 
        compra.codigo AS CodigoCompra, 
        sp.statusProducto AS Status 
        FROM TProducto p
        JOIN TCompra compra ON p.idCompra = compra.idCompra
        JOIN TCliente c ON compra.idCliente = c.id_cliente
        JOIN TStatusProducto sp ON p.idStatus = sp.idStatus
        JOIN TCategoria cat ON p.idCategoria = cat.idCategoria
        WHERE p.idStatus IN(1, 2, 4)";
            return _dbConnection.Query<ProductoDTO>(query).ToList();
        }
    }
}
