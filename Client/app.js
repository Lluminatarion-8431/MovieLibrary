






function processForm( e ){
    var data = {
        Title : this["title"].value,
        Director: this["director"].value,
        Genre: this["genre"].value
    };

    if(data.Title == "" || data.Director == ""){
        alert("Please enter a movie and try again");
        processForm();
    }
    else{

        $.ajax({
            url: 'https://localhost:44325/api/movie',
            dataType: 'text',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
                
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        
        }).then(function(){
            createTable();
        });

        document.getElementById('my-form').reset();
        e.preventDefault();
    }
}

$('#my-form').submit( processForm );


function getMovieById(){
    var id = $('#movieId').val();
    var movie;
    $.ajax({
        url: 'https://localhost:44325/api/movie/' + id,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function( data, textStatus, jQxhr ){
            movie = data;
            console.log(movie);
            changeInput(movie);           
        },
        error: function( jqXhr, textStatus, errorThrown ){
            console.log( errorThrown );
        }
    });
}