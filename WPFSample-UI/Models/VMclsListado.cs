using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPFSample;

namespace WPFSample_UI.Models
{
    public class VMclsListado
    {
        public clsListadosBL lista {get;set;}
        public int cantidad { get; set; }
        
        public VMclsListado()
        {
            
            this.lista = new clsListadosBL();
            this.cantidad = lista.listarBL().Count();
        }
    }
}