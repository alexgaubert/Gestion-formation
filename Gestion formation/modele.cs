using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms; 

namespace Gestion_formation
{
    class modele
    {
        private MySqlConnection myConnection;
        private MySqlDataAdapter mySqlDataAdapterTP7 = new MySqlDataAdapter();
        private DataSet dataSetTP7 = new DataSet();
        private DataView dv_formation = new DataView(), dv_personne = new DataView();
        
        private bool connopen = false;
        private bool errgrave = false;
        private bool chargement = false;

        private modele()
        {

        }

        #region Accesseurs
        public bool Connopen
        {
            get { return connopen; }
            set { connopen = value; }
        }

        public bool Errgrave
        {
            get { return errgrave; }
            set { errgrave = value; }
        }

        public bool Chargement
        {
            get { return chargement; }
            set { chargement = value; }
        }

        public DataView Dv_personne
        {
            get { return dv_personne; }
            set { dv_personne = value; }
        }

        public DataView Dv_formation
        {
            get { return dv_formation; }
            set { dv_formation = value; }
        }
        #endregion

        public void seconnecter()
        {
            String myConnectionString = "Database=bd_ex_bddeconnectee;Data Source=localhost;User Id=root;";
            myConnection = new MySqlConnection(myConnectionString);

            try
            {
                myConnection.Open();
                connopen = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur ouveture bdd : " + err, "PBS connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connopen = false;
                errgrave = true;
            }
        }

        public void sedeconnecter()
        {
            if (!connopen)
            {
                return;
            }

            try
            {
                myConnection.Close();
                myConnection.Dispose();
                connopen = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur fermeture bdd : " + err, "PBS deconnection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errgrave = true;
            }
        }

        public void import()
        {
            if (!connopen) return;
            mySqlDataAdapterTP7.SelectCommand = new MySqlCommand("SELECT * FROM formation; SELECT * FROM personne;", myConnection);
            try
            {
                dataSetTP7.Clear();
                mySqlDataAdapterTP7.Fill(dataSetTP7);
                MySqlCommand vcommand = myConnection.CreateCommand();

                vcommand.CommandText = "SELECT AUTO_INCREMENT AS last_id FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'personne'";
                UInt64 der_personne = (UInt64)vcommand.ExecuteScalar();
                dataSetTP7.Tables[1].Columns[0].AutoIncrement = true;
                dataSetTP7.Tables[1].Columns[0].AutoIncrementSeed = Convert.ToInt64(der_personne);
                dataSetTP7.Tables[1].Columns[0].AutoIncrementStep = 1;

                dv_formation = dataSetTP7.Tables[0].DefaultView;
                dv_personne = dataSetTP7.Tables[1].DefaultView;

                chargement = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur chargement dataset : " + err, "PBS formation/personne", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errgrave = true;
            }
        }
    }
}
