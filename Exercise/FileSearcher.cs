using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise
{
    public class FileSearcher : ISearcher
    {
        private string _user;
        private string _password;

        public FileSearcher(string _user, string _password)
        {
            this._user = _user;
            this._password = _password;
        }

        public IActionResult Search()
        {
            ControllerBase _controller = new ConcretController();

            // Check if user and passwords are empty or null
            if (string.IsNullOrEmpty(this._user) || string.IsNullOrEmpty(this._password))
                return _controller.BadRequest("El usuario/contraseña no puede ser nulo");

            string[] _lines = System.IO.File.ReadAllLines("users.csv");
            bool _continue = false;
            foreach (string _line in _lines)
            {
                // Skip the headers
                if (_continue)
                {
                    string[] _content = _line.Split(',');
                    if (string.Equals(this._user, _content[1]) && string.Equals(this._password, _content[2]))
                    {
                        return _controller.Ok(new { Message = "Login exitoso", Token = _content[3] });
                    }

                }
                else
                    _continue = true;
            }
            return _controller.BadRequest("El usuario o contraseña provistos son invalidos");
            /*
            return _controller.Problem(
                detail: "El usuario o contraseña provistos son invalidos",
                statusCode: StatusCodes.Status403Forbidden
            );*/
        }

    }

}
