const API_PERSONAS_URL2 = 'https://localhost:7217/api/cargos/obtenerCargos'
function cargarCargos(){



    fetch(API_PERSONAS_URL2)
    .then((respuesta) => respuesta.json())
    .then((respuesta) => {
        if(!respuesta.ok){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error no especificado',
                
              })
        }

        const cuerpoTabla = document.getElementById("inputCargo")
        
        respuesta.cargos.forEach((per) => {
            
            const fila = document.createElement('option')
            
           fila.value = per.id;
           fila.textContent = per.name;
            
            cuerpoTabla.appendChild(fila)
        });
    }).catch((err) => {
        alert("Algo salio mal!!")
    })

}