using Exercise.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void Get_LatLong()
        {
            // Arrange
            string _province = "Formosa";

            ILogger<MainController> _logger = null;
            var _controller = new MainController(_logger);

            // Act
            ActionResult _response = (ActionResult)_controller.Get(_province);
            ObjectResult _actual = (ObjectResult)_response;

            // Assert
            Assert.AreEqual("{ Latitud = -24,894972594871, Longitud = -59,9324405800872 }", _actual.Value.ToString());
        }
        
        [TestMethod]
        public void Get_BadRequest()
        {
            // Arrange
            string _province = "Tomate";
            ILogger<MainController> _logger = null;
            var _controller = new MainController(_logger);

            // Act
            ActionResult _response = (ActionResult)_controller.Get(_province);
            ObjectResult _actual = (ObjectResult)_response;

            // Assert
            Assert.AreEqual(400, _actual.StatusCode);
        }

        [TestMethod]
        public void Post_GetOk()
        {
            //Arrange
            ILogger<MainController> _logger = null;
            var _controller = new MainController(_logger);
            string _user = "juan";
            string _password = "nauj";

            // Act
            ActionResult _response = (ActionResult)_controller.Post(_user,_password);
            ObjectResult _actual = (ObjectResult)_response;

            // Assert
            Assert.AreEqual(200 ,_actual.StatusCode);
        }

        [TestMethod]
        public void Post_GetBadRequest()
        {
            // Arrange
            ILogger<MainController> _logger = null;
            var _controller = new MainController(_logger);
            string _user = "juan";
            string _password = "juan";

            // Act
            ActionResult _response = (ActionResult)_controller.Post(_user, _password);
            ObjectResult _actual = (ObjectResult)_response;

            // Assert
            Assert.AreEqual(400, _actual.StatusCode);
        }
    }

}
