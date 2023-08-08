using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace Delosi.Models
{
    public class Punto_de_Venta
    {
        [Display(Name = "Nom_Empresa")] public string nom_empresa_ws { get; set; }
        [Display(Name = "Tienda")] public string comp_tienda_ws { get; set; }
        [Display(Name = "Num_Tienda")] public string num_tienda_ws { get; set; }
        [Display(Name = "Nomb_Teinda")] public string nomb_teinda_ws { get; set; }
        [Display(Name = "IP_WS")] public string ip_ws { get; set; }
        [Display(Name = "Estado_Tienda")] public string estado_tienda { get; set; }
        [Display(Name = "Modelo")] public string modelo { get; set; }
        [Display(Name = "Status_WS")] public string status_ws { get; set; }
        [Display(Name = "Join_Tienda")] public string join_tienda { get; set; }
    }
}