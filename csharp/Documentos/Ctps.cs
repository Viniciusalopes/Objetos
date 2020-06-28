using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentos
{
    class Ctps
    {
        #region ATRIBUTOS
        
		private int numeroCtps;
		private string serieCtps;

        #endregion ATRIBUTOS

        #region GET/SET
        public int NumeroCtps
		{
			get { return numeroCtps; }
			set { numeroCtps = value; }
		}

		public string SerieCtps
		{
			get { return serieCtps; }
			set { serieCtps = value; }
		}
		
		#endregion GET/SET
	}
}
