$(document).ready(function () {

    $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        var $subMenu = $(this).next(".dropdown-menu");
        $subMenu.toggleClass('show');


        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });


        return false;
    });

    $('.register').click(function () {
        $('#register').addClass('show d-block');
        $('#register').removeClass('d-none');
        $('#login').addClass('d-none');
        $('#login').removeClass('show');
    });
    $('.account-form .close').click(function () {
        $('#register, #login, .modal-backdrop').addClass('d-none');
        $('#register, #login, .modal-backdrop').removeClass('show d-block');
    });
    $('.account-login').click(function () {
        $('#login').addClass('show');
        $('#login').removeClass('d-none');
    });

    //$(".datepicker").datepicker({
    //    format: 'dd/mm/yyyy',
    //    todayHighlight: false,
    //    autoclose: true,
    //    startDate: new Date(),
    //});

    var date = new Date();
    date.setDate(date.getDate() + 1);
    $(".datepicker").datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: false,
        autoclose: true,
        startDate: date
    });

    $("#msgDisplay").fadeOut(3000);
});
