using System;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace WebAppProj1.Models
{
    public class GuestInventory
    {

        // all database
        private const string CONNECTION_STRING = "Server=localhost;Database=firstdb;Uid=chris;Pwd=password;SslMode=none;";
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;

        // main list for entrys
        private List<Guests> _mainGuestList;

        // user input strings
        private string _user_FName;
        private string _user_LName;
        private string _user_Entry;
        //Date it was submitted
        private string _user_DateEntry;

     public GuestInventory() {
         _mainGuestList = new List<Guests>();
         dbConnection = new MySqlConnection(CONNECTION_STRING);
         dbCommand = new MySqlCommand("", dbConnection);
     }
//--------------------------------------get sets
    public string user_FName {
        get {return _user_FName;} set {_user_FName = value;}
    }
     public string user_LName {
        get {return _user_LName;} set {_user_LName = value;}
    }
     public string user_Entry {
        get {return _user_Entry;} set {_user_Entry = value;}
    }
     public string user_DateEntry {
        get {return _user_DateEntry;} set {_user_DateEntry = value;}
    }

//---------------------------------List for entrys to display from database
    public List<Guests> mainGuestList {
        get{
            return _mainGuestList;
        } 
    }

//------------------------------------On submission of entry, insert new entry into database
    public void submitEntry(){
        Console.WriteLine("*****Entry entered");
        Console.WriteLine(_user_FName);
        Console.WriteLine(_user_LName);
        Console.WriteLine(_user_Entry);
        Console.WriteLine(_user_DateEntry);

        try {
            dbConnection.Open();
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = "INSERT INTO tblGuests (firstName, lastName, entryDate, entry) VALUES (?firstName, ?lastName, ?entryDate, ?entry)";
            
            dbCommand.Parameters.AddWithValue("?firstName", _user_FName);
            dbCommand.Parameters.AddWithValue("?lastName", _user_LName);
            dbCommand.Parameters.AddWithValue("?entryDate", _user_DateEntry);
            dbCommand.Parameters.AddWithValue("?entry", _user_Entry);


            dbCommand.ExecuteNonQuery();

        } catch (Exception e) {
            Console.WriteLine(">>> An error has occured while inserting data" + e.Message);
        } finally {
            dbConnection.Close();
        }

    }

//------------------------------------Call private methods

public void setupData(){
    populateEntrys();
    //submitEntry(_user_FName,_user_LName,user_Entry,_user_DateEntry);
}

//-----------------------------------Grabbing data from database
    private void populateEntrys(){
        Console.WriteLine("Inside populateEntrys()");
        try {
            dbConnection.Open();
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = "SELECT * FROM tblGuests";
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read()) {
                Guests guests = new Guests();
                guests.firstName = dbReader["firstName"].ToString();
                guests.lastName = dbReader["lastName"].ToString();
                guests.date = dbReader["entryDate"].ToString();
                guests.entry = dbReader["entry"].ToString();
                
                _mainGuestList.Add(guests);
            }
            dbReader.Close();
        } catch (Exception e) {
            Console.WriteLine(">>> An error has occured with with DB retrieval" + e.Message);
        } finally {
            dbConnection.Close();
        }
    }
     
    }
}