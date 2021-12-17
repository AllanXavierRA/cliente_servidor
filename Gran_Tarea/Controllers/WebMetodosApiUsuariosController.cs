using datos.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gran_Tarea.Controllers
{
    public class WebMetodosApiUsuariosController : Controller
    {
        //istancia de base de datos.
        NorthwindEntities conexion = new NorthwindEntities();

        // GET: WebMetodosApiUsuarios
        public ActionResult Index_Page1()
        {
            return View();
        }
        //web metodo listado de usarios.
        [HttpGet]
        public IEnumerable<Usuario> lista_de_usuarios()
        {
            var listausuarios = conexion.Usuario.ToList();
            return listausuarios;
        }


        //busqueda de usario especifico.
        [HttpGet]
        public Usuario Buscar_Usuario(int id)
        {
            var datousuario = conexion.Usuario.FirstOrDefault(a => a.usrid == id);
            return datousuario;
        }
        //Metodo de actualizacion.
        [HttpPost]
        public bool Insertar_Usuario(Usuario user)
        {
            conexion.Usuario.Add(user);
            return conexion.SaveChanges() > 0;
        }
        //actualizacion
        [HttpPut]
        public bool actualizar_Usuario(Usuario user)
        {
            var actualizarusuario = conexion.Usuario.FirstOrDefault(a => a.usrid == user.usrid);
            actualizarusuario.usrapellidop = user.usrapellidop;
            actualizarusuario.usrapellidom = user.usrapellidom;
            actualizarusuario.usrmail = user.usrmail;
            actualizarusuario.usrclave = user.usrclave;
            return conexion.SaveChanges() > 0;
        }
        //Eliminar usuario
        [HttpDelete]
        public bool eliminar_Usuario(Usuario user)
        {
            var eliminarusuario = conexion.Usuario.FirstOrDefault(a => a.usrid == user.usrid);
            conexion.Usuario.Remove(eliminarusuario);

            return conexion.SaveChanges() > 0;

        }
    }
}