var destinationBox;
var fromBox;
var destinationList;
var fromList;

var fromMenuItem;
var destMenuItem;
var switchDestBtn;

$(document).ready(function () {
    destinationBox = $('.destination-dropdown');
    fromBox = $('.from-dropdown');
    destinationList = $('.destination-menu');
    fromList = $('.from-menu');
    switchDestBtn = $('#switchDestionations');
    destMenuItem = $('.destination-menu-item');

    fromBox.on(
        'paste blur focus', function (e) {
            if (e.type == 'blur') {
                fromList.hide();
            }
            if (e.type != 'blur') {
                getAutoComplete(fromBox.val(), fromList)
                fromList.show();
                destinationList.hide()
            }
            
    });

    destinationBox.on(
        'blur paste focus', function (e) {
            if (e.type == 'blur') {
                destinationList.hide();
            }
            if (e.type != 'blur') {
                getAutoComplete(destinationBox.val(), destinationList);
                destinationList.show();
                fromList.hide()
            }                
           });

    switchDestBtn.on('click', function () {
        var destVal = destinationBox.val();
        var fromVal = fromBox.val();
        fromBox.val(destVal);
        destinationBox.val(fromVal);
    });


    function getAutoComplete(location, list) {
        var uri = "/Home/GetLocation";
        $.getJSON(uri, { searchInput: location })
            .done(function (data) {
                list.html("");
                $.each(data, function (key, item) {
                    $('<li/>').addClass(['dropdown-item', list.attr("id")+'-item']).attr('role', 'menuitem').html(item.location)
                      .appendTo(list);

                });
            });
    }
    fromMenuItem = $('.from-menu-item');
    fromMenuItem.on('click', function () {
        console.log("Hello");
        var val = $('.from-menu-item').val();
        console.log(val);
    });

    function setText(text) {
        destinationBox.val(text);
        getAutoComplete(text);
    }

    $('.from-dropdown').focusout(function () {
        $('.from-menu').hide();
    });
    $('.destination-dropdown').focusout(function () {
        $('.destination-menu').hide();
    });
 

    $("#showTimeTable").click(function (e) {
        //Serialize the form datas.   
        var valdata = $("#purchaseTicketForm").serialize();
        var timetable = $("#selectRouteForm");

        $.ajax({
            url: "/Home/Timetable",
            type: "GET",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: valdata,
            success: function (data) {
                timetable.load("/Home/Timetable");
            }
        });

    });   


});