using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public interface IFixRepository
    {
        void DeleteFix(Riparazione fix);
        void NewFix(Riparazione fix);
        List<Riparazione> GetAllFixes();
        List<Riparazione> GetCarFixes(string targa);
        List<Riparazione> GetMechanicFixes(int mechId);
        Riparazione GetFixDetail(int fixID);
        void UpdateFix(Riparazione fix);
    }
}
