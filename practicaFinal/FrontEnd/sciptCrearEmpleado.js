
function cargarNuevoEmpleado(){

    let txtNombre = document.getElementById('nombre')
    let txtApellido = document.getElementById('apellido')
    let txtDni = document.getElementById('dni')
    let inputCargoText = document.getElementById('inputCargo')
    var inputCargo= inputCargoText.options[inputCargoText.selectedIndex].value
    
    let inputSucursalText = document.getElementById('inputSucursal')
    var inputSucursal= inputSucursalText.options[inputSucursalText.selectedIndex].value
    
    let inputJefeText = document.getElementById('inputJefe')
    var inputJefe= inputJefeText.options[inputJefeText.selectedIndex].value
    
    

  

    const url = 'https://localhost:7217/api/empleados/PostNuevoEmpleado'

    const request = {
        "name": txtNombre.value,
        "apellido": txtApellido.value,
        "idCargo": inputCargo,
        "idSucursal": inputSucursal,
        "dni": txtDni.value,
        "idJefe": inputJefe
    }

    fetch(url,{
        body: JSON.stringify(request),
        method: 'post',
        headers: {
            'Content-Type':'application/json'
        }
    })
    .then(respuesta => respuesta.json())
    .then(respuesta => {
        if(respuesta.ok){
            Swal.fire(
                'Exito',
                'empleado creado',
                'success'
              )
              cargarJefes();
              cargarSucursales();
              cargarCargos();
              
            
        }
        else{
            alert("error al crear el empleado")
        }
    })
    .catch(err => alert("ERROR: " + err))
}