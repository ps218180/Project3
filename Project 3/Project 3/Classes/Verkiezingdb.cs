using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_3.Classes
{
    class Verkiezingdb
    {
        #region fields
        MySqlConnection _connection = new MySqlConnection("Port=3309;Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion

        #region functions
        public DataTable SelectPartij()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM partij";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public DataTable SelectStandpunt()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM standpunt";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public DataTable SelectVerkiezingPartij()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM partij_verkiezing";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        #endregion
    }
}
