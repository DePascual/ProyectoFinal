using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FITOCRACY.Models
{
    public class usuario
    {
        private int _id;
        private string _email;
        private string _username;
        private string _password;
        private byte[] _foto;
        private int _points;
        private string _descripcion;
        private int _level;
        private string _workouts;
        private DateTime _birthday;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }


        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public byte[] Foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }

        public int Points
        {
            get
            {
                return _points;
            }

            set
            {
                _points = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }

        public string Workouts
        {
            get
            {
                return _workouts;
            }

            set
            {
                _workouts = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }

            set
            {
                _birthday = value;
            }
        }
    }
}