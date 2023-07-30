const API_PERSONAS_URL = 'https://localhost:7217/api/Sucursales/obtenerSucursales'
function cargarSucursales(){



    fetch(API_PERSONAS_URL)
    .then((respuesta) => respuesta.json())
    .then((respuesta) => {
        if(!respuesta.ok){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error no especificado',
                
              })
        }

        const cuerpoTabla = document.getElementById("inputSucursal")
        
        respuesta.sucursales.forEach((per) => {
            
            const fila = document.createElement('option')
            
           fila.value = per.id;
           fila.textContent = per.name;
            
            cuerpoTabla.appendChild(fila)
        });
    }).catch((err) => {
        alert("Algo salio mal!!")
    })

}