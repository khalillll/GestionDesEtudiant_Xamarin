using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Data;

namespace App3
{
    public class Gestion_Etudiant
    {
        public readonly SQLiteAsyncConnection database;

        public Gestion_Etudiant(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Etudiant>().Wait();
            database.CreateTableAsync<Admin>().Wait();
            database.CreateTableAsync<Filiere>().Wait();

        }
        public Task<List<Etudiant>> GetConseilAsync()
        {
            return database.Table<Etudiant>().Where(i => i.Absence > 8).ToListAsync();
        }
        public Task<List<Etudiant>> GetEtudiantsAsync()
        {
            return database.Table<Etudiant>().ToListAsync();
        }

        public Task<List<Filiere>> GetFilieresAsync()
        {
            return database.Table<Filiere>().ToListAsync();
        }
        
        public Task<Etudiant> GetEtudiantAsync(int cne)
        {
            return database.Table<Etudiant>().Where(i => i.Cne == cne).FirstOrDefaultAsync();
        }
        public Task<Admin> GetAdminAsync(int id)
        {
            return database.Table<Admin>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }



        
        public IEnumerable<Etudiant> GetEtudiantfiliereconditionConseilAsync(String nomfiliere)
        {

            //ff = database.Table<Filiere>().Where(i => i.Filierename == nomfiliere).FirstOrDefaultAsync();
            //await Task.Delay(1000);
            //return database.ExecuteAsync("SELECT * FROM Etudiant JOIN Filiere ON Etudiant.IdFiliere = Filiere.Id WHERE Filiere.Filierename=" + nomfiliere + "");

            var db = new SQLiteConnection(database.GetConnection().DatabasePath);


            return db.Query<Etudiant>("select * from Etudiant inner join Filiere on Etudiant.IdFiliere = Filiere.Id where Etudiant.Absence > 8 and Filiere.Filierename = ?", nomfiliere);

        }
        public IEnumerable<Etudiant> GetEtudiantfiliereconditionAsync(String nomfiliere)
        {

            //ff = database.Table<Filiere>().Where(i => i.Filierename == nomfiliere).FirstOrDefaultAsync();
            //await Task.Delay(1000);
            //return database.ExecuteAsync("SELECT * FROM Etudiant JOIN Filiere ON Etudiant.IdFiliere = Filiere.Id WHERE Filiere.Filierename=" + nomfiliere + "");

            var db = new SQLiteConnection(database.GetConnection().DatabasePath);

            
            return db.Query<Etudiant>("select * from Etudiant inner join Filiere on Etudiant.IdFiliere = Filiere.Id where Filiere.Filierename = ?", nomfiliere);

        }






        public Task<Filiere> GetFiliereAsync(int ID)
        {
            return database.Table<Filiere>().Where(i => i.Id == ID).FirstOrDefaultAsync();
        }
        public Task<Filiere> GetFiliereAsync(String name)
        {
            return database.Table<Filiere>().Where(i => i.Filierename == name).FirstOrDefaultAsync();
        }

        public Task<Admin> GetAdminAsync(String user, String pass)
        {
            return database.Table<Admin>().Where(i => (i.Username == user && i.Password == pass)).FirstOrDefaultAsync();
        }

        public Task<int> SaveEtudiant(Etudiant etudiant)
        {
            if (etudiant.Id != 0)
            {
                return database.UpdateAsync(etudiant);
            }
            else
            {
                return database.InsertAsync(etudiant);
            }
        }


        public Task<int> Register_Admin(Admin admin)
        {
            if (admin.Id != 0)
            {
                return database.UpdateAsync(admin);
            }
            else
            {
                return database.InsertAsync(admin);
            }
        }


        public Task<int> AddFiliere(Filiere filiere)
        {
            if (filiere.Id != 0)
            {
                return database.UpdateAsync(filiere);
            }
            else
            {
                return database.InsertAsync(filiere);
            }
        }


        public Task<int> DeleteEtudiantasync(Etudiant etudiant)
        {
            return database.DeleteAsync(etudiant);
        }


    }
}
