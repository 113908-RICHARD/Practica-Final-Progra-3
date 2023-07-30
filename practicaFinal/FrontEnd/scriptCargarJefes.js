const API_PERSONAS_URL3 = 'https://localhost:7217/api/Empleados/obtenerJefes'
function cargarJefes(){



    fetch(API_PERSONAS_URL3)
    .then((respuesta) => respuesta.json())
    .then((respuesta) => {
        if(!respuesta.ok){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error no especificado',
                
              })
        }

        const cuerpoTabla = document.getElementById("inputJefe")
        
        respuesta.listEmpleados.forEach((per) => {
            
            const fila = document.createElement('option')
            
           fila.value = per.id;
           fila.textContent = per.nombre;
            
            cuerpoTabla.appendChild(fila)
        });
    }).catch((err) => {
        alert("Algo salio mal!!")
    })

}