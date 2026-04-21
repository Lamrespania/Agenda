### Variables de entorno de la solución
</br>

Proyecto __User__ - Agenda.User.Grpc

```
* USER_DB  
  Cadena de conexión para la base de datos de usuarios User.db
```
</br>

Proyecto __Login__ - Agenda.Login.Grpc

```
* USER_DB  
  Cadena de conexión para la base de datos de usuarios User.db  

* USER_TOKEN_LIFETIME_MIN  
  Tiempo de vida en minutos del token generado  

* USER_TOKEN_REFRESH_LIFETIME_HOUR  
  Tiempo de vida en horas del token de refresco generado
```
</br>

Proyecto __WebApi__ - AgendaWebApi

```
* AGENDA_DB  
  Cadena de conexión para la base de datos principal Agenda.db  

* USER_SERVICE_URL
  Dirección http para consumir el servicio Grpc de User

* LOGIN_SERVICE_URL  
  Dirección http para consumir el servicio Grpc de Login
```
</br>

Proyecto __UI__ - Agenda.WinForms

```
* API_URL  
  Dirección http para consumir la Api  

* API_TIMEOUT_SEC  
  Timeout en segundos de las peticiones a la Api
```
</br>

Proyecto __UI__ - Agenda.WPF

```
* API_URL  
  Dirección http para consumir la Api  

* API_TIMEOUT_SEC  
  Timeout en segundos de las peticiones a la Api
```
</br>

Proyecto __UI__ - Agenda.Blazor

```
* API_URL  
  Dirección http para consumir la Api  

* API_TIMEOUT_SEC  
  Timeout en segundos de las peticiones a la Api

* COOKIE_EXPIRE_HOUR
  Expiración de la cookie en horas
```
