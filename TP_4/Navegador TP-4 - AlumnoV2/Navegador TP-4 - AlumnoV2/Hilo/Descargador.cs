using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    // Delegados
    public delegate void Progreso(int avance);
    public delegate void DescargaCompleta(string html);

    public class Descargador
    {
        // Atributos
        private string html;
        private Uri direccion;

        // Eventos
        public event Progreso progreso;
        public event DescargaCompleta descarga;

        // Constructor
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progreso(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                descarga(e.Result);
            }
            catch(Exception excep)
            {
                this.descarga(excep.Message);
            }
        }
    }
}
