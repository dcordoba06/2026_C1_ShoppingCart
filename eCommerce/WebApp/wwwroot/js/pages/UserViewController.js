

//Clase controladora de la vista Users.cshtml

//Definimos una clase JS usando prototype
function UserViewController() {

    this.ViewName = "Users";
    //Nombre del controlador que consumo en el API del backend
    this.API_ControllerName = "User";

    //metodo "constructor"
    this.InitView = function () {
        this.LoadTable();
        //Asociar el evento de crear al boton
        $('#btnCreate').click(function () {
            var vc = new UserViewController();
            vc.Create();
        })


        //Asociar evento de update
        $('#btnUpdate').click(function () {
            var vc = new UserViewController();
            vc.Update();
        })

        //Asociar evento de update
        $('#btnDelete').click(function () {
            var vc = new UserViewController();
            vc.Delete();
        })
    }

    //Metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        var columns = [];
        columns[0] = { 'data': 'id', 'title' :'Id' };
        columns[1] = { 'data': 'name', 'title': 'Nombre' };
        columns[2] = { 'data': 'lastName', 'title': 'Apellidos' };
        columns[3] = { 'data': 'birthDate', 'title': 'Fecha Nacimiento' };
        columns[4] = { 'data': 'status', 'title': 'Estado' };
        columns[5] = { 'data': 'created', 'title': 'Registro' };

        //convertir la tabla plana y fea en una tabla mas bonita y robusta
        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        //asignar evento de mapeo del dto seleccionado con el form
        $('#tblUsers tbody').on('click', 'tr', function () {

            var row = $(this).closest('tr');

            //extraer el DTO al que se le dio click
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            //cargar el DTO en el form
            $('#txtId').val(userDTO.id);
            $('#txtName').val(userDTO.name);
            $('#txtLastName').val(userDTO.lastName);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);

            //formato de la fechga
            var onlyDate = userDTO.birthDate.split('T');
            $('#txtBirthDate').val(onlyDate[0]);

        })

     }

    //Metodo para la creacion de un usuario

    this.Create = function () {

        var userDTO = {};
        //Set con valores default
        userDTO.id = 0;
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.name = $('#txtName').val();
        userDTO.lastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPwd').val();

        //Enviar al API
        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Create";

        ca.PostToAPI(urlEndPoint, userDTO, function () {
            //recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })

    }

    //Metodo para la actualizacion del usuario
    this.Update = function () {

        var userDTO = {};
        //Set con valores default
       
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.id = $('#txtId').val();
        userDTO.name = $('#txtName').val();
        userDTO.lastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPwd').val();

        //enviar al API
        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Update";

        ca.PutToAPI(urlEndPoint, userDTO, function () {
            //recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    //metodo de delete
    this.Delete = function () {

        var userDTO = {};
        //Set con valores default

        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.id = $('#txtId').val();
        userDTO.name = $('#txtName').val();
        userDTO.lastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPwd').val();

        //enviar al API
        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Delete";

        ca.DeleteToAPI(urlEndPoint, userDTO, function () {
            //recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

}

//Instancia y render del controlador
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
})