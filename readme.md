# Aplicaci�n de Sala de Chat

Este proyecto tiene todo lo necesario para crear una aplicaci�n de chat. Aqu� tienes un resumen de lo que hace cada parte:

## Funcionalidad del Servidor

### Program.cs (BasicServerFunctionality)

Este archivo contiene el c�digo principal para el servidor de la aplicaci�n de chat. B�sicamente, se encarga de escuchar conexiones entrantes de los clientes y mostrar informaci�n cuando un cliente se conecta.

### SignUpAndSignIn.cs (ChatroomWithUserIdentification)

Aqu� se maneja todo lo relacionado con la creaci�n de cuentas y el inicio de sesi�n de usuarios. Guarda la informaci�n de los usuarios en una base de datos MySQL.

## Interfaz del Cliente

### CreateUser.cs (FormSideOfTheChat)

Este formulario permite a los usuarios crear nuevas cuentas introduciendo un nombre de usuario y una contrase�a.

### Form1.cs (FormSideOfTheChat)

Esta es la interfaz principal para que los usuarios inicien sesi�n en la aplicaci�n. Les pide que ingresen sus credenciales y pueden iniciar sesi�n. Si no tienen una cuenta, pueden crear una nueva desde aqu�.

## Dependencias

- System
- System.Collections.Generic
- System.ComponentModel
- System.Data
- System.Drawing
- System.Linq
- System.Text
- System.Threading.Tasks
- System.Windows.Forms
- ChatroomWithUserIdentification
