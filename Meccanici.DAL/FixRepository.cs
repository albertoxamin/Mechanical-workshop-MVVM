using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public class FixRepository : IFixRepository
    {
        private List<Riparazione> fixes;

        public void DeleteFix(Riparazione fix)
        {
            fixes.Remove(fix);
        }

        public List<Riparazione> GetAllFixes()
        {
            if (fixes == null)
                LoadFixes();
            return fixes;
        }

        public List<Riparazione> GetCarFixes(string targa)
        {
            if (fixes == null)
                LoadFixes();
            return fixes.Where(x => x.CarID == targa).ToList();
        }

        public List<Riparazione> GetMechanicFixes(int mechId)
        {
            if (fixes == null)
                LoadFixes();
            return fixes.Where(x => x.MechanicID == mechId).ToList();
        }

        public Riparazione GetFixDetail(int fixID)
        {
            if (fixes == null)
                LoadFixes();
            return fixes.Where(x => x.ID == fixID).FirstOrDefault();
        }

        public void UpdateFix(Riparazione fix)
        {
            Riparazione fixToUpdate = fixes.Where(x => x.ID == fix.ID).FirstOrDefault();
            fixToUpdate = fix;
        }
        private const string TABLE_NAME = "fix";
        private async void LoadFixes()
        {
            fixes = new List<Riparazione>();
            var res = DBConnection.instance.ExecuteQuery(string.Format("SELECT * FROM {0}", TABLE_NAME)).Result;
            while (res.Read())
            {
                fixes.Add(new Riparazione()
                {
                    ID = (int)res["FixID"],
                    Date = (DateTime)res["Date"],
                    Note = (string)res["Notes"],
                    CarID = (string)res["Car_Plate"],
                    MechanicID = (int)res["Mech_ID"]
                });
            }
            res.Close();
            //{
            //new Riparazione() { ID=1, CarID="FI007NE", Date=new DateTime(2016,11,15), MechanicID=1, Note="Sostituite le ruote" },
            //new Riparazione() { ID=2, CarID="FI007NE", Date=new DateTime(2016,10,14), MechanicID=2, Note="Cambio d'olio" },
            //new Riparazione() { ID=3, CarID="FI007NE", Date=new DateTime(2016,9 ,12), MechanicID=1, Note="Ricaricata la batteria" },
            //new Riparazione() { ID=4, CarID="FI007NE", Date=new DateTime(2016,8 ,11), MechanicID=1, Note="Cambiata la cinghia" },
            //new Riparazione() { ID=5, CarID="FI007NE", Date=new DateTime(2016,6 ,9 ), MechanicID=2, Note="Tolto il voltante" },
            //new Riparazione() { ID=6, CarID="FI001NE", Date=new DateTime(2016,2,22), MechanicID=1, Note="asdd le ruote" },
            //new Riparazione() { ID=7, CarID="FI001NE", Date=new DateTime(2016,1,21), MechanicID=2, Note="ad d'olio" },
            //new Riparazione() { ID=8, CarID="FI001NE", Date=new DateTime(2015,12,12), MechanicID=1, Note="ads la batteria" }
            //};
        }

        public void NewFix(Riparazione fix)
        {
            string values = "'" + fix.Date.ToString("u") + "','" + fix.Note + "','" + fix.CarID + "'," + fix.MechanicID;
            DBConnection.instance.InsertInto(TABLE_NAME, "Date,Notes,Car_Plate,Mech_ID", values);
            LoadFixes();
        }
    }
}
