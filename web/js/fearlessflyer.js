// Display modal dialog
$(document).ready(function(){
    $('li img').on('click',function(){
    
        // set per-image values
        var img = '<img src="' + getFullImgPath($(this).attr('src')) + '" class="img-responsive"/>';
        var desc = $(this).attr('title');

        //start of new code new code
        var index = $(this).parent('li').index();

        var html = '';
        html += '<a class="controls next" href="'+ (index+2) + '">Next &raquo;</a>';
        html += '<a class="controls previous" href="' + (index) + '">&laquo; Prev</a>';
        html += img;
        html += '<div style="clear:both;display:block;">';
        html += '<span id="image_description">' + desc + '</span>';
        html += '</div>';

        $('#myModal').modal();
        $('#myModal').on('shown.bs.modal', function(){
            $('#myModal .modal-body').html(html);
            //new code
            $('a.controls').trigger('click');
        })
        $('#myModal').on('hidden.bs.modal', function(){
            $('#myModal .modal-body').html('');
        });

   });

})


// Clicking a thumbnail
$(document).on('click', 'a.controls', function(){
    var index = $(this).attr('href');
    var src = $('ul.row li:nth-child('+ index +') img').attr('src');
    var desc = $('ul.row li:nth-child(' + index +') img').attr('title');
    
    src = getFullImgPath(src);

    $('.modal-body img').attr('src', src);
    $('#image_description').html(desc);

    var newPrevIndex = parseInt(index) - 1;
    var newNextIndex = parseInt(newPrevIndex) + 2;

    if($(this).hasClass('previous')){
        $(this).attr('href', newPrevIndex);
        $('a.next').attr('href', newNextIndex);
    }else{
        $(this).attr('href', newNextIndex);
        $('a.previous').attr('href', newPrevIndex);
    }

    var total = $('ul.row li').length + 1;
    //hide next button
    if(total === newNextIndex){
        $('a.next').hide();
    }else{
        $('a.next').show()
    }
    //hide previous button
    if(newPrevIndex === 0){
        $('a.previous').hide();
    }else{
        $('a.previous').show()
    }


    return false;
});


// Arrow keys
$('#myModal').keydown(function(e)
{
  if (e.keyCode == 37) {
    if ($('a.previous').is(":visible")) {
      $('a.previous')[0].click();
    }
    return false;
  }
  
  if (e.keyCode == 39) {
    if ($('a.next').is(":visible")) {
      $('a.next')[0].click();
    }
    return false;
  }
});


// Helper to convert file.png to file.full.png
function getFullImgPath(src) {
    var split = src.split('.png');
    src = split[0] + '.full.png';
    return src;
}
