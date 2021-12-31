$('input[class*="date-picker"]').datepicker({
    format: "dd-mm-yyyy", endDate: '+0d', autoclose: true
});

$('input[class*="date-future"]').datepicker({
    format: "dd-mm-yyyy", autoclose: true
});

$('input[class*="datetime-future"]').datetimepicker({
    weekStart: 1,
    todayBtn: 0,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    maxView: 2,
    minView: 1,
    showMeridian: 0,
    pickerPosition: "bottom-left",
    daysOfWeekDisabled: [0],
    forceParse: 0,
    format: "DD/MM/YYYY HH:mm",
});

$('a').tooltip();
$('[data-toggle="tooltip"]').tooltip();

$('select[class*="select-filter"]').select2();
$('select[class*="multi-tag-select"]').select2({ placeholder: "Click here to select" });

$(document).ready(function () {
    $("div[id*='validationSummary']").each(function () {
        $(this).prepend('<a class="close" onclick="Close();">×</a>')
    });
    $('input[type="submit"] , button[type="submit"]').click(function () {
        $("div[id*='validationSummary']").removeAttr('style');
        if ($('.UnlockEditor').length)
            ValidateEditor();
        if (!$(this).closest('form').valid()) {
            $('html, body').animate({
                scrollTop: $('#page-wrapper').offset().top,
            }, 800);
        }
    });
});

function Close() {
    $("div[id*='validationSummary']").css('display', 'none');
}

function NumberWithDot(e) //Number Only 
{
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 47 && k < 58) || k == 46 || k == 8 || k == 0);
}

function getQueryStringArray() {
    var result = {}, queryString = location.search.substring(1), re = /([^&=]+)=([^&]*)/g, m;
    while (m = re.exec(queryString)) {
        result[decodeURIComponent(m[1].toLocaleLowerCase())] = decodeURIComponent(m[2]);
    }
    return result;
}

function getQueryString(value) {
    if (value != null)
        return getQueryStringArray()[value.toString().toLocaleLowerCase()];
    else
        return '';
}

$(function () {
    $('.datetimepicker').datetimepicker({
        weekStart: 1,
        todayBtn: 0,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        maxView: 2,
        minView: 1,
        showMeridian: 0,
        pickerPosition: "bottom-left",
        daysOfWeekDisabled: [0],
        forceParse: 0
    });
    $('.datetimepicker input').focus(function () {
        $(this).next('.input-group-addon').trigger('click');
    });
});

$("#usersession").on("click", function () {
    $(this).toggleClass("dropdown open");
});

$(function () {
    $('.navbar-right .dropdown').click(function () {
        $(this).toggleClass('dropdown dropdown open');
    });

    if ($('.UnlockEditor').length){
        $('.UnlockEditor').summernote({
            height: 800,
            airMode: false,
            codemirror: { // codemirror options
                theme: 'monokai'
            },
            callbacks: {
                onImageUpload: function (files) {
                    var $editor = $(this);
                    var formData = new FormData();
                    formData.append("file", files[0]);
                    $.ajax({
                        type: 'POST',
                        url: "/UnlockFreshCMS/Handler.ashx?FunctionName=UploadTextEditorImage",
                        data: formData,
                        cache: false,
                        contentType: false,
                        processData: false,
                        success: function (imageUrl) {
                            if (!imageUrl) {
                                return;
                            }
                            var imgNode = document.createElement('img');
                            imgNode.src = imageUrl;
                            $editor.summernote('insertNode', imgNode);
                        },
                        error: function () {
                        }
                    });
                }
            }
        });
    }
    $('#msgDisplay').fadeOut(15000);
});

