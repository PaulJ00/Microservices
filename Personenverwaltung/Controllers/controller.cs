﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Personenverwaltung.Models;

namespace Personenverwaltung.Controllers
{
    public class controller
    {
        private List<Person> _ListPS;
        private List<user> uLIST;
        public List<Person> ListPS { get => _ListPS; set => _ListPS = value; }
        public List<user> ULIST { get => uLIST; set => uLIST = value; }

        public controller()
        {
            this.ListPS = new List<Person>();
            ListPS.Add(new Person());
        }

        public void GetAllPersons()
        {
            ListPS = new List<Person>();
            string json = HTTPRequest("API/Person/GetPerson");
            ListPS = (List<Person>)JsonConvert.DeserializeObject(json, typeof(List<Person>));
        }

        public void GetAllUser()
        {
            string json = HTTPRequest("API/Person/GetUser");
            ULIST = (List<user>)JsonConvert.DeserializeObject(json, typeof(List<user>));
        }


        public string HTTPRequest(string URI, string Port = "44328")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:" + Port + "/" + URI);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string retResponse = reader.ReadToEnd();
            return retResponse;
        }

        public void DelPerson(int PID)
        {
            HTTPRequest("api/Person/GetDelUser/" + PID);
            GetAllPersons();
        }

        public void AddPerson(Person neu)
        {
            HTTPRequest("api/Person/GetAddUser/" + neu.Name + "/" + neu.Typ);
            GetAllPersons();
        }
    }
}