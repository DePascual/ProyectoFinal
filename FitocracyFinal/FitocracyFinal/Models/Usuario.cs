using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitocracyFinal.Models
{
    public class Usuario
    {
        private ObjectId _IdUsuario;

        private string _Email;

        private string _Username;

        private string _Password;

        private byte[] _Foto;

        private int _Points;

        private int _Age;

        private string _Description;

        private int _Level;

        private string _WorkOuts;

        private DateTime _Birthday;

        public ObjectId IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Username
        {
            get
            {
                return _Username;
            }

            set
            {
                _Username = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public byte[] Foto
        {
            get
            {
                return _Foto;
            }

            set
            {
                _Foto = value;
            }
        }

        public int Points
        {
            get
            {
                return _Points;
            }

            set
            {
                _Points = value;
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }

            set
            {
                _Age = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        public int Level
        {
            get
            {
                return _Level;
            }

            set
            {
                _Level = value;
            }
        }

        public string WorkOuts
        {
            get
            {
                return _WorkOuts;
            }

            set
            {
                _WorkOuts = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return _Birthday;
            }

            set
            {
                _Birthday = value;
            }
        }
    }
}