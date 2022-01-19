Project Exercise

First step
--------------------------------------------------------------
In order to start, you have to compile/execute the project "Exercise" with visual studio.
Once the project is running you will be able to performe request against the service.
For practical purposes, i'll say that my service is running in port 44305

Proyect description
-----------------------------------------------------------
The actual project provide an endpoint with two services
The first services returns the coordinates of an Argentinian province. The associated verb is GET.
In order to receive a valid answer you must provide a valid province name, otherwise the service will return
the legend "La provincia suministrada es invalida". You can visit the page:
https://www.argentina.gob.ar/pais/provincias , all the provinces are listed there.
An example of request could be:
https://localhost:44305/api/main/chaco, being "chaco" the name of the province whose coordinates we want to 
find out( can be written in uppercase or lowercase)
The response for this request will be in json format:
{
    "latitud": "-26,3864309061226",
    "longitud": "-60,7658307438603"
}
However, if the service that returns the coordinates is unavailable you will receive an error http 500.

The second services take two headers("user" and "password"), and check the files users.csv in order to find
out a coincidence. The associated verb is POST

An example of request could be:
https://localhost:44305/api/main/
If the provided credentials has a match on the file, you will receive a message along with a very usefull 
token, also in json format:
{
    "message": "Login exitoso",
    "token": token_value
}

Otherwise, the response will be:
"El usuario o contraseña provistos son invalidos"

Also, if any of the credentials are blank, the response will be:
"El usuario/contraseña no pueden ser nulo"


--------------------------------------------------------------
Postman documentation available in:
https://documenter.getpostman.com/view/17462417/UVXnHudj
