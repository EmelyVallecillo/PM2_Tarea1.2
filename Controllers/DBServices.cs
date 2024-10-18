using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;
using SQLite;
using System.IO;
using Microsoft.Maui.Storage;



namespace MauiApp1.Controllers
{
    public class DBServices
    {
        readonly SQLiteAsyncConnection _connection;
        public DBServices()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
                    SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBAutores.db3"), extensiones);
            _connection.CreateTableAsync<Autores>();
        }

        //CREATE
        public async Task <int> biblioteca(Models.Autores aut)
        {
            if (aut.Id == 0)
            {
                return await _connection.InsertAsync(aut);
            }
            else
            {
                return await _connection.UpdateAsync(aut);
            }
        }

        //READ
        public async Task<List<Models.Autores>> GetListAutor()
        {
            return await _connection.Table<Models.Autores>().ToListAsync();
        }

        //READ ID
        public async Task<Models.Autores> GetAutor(int pid)
        {
            return await _connection.Table<Models.Autores>().Where(i=>i.Id == pid).FirstOrDefaultAsync();
        }

        //DELETE

        /* public async Task<int> DeleteAutor(Models.Autores autor)
         {
             return await _connection.DeleteAsync(autor);
         }
        */

    }
}
