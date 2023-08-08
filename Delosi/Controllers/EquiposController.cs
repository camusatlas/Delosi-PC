using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Delosi.Models;

namespace Delosi.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        //Listado de Servidor - Punto de Venta - KDS
        IEnumerable<Servidor> servidors()
        {
            List<Servidor> lista = new List<Servidor>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Servidores", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidor
                {
                    nom_emp = dr.GetString(0),
                    comp_tienda_servidor = dr.GetString(1),
                    num = dr.GetString(2),
                    departamento = dr.GetString(3),
                    provincia = dr.GetString(4),
                    distrito = dr.GetString(5),
                    region = dr.GetString(6),
                    servidor_ip = dr.GetString(7),
                    hostname = dr.GetString(8),
                    tamaño_bd = dr.GetString(9),
                    estado_tienda = dr.GetString(10),
                    vers_micros = dr.GetString(11),
                    so = dr.GetString(12),
                    ram = dr.GetString(13),
                    model_equipo = dr.GetString(14),
                    serial_equipo = dr.GetString(15),
                    nom_tienda = dr.GetString(16),
                    tecnico_asigando = dr.GetString(17),
                    fecha_instalacion = dr.GetString(18),
                    observaciones = dr.GetString(19),
                    NomTiendaDWH = dr.GetString(20),
                    Email = dr.GetString(21),
                    telefono_tienda = dr.GetString(22),
                    direccion_tienda = dr.GetString(23),
                    Latitud = dr.GetString(24),
                    Longitud = dr.GetString(25),
                    Categoria = dr.GetString(26),
                    join_tienda = dr.GetString(27)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        //Listado de Punto de Venta
        IEnumerable<Punto_de_Venta> punto_De_Ventas()
        {
            List<Punto_de_Venta> lista = new List<Punto_de_Venta>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Punto_Venta", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Punto_de_Venta
                {
                    nom_empresa_ws = dr.GetString(0),
                    comp_tienda_ws = dr.GetString(1),
                    num_tienda_ws = dr.GetString(2),
                    nomb_teinda_ws = dr.GetString(3),
                    ip_ws = dr.GetString(4),
                    estado_tienda = dr.GetString(5),
                    modelo = dr.GetString(6),
                    status_ws = dr.GetString(7),
                    join_tienda = dr.GetString(8),
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        //Listado de KDS
        IEnumerable<Kds> kds()
        {
            List<Kds> lista = new List<Kds>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_KDS", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Kds
                {
                    nom_empresa_kds = dr.GetString(0),
                    comp_tienda_kds = dr.GetString(1),
                    num_tienda_kds = dr.GetString(2),
                    nomb_teinda_kds = dr.GetString(3),
                    ip_kds = dr.GetString(4),
                    hostname = dr.GetString(5),
                    estado_tienda = dr.GetString(6),
                    modelo = dr.GetString(7),
                    status_kds = dr.GetString(8),
                    join_tienda = dr.GetString(9),
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        //Imsertar Servidor - Punto de Venta - KDS
    string AgregarServidor(Servidor reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_Servidores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Emp", reg.nom_emp);
                cmd.Parameters.AddWithValue("@Comp_Tienda", reg.comp_tienda_servidor);
                cmd.Parameters.AddWithValue("@Num", reg.num);
                cmd.Parameters.AddWithValue("@Departamento", reg.departamento);
                cmd.Parameters.AddWithValue("@Provincia", reg.provincia);
                cmd.Parameters.AddWithValue("@Distrito", reg.distrito);
                cmd.Parameters.AddWithValue("@Region", reg.region);
                cmd.Parameters.AddWithValue("@Servidor_IP", reg.servidor_ip);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.tamaño_bd);
                cmd.Parameters.AddWithValue("@Vers_Micros", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Tamaño_BD", reg.vers_micros);
                cmd.Parameters.AddWithValue("@S_O", reg.so);
                cmd.Parameters.AddWithValue("@Ram", reg.ram);
                cmd.Parameters.AddWithValue("@Model_Equipo", reg.model_equipo);
                cmd.Parameters.AddWithValue("@Serial_Equipo", reg.serial_equipo);
                cmd.Parameters.AddWithValue("@Nom_Tienda", reg.nom_tienda);
                cmd.Parameters.AddWithValue("@Tecnico_Asigando", reg.tecnico_asigando);
                cmd.Parameters.AddWithValue("@Fecha_Instalacion", reg.fecha_instalacion);
                cmd.Parameters.AddWithValue("@Observaciones", reg.observaciones);
                cmd.Parameters.AddWithValue("@Nom_Tienda_DWH", reg.NomTiendaDWH);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono_Tienda", reg.telefono_tienda);
                cmd.Parameters.AddWithValue("@Direccion_Tienda", reg.direccion_tienda);
                cmd.Parameters.AddWithValue("@Latitud", reg.Latitud);
                cmd.Parameters.AddWithValue("@Longitud", reg.Longitud);
                cmd.Parameters.AddWithValue("@Categoria", reg.Categoria);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Servidor...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        //Punto de Venta
        string AgregarPuntoVenta(Punto_de_Venta reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_Punto_Ventas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_ws);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_ws);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_ws);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_teinda_ws);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_ws);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_ws);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Punto de Venta...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        //KDS
        string AgregarKDS(Kds reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_KDS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_kds);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_kds);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_kds);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_teinda_kds);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_kds);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_kds);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);

                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Kds...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }


        //Actualizar Servidor - Punto de Venta - KDS
        //Servidor
        string ActualizarServidor(Servidor reg)
        {
           string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_Servidores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Emp", reg.nom_emp);
                cmd.Parameters.AddWithValue("@Comp_Tienda", reg.comp_tienda_servidor);
                cmd.Parameters.AddWithValue("@Num", reg.num);
                cmd.Parameters.AddWithValue("@Departamento", reg.departamento);
                cmd.Parameters.AddWithValue("@Provincia", reg.provincia);
                cmd.Parameters.AddWithValue("@Distrito", reg.distrito);
                cmd.Parameters.AddWithValue("@Region", reg.region);
                cmd.Parameters.AddWithValue("@Servidor_IP", reg.servidor_ip);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.tamaño_bd);
                cmd.Parameters.AddWithValue("@Vers_Micros", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Tamaño_BD", reg.vers_micros);
                cmd.Parameters.AddWithValue("@S_O", reg.so);
                cmd.Parameters.AddWithValue("@Ram", reg.ram);
                cmd.Parameters.AddWithValue("@Model_Equipo", reg.model_equipo);
                cmd.Parameters.AddWithValue("@Serial_Equipo", reg.serial_equipo);
                cmd.Parameters.AddWithValue("@Nom_Tienda", reg.nom_tienda);
                cmd.Parameters.AddWithValue("@Tecnico_Asigando", reg.tecnico_asigando);
                cmd.Parameters.AddWithValue("@Fecha_Instalacion", reg.fecha_instalacion);
                cmd.Parameters.AddWithValue("@Observaciones", reg.observaciones);
                cmd.Parameters.AddWithValue("@Nom_Tienda_DWH", reg.NomTiendaDWH);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono_Tienda", reg.telefono_tienda);
                cmd.Parameters.AddWithValue("@Direccion_Tienda", reg.direccion_tienda);
                cmd.Parameters.AddWithValue("@Latitud", reg.Latitud);
                cmd.Parameters.AddWithValue("@Longitud", reg.Longitud);
                cmd.Parameters.AddWithValue("@Categoria", reg.Categoria);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} Servidor...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        //Punto de Venta
        string ActualizarPuntoVenta(Punto_de_Venta reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_Punto_Venta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_ws);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_ws);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_ws);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_teinda_ws);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_ws);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_ws);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} Punto de Venta...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        //KDS
        string ActualizarKDS(Kds reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_KDS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_kds);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_kds);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_kds);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_teinda_kds);
                cmd.Parameters.AddWithValue("@IP_KDS", reg.ip_kds);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Modelo", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Status_WS", reg.modelo);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.status_kds);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} KDS...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult Index()
        {
            return View(servidors());
        }
        //Crear Iformacion
        //Servidor
        public ActionResult Create()
        {
            ViewBag.servidors = new SelectList(servidors(),"nom_emp","comp_tienda_servidor");
            return View(new Servidor());
        }
        [HttpPost] public ActionResult Create(Servidor reg)
        {
            ViewBag.mensaje = AgregarServidor(reg);
            return View(new Servidor());
        }

        //Crear Punto de Venta
        public ActionResult CreatePuntoVenta()
        {
            ViewBag.servidors = new SelectList(punto_De_Ventas(), "nom_empresa_ws", "comp_tienda_ws");
            return View(new Punto_de_Venta());
        }
        [HttpPost]
        public ActionResult CreatePuntoVenta(Punto_de_Venta reg)
        {
            ViewBag.mensaje = AgregarPuntoVenta(reg);
            return View(new Punto_de_Venta());
        }
        //Crear KDS
        public ActionResult CreateKDS()
        {
            ViewBag.servidors = new SelectList(kds(), "nom_empresa_kds", "comp_tienda_kds");
            return View(new Kds());
        }
        [HttpPost]
        public ActionResult CreateKDS(Kds reg)
        {
            ViewBag.mensaje = AgregarKDS(reg);
            return View(new Kds());
        }

        //Busqueda Servidores
        IEnumerable<Servidor> buscarServidor(string nombre)
        {
            List<Servidor> lista = new List<Servidor>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("BuscServidor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nom_Tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidor
                {
                    nom_emp = dr.GetString(0),
                    comp_tienda_servidor = dr.GetString(1),
                    num = dr.GetString(2),
                    departamento = dr.GetString(3),
                    provincia = dr.GetString(4),
                    distrito = dr.GetString(5),
                    region = dr.GetString(6),
                    servidor_ip = dr.GetString(7),
                    hostname = dr.GetString(8),
                    tamaño_bd = dr.GetString(9),
                    estado_tienda = dr.GetString(10),
                    vers_micros = dr.GetString(11),
                    so = dr.GetString(12),
                    ram = dr.GetString(13),
                    model_equipo = dr.GetString(14),
                    serial_equipo = dr.GetString(15),
                    nom_tienda = dr.GetString(16),
                    tecnico_asigando = dr.GetString(17),
                    fecha_instalacion = dr.GetString(18),
                    observaciones = dr.GetString(19),
                    NomTiendaDWH = dr.GetString(20),
                    Email = dr.GetString(21),
                    telefono_tienda = dr.GetString(22),
                    direccion_tienda = dr.GetString(23),
                    Latitud = dr.GetString(24),
                    Longitud = dr.GetString(25),
                    Categoria = dr.GetString(26),
                    join_tienda = dr.GetString(27)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarServidor(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(buscarServidor(nombre));
        }
        //Busqueda Punto de Venta
        IEnumerable<Punto_de_Venta> buscarPuntoVenta(string nombre)
        {
            List<Punto_de_Venta> lista = new List<Punto_de_Venta>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("BuscPuntoVenta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Punto_de_Venta
                {
                    nom_empresa_ws = dr.GetString(0),
                    comp_tienda_ws = dr.GetString(1),
                    num_tienda_ws = dr.GetString(2),
                    nomb_teinda_ws = dr.GetString(3),
                    ip_ws = dr.GetString(4),
                    estado_tienda = dr.GetString(5),
                    modelo = dr.GetString(6),
                    status_ws = dr.GetString(7),
                    join_tienda = dr.GetString(8)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarPuntoVenta(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(buscarPuntoVenta(nombre));
        }

        //Buscar KDS
        IEnumerable<Kds> buscarKDS(string nombre)
        {
            List<Kds> lista = new List<Kds>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("BuscKDS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Kds
                {
                    nom_empresa_kds = dr.GetString(0),
                    comp_tienda_kds = dr.GetString(1),
                    num_tienda_kds = dr.GetString(2),
                    nomb_teinda_kds = dr.GetString(3),
                    ip_kds = dr.GetString(4),
                    hostname = dr.GetString(5),
                    estado_tienda = dr.GetString(6),
                    modelo = dr.GetString(7),
                    status_kds = dr.GetString(8),
                    join_tienda = dr.GetString(9)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarKDS(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(buscarKDS(nombre));
        }
        //Editar Servidor
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Servidor reg = servidors().FirstOrDefault(x => x.nom_tienda == id);
            ViewBag.servidors = new SelectList(servidors(), "nom_emp", "comp_tienda_servidor");
            return View(reg);
        }
        [HttpPost]public ActionResult Edit(Servidor reg)
        {
            ViewBag.mensaje = ActualizarServidor(reg);
            return View(new Servidor());
        }
        //Editar Punto de Venta
        public ActionResult EditPuntoVenta(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Punto_de_Venta reg = punto_De_Ventas().FirstOrDefault(x => x.join_tienda == id);
            ViewBag.punto_De_Venta = new SelectList(punto_De_Ventas(), "nom_empresa_ws", "comp_tienda_ws");
            return View(reg);
        }
        [HttpPost]
        public ActionResult EditPuntoVenta(Punto_de_Venta reg)
        {
            ViewBag.mensaje = ActualizarPuntoVenta(reg);
            return View(new Punto_de_Venta());
        }
        //Editar KDS
        public ActionResult EditKDS(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Kds reg = kds().FirstOrDefault(x => x.join_tienda == id);
            ViewBag.punto_De_Venta = new SelectList(kds(), "nom_empresa_kds", "comp_tienda_kds");
            return View(reg);
        }
        [HttpPost]
        public ActionResult EditKDS(Kds reg)
        {
            ViewBag.mensaje = ActualizarKDS(reg);
            return View(new Kds());
        }

    }
}