

//Clase controladora de la vista Users.cshtml

//Definimos una clase JS usando prototype
function UserViewController() {

    this.ViewName = "Users";
    //Nombre del controlador que consumo en el API del backend
    this.API_ControllerName = "User";

    //metodo "constructor"
    this.InitView = function () {
        this.LoadTable();
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

     }
}

//Instancia y render del controlador
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
})