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
        MySqlConnection _connection = new MySqlConnection("sServer=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #endregion

        #region functions
        #region select
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
        public DataTable SelectThema()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM thema";
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
        public DataTable SelectVerkiezing()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezing";
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
        public DataTable SelectVerkiezingsoort()
        {
            DataTable result = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezingsoort";
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

        #region insert
        public bool Insertpartij(string naam, string adres, string postcode, string gemeente, string email, string telefoonnummer)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `partij` (`naam`, `adres`, `postcode`, `gemeente`, `emailadres`, `telefoonnummer`) VALUES (@naam, @adres, @postcode, @gemeente, @email, @telefoonnummer);";
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@postcode", postcode);
                command.Parameters.AddWithValue("@gemeente", gemeente);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        public bool Insertstandpunt(int themaid, string standpunt)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `standpunt` (`thema_id`, `standpunt`) VALUES (@themaid, @standpunt);";
                command.Parameters.AddWithValue("@themaid", themaid);
                command.Parameters.AddWithValue("@standpunt", standpunt);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        public bool InsertThema(string thema)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `thema` (`thema`) VALUES (@thema);";
                command.Parameters.AddWithValue("@thema", thema);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        #endregion

        #region update
        public bool Updatepartij(int partij_id, string naam, string adres, string postcode, string gemeente, string email, string telefoonnummer)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `partij` SET `naam` = @naam, `adres` = @adres, `postcode` = @postcode, `gemeente` = @gemeente, `emailadres` = @email, `telefoonnummer` = @telefoonnummer WHERE `partij`.`partij_id` = @partij_id;";
                command.Parameters.AddWithValue("@partij_id", partij_id);
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@postcode", postcode);
                command.Parameters.AddWithValue("@gemeente", gemeente);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                int nraffected = command.ExecuteNonQuery();
                succes = (nraffected != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }

        public bool Updatestandpunt(int standpuntid, int themaid, string standpunt)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `standpunt` SET `thema_id` = @themaid, `standpunt` = @standpunt WHERE `standpunt`.`standpunt_id` = @standpunt_id;";
                command.Parameters.AddWithValue("@standpunt_id", standpuntid);
                command.Parameters.AddWithValue("@themaid", themaid);
                command.Parameters.AddWithValue("@adres", standpunt);
                int nraffected = command.ExecuteNonQuery();
                succes = (nraffected != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        public bool UpdateThema(int thema_ID, string thema)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `thema` SET `thema` = @thema WHERE `thema`.`thema_id` = @thema_id;";
                command.Parameters.AddWithValue("@thema_id", thema_ID);
                command.Parameters.AddWithValue("@thema", thema);
                int nraffected = command.ExecuteNonQuery();
                succes = (nraffected != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        #endregion

        #region delete
        public bool DeletePartij(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `partij` WHERE `partij`.`partij_id` = @partij_id;";
                command.Parameters.AddWithValue("@partij_id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Verwijder of pas eerst de drivers aan die bijhoorend zijn bij het team dat u wilt verwijderen");
            }
            finally
            {
                _connection.Close();
            }
            return succes;
            }
        public bool DeleteThema(string id)
        {
            bool succes = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `thema` WHERE `thema`.`thema_id` = @thema_id;";
                command.Parameters.AddWithValue("@thema_id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Verwijder of pas eerst de drivers aan die bijhoorend zijn bij het team dat u wilt verwijderen");
            }
            finally
            {
                _connection.Close();
            }
            return succes;
        }
        #endregion

        #endregion
    }
}