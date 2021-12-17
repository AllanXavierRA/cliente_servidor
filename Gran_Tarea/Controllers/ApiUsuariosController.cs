using datos.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Gran_Tarea.Controllers
{
    public class ApiProductsController : ApiController
    {
        NorthwindEntities conexion = new NorthwindEntities();

        // GET: WebMetodosApiUsuarios
       
        //web metodo listado de usarios.
        [HttpGet]
        public IEnumerable<Products> lista_de_productos()
        {
            var listaproductos = conexion.Products.ToList();
            return listaproductos;
        }


        //busqueda de usario especifico.
        [HttpGet]
        public Products Buscar_Producto(int id)
        {
            var datoproducto = conexion.Products.FirstOrDefault(a => a.ProductID == id);
            return datoproducto;
        }
        //Metodo de actualizacion.
        [HttpPost]
        public bool Insertar_Producto(Products insumo)
        {
            conexion.Products.Add(insumo);
            return conexion.SaveChanges() > 0;
        }
        //actualizacion
        [HttpPut]
        public bool actualizar_Usuario(Products insumo)
        {
            var actualizarproducto = conexion.Products.FirstOrDefault(a => a.ProductID == insumo.ProductID);
            actualizarproducto.ProductName = insumo.ProductName;
            actualizarproducto.UnitPrice = insumo.UnitPrice;
            actualizarproducto.UnitsInStock = insumo.UnitsInStock;
            actualizarproducto.UnitsOnOrder = insumo.UnitsOnOrder;
            return conexion.SaveChanges() > 0;
        }
        //Eliminar usuario
        [HttpDelete]
        public bool eliminar_producto(Products insumo)
        {
            var eliminarproducto = conexion.Products.FirstOrDefault(a => a.ProductID == insumo.ProductID);
            conexion.Products.Remove(eliminarproducto);

            return conexion.SaveChanges() > 0;

        }
    }

}
