using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace Gestion_formation
{
    class modele
    {
        private MySqlConnection myConnection;
        private MySqlDataAdapter mySqlDataAdapterTP7 = new MySqlDataAdapter();
        private DataSet dataSetTP7 = new DataSet();
        private DataView dv_formation = new DataView(), dv_personne = new DataView();
        private ArrayList rapport = new ArrayList();
        
        private bool connopen = false;
        private bool errgrave = false;
        private bool chargement = false;
        private bool errmaj = false;
        private char vaction, vtable;        

        public modele()
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

        public bool Errmaj
        {
            get { return errmaj; }
            set { errmaj = value; }
        }

        public char Vtable
        {
            get { return vtable; }
            set { vtable = value; }
        }

        public char Vaction
        {
            get { return vaction; }
            set { vaction = value; }
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

        private void OnRowUpdated(object sender, MySqlRowUpdatedEventArgs args)
        {
            string msg="";
            Int64 nb = 0;
            if (args.Status == UpdateStatus.ErrorsOccurred)
            {
                if (vaction == 'd' || vaction == 'u')
                {
                    MySqlCommand vcommand = myConnection.CreateCommand();
                    if (vtable == 'p')
                    {
                        vcommand.CommandText = "SELECT COUNT(*) FROM personne WHERE IdPersonne = '" +args.Row[0, DataRowVersion.Original] + "'";
                    }
                    nb = (Int64)vcommand.ExecuteScalar();
                }
                if (vaction == 'd')
                {
                    if (nb == 1)
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personnes : " + args.Row[0, DataRowVersion.Original] + "impossible delete car enr modifié dans la base";
                        }
                        rapport.Add(msg);
                        errmaj = true;
                    }
                }
                if (vaction == 'u')
                {
                    if (nb == 1)
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personne: " + args.Row[0, DataRowVersion.Original] + "impossible MAJ car enr modifié dans la base";
                        }
                        rapport.Add(msg);
                        errmaj = true;
                    }
                    else
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personne : " + args.Row[0, DataRowVersion.Original] + "impossible MAJ car enr supprimé dans la base";
                        }
                        rapport.Add(msg);
                        errmaj = true;
                    }
                }
                if (vaction == 'c')
                {
                    if (vtable == 'p')
                    {
                        msg = "pour le numéro de personne : " + args.Row[0, DataRowVersion.Current] + "impossible ADD car erreur données";
                    }
                    rapport.Add(msg);
                    errmaj = true;
                }
            }
        }

        public void add_personne()
        {
            vaction = 'c'; // on précise bien l’action, ici c pour create
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement ajout d'un enr de la table
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);
            mySqlDataAdapterTP7.InsertCommand = new MySqlCommand("insert into personne (nom,prenom,IdFormation) values(?nom,?prenom,?IdFormation)", myConnection);// notre commandbuilder ici ajout non fait si erreur de données
            //déclaration des variables utiles au commandbuilder
            // pas besoin de créer l’IdPersonne car en auto-increment
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFormation", MySqlDbType.Int16, 10, "IdFormation");
            //on continue même si erreur de MAJ
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;
            //table concernée 1 = personne
            DataTable table = dataSetTP7.Tables[1];
            //on ne s'occupe que des enregistrement ajoutés en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.Added));
            //désassocie la méthode sur l'événement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdated);
        }

        public void maj_personne()
        {
            vaction = 'u'; // on précise bien l’action, ici c pour create
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement ajout d'un enr de la table
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);
            mySqlDataAdapterTP7.UpdateCommand = new MySqlCommand("update personne set nom=?nom,prenom=?prenom, IdFormation=?IdFormation where IdPersonne = ?num ", myConnection);
            //déclaration des variables utiles au commandbuilder
            // pas besoin de créer l’IdPersonne car en auto-increment
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFormation", MySqlDbType.Int16, 10, "IdFormation");
            //on continue même si erreur de MAJ
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;
            //table concernée 1 = personne
            DataTable table = dataSetTP7.Tables[1];
            //on ne s'occupe que des enregistrement ajoutés en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.Added));
            //désassocie la méthode sur l'événement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdated);
        }

        public void del_personne()
        {
            vaction = 'd'; // on précise bien l’action, ici c pour create
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement ajout d'un enr de la table
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);
            mySqlDataAdapterTP7.DeleteCommand = new MySqlCommand("delete from personne where IdPersonne = ?num;", myConnection);// force le delete même si maj dans la base
            //déclaration des variables utiles au commandbuilder
            // pas besoin de créer l’IdPersonne car en auto-increment
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFormation", MySqlDbType.Int16, 10, "IdFormation");
            //on continue même si erreur de MAJ
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;
            //table concernée 1 = personne
            DataTable table = dataSetTP7.Tables[1];
            //on ne s'occupe que des enregistrement ajoutés en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.Added));
            //désassocie la méthode sur l'événement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdated);
        }
    }
}
