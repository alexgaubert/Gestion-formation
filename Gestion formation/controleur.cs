using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_formation
{
    public static class controleur
    {
        static modele vmodele;

        public static init(){
        }

        #region Accesseurs
        internal static modele Vmodele
        {
            get { return controleur.vmodele; }
            set { controleur.vmodele = value; }
        }
        #endregion
    }
}