//jQuery(function ($) {
$('.showSingle').click(function () {
    var itemid = '#div' + $(this).attr('target'); //id of the element to show/hide.
    //Show the element if nothing is shown.
    if ($('.targetDiv.active').length === 0) {
        $(itemid).slideDown();
        $(itemid).addClass('active');
        $('.activated').removeClass('activated');
        $(this).addClass('activated');
        //Hide the element if it is shown.
    } else if (itemid == "#" + $('.active').attr('id')) {
        $('.targetDiv.active').slideUp();
        $(itemid).removeClass('active');
        $('.activated').removeClass('activated');
        //Otherwise, switch out the current element for the next one sequentially.
    } else {
        $(this).removeClass('active');
        $('.targetDiv.active').slideUp(function () {
            if ($(".targetDiv:animated").length === 0) {
                $(itemid).slideDown();
                $(itemid).addClass('active');
            }
        });
        $('.activated').removeClass('activated');
        $(this).addClass('activated');
    }
});

$('td').each(function(){
    if($(this).html() != undefined && $(this).html().trim().toLowerCase() == "active"){
        $(this).addClass('text-success')
    }else if($(this).html() != undefined && $(this).html().trim().toLowerCase() == "in-active"){
        $(this).addClass('text-danger')
    }
});

$('span>a>i.fa-pencil-square-o , span>a>i.fa-trash-o, span>a>i.fa-info-circle').each(function(){
    if($(this).hasClass('fa-pencil-square-o'))
        $(this).addClass('text-success');
    else if($(this).hasClass('fa-trash-o'))
        $(this).addClass('text-danger');
    else if($(this).hasClass('fa-info-circle'))
        $(this).addClass('text-info');
});

function ShowConfirmation(e,val,message,isValidate) {
    e.preventDefault();
    if(isValidate != undefined && isValidate == true ? $('input[type="checkbox"]:checked').length : true){
        var currentElement = val;
        swal({
            title: "Are you sure?",
            text: message,
            icon: "warning",
            buttons: {
                cancel: "No",
                confirm: "Yes"
            },
            dangerMode: true,
        })
    .then((willDelete) => {
        if (willDelete) {
        if(currentElement.type != "submit")
        window.location.href = currentElement.href;
    else
            $('form').submit();
    } else {
        return false;
    }
});
}else
{
    swal({
        title: "Please check ?",
        text: 'atleast one record need to be selected to perform following operation.',
        icon: "warning",
        buttons: {
            cancel: "Ok",
        },
        dangerMode: true,
    })}
}

$('a#selectall').click(function(){
    $('input[type="checkbox"]').each(function(){
        var checkBoxes = $(this);
        checkBoxes.prop("checked", !checkBoxes.prop("checked"));
    });
    $(this).text() != undefined && $(this).text()  == 'Select All' ?  $(this).text('Deselect All') :  $(this).text('Select All') ;
    $(this).attr('data-original-title') != undefined && $(this).attr('data-original-title') == 'Select All' ? $(this).attr('data-original-title','Deselect All') : $(this).attr('data-original-title','Select All');
});

$('table th').click(function(){
    if(this.textContent != undefined && this.textContent != "")
        $('form').submit();
});

$(function () {
    DisableSEO();
})

$('input[name="SEOFlag"]').click(function(){
    DisableSEO();
});

function DisableSEO() {
    $('#SEO').find('input[type="text"],textarea').each(function(){
        if($(this).attr('disabled') != undefined && $(this).attr('disabled') == 'disabled'  && $('input[name="SEOFlag"]:checked').val() != "1")
            $(this).removeAttr('disabled');
        else if($('input[name="SEOFlag"]:checked').val() != "2")
            $(this).attr('disabled','disabled');
    });
}

$(function () {
    ValidateEditor();
})

function ValidateEditor() {
    $('form').each(function () {
        if($('.UnlockEditor').length > 0 ){
            if ($('.note-editable').html() == "<p><br></p>" || $('.note-editable').html() == ""){
                $('.UnlockEditor').val('');
                if ($(this).data('validator'))
                    $(this).data('validator').settings.ignore = ".note-editor *";
            }else{
                $('.UnlockEditor').val($('.note-editable').html());
                $(this).data("validator").settings.ignore = ".data-val-ignore, :hidden, :disabled";
            }
        }
        //$("input[data-val-date]").removeAttr("data-val-date");
        $.validator.addMethod('date',
function (value, element) {
    return true; // since MVC4 data-val-date is put on EVERY vm date property. Default implementation does not allow for multiple cultures...
});
    });
}