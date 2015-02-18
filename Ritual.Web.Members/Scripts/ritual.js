$(document).ready(function () {

    $('.jqueryui-datepicker').datepicker();

    $('.jqueryui-datetimepicker').datetimepicker();
    $('.jqueryui-timepicker').timepicker();
    $(".rep").each(function () {
        $(this).keyup(function () {
            calculateSum();
        });
    });
});

function calculateSum() {
    var sum = 0;
    $(".rep").each(function () {
        if (!isNaN(this.value) && this.value.length != 0) {
            sum += parseFloat(this.value);
        }
    });
    $(".reptotal").val(sum.toFixed(0));
}/*!
 * Author: Abdullah A Almsaeed
 * Date: 4 Jan 2014
 * Description:
 *      This file should be included in all pages
 !**/

/*
 * Global variables. If you change any of these vars, don't forget 
 * to change the values in the less files!
 */
var left_side_width = 220; //Sidebar width in pixels

$(function () {
    "use strict";

    //Enable sidebar toggle
    $("[data-toggle='offcanvas']").click(function (e) {
        e.preventDefault();

        //If window is small enough, enable sidebar push menu
        if ($(window).width() <= 992) {
            $('.row-offcanvas').toggleClass('active');
            $('.left-side').removeClass("collapse-left");
            $(".right-side").removeClass("strech");
            $('.row-offcanvas').toggleClass("relative");
        } else {
            //Else, enable content streching
            $('.left-side').toggleClass("collapse-left");
            $(".right-side").toggleClass("strech");
        }
    });

    //Add hover support for touch devices
    $('.btn').bind('touchstart', function () {
        $(this).addClass('hover');
    }).bind('touchend', function () {
        $(this).removeClass('hover');
    });



    /*
     * INITIALIZE BUTTON TOGGLE
     * ------------------------
     */
    $('.btn-group[data-toggle="btn-toggle"]').each(function () {
        var group = $(this);
        $(this).find(".btn").click(function (e) {
            group.find(".btn.active").removeClass("active");
            $(this).addClass("active");
            e.preventDefault();
        });

    });

    /* Sidebar tree view */
    $(".sidebar .treeview").tree();

    /* 
     * Make sure that the sidebar is streched full height
     * ---------------------------------------------
     * We are gonna assign a min-height value every time the
     * wrapper gets resized and upon page load. We will use
     * Ben Alman's method for detecting the resize event.
     * 
     **/
    function _fix() {
        //Get window height and the wrapper height
        var height = $(window).height() - $("body > .header").height() - ($("body > .footer").outerHeight() || 0);
        $(".wrapper").css("min-height", height + "px");
        var content = $(".wrapper").height();
        //If the wrapper height is greater than the window
        if (content > height)
            //then set sidebar height to the wrapper
            $(".left-side, html, body").css("min-height", content + "px");
        else {
            //Otherwise, set the sidebar to the height of the window
            $(".left-side, html, body").css("min-height", height + "px");
        }
    }
    //Fire upon load
    _fix();
    //Fire when wrapper is resized
    $(".wrapper").resize(function () {
        _fix();
        fix_sidebar();
    });

    //Fix the fixed layout sidebar scroll bug
    fix_sidebar();


});
function fix_sidebar() {
    //Make sure the body tag has the .fixed class
    if (!$("body").hasClass("fixed")) {
        return;
    }

    //Add slimscroll
    $(".sidebar").slimscroll({
        height: ($(window).height() - $(".header").height()) + "px",
        color: "rgba(0,0,0,0.2)"
    });
}

/*END DEMO*/

/*
 * SIDEBAR MENU
 * ------------
 * This is a custom plugin for the sidebar menu. It provides a tree view.
 * 
 * Usage:
 * $(".sidebar).tree();
 * 
 * Note: This plugin does not accept any options. Instead, it only requires a class
 *       added to the element that contains a sub-menu.
 *       
 * When used with the sidebar, for example, it would look something like this:
 * <ul class='sidebar-menu'>
 *      <li class="treeview active">
 *          <a href="#>Menu</a>
 *          <ul class='treeview-menu'>
 *              <li class='active'><a href=#>Level 1</a></li>
 *          </ul>
 *      </li>
 * </ul>
 * 
 * Add .active class to <li> elements if you want the menu to be open automatically
 * on page load. See above for an example.
 */
(function ($) {
    "use strict";

    $.fn.tree = function () {

        return this.each(function () {
            var btn = $(this).children("a").first();
            var menu = $(this).children(".treeview-menu").first();
            var isActive = $(this).hasClass('active');

            //initialize already active menus
            if (isActive) {
                menu.show();
                btn.children(".fa-angle-left").first().removeClass("fa-angle-left").addClass("fa-angle-down");
            }
            //Slide open or close the menu on link click
            btn.click(function (e) {
                e.preventDefault();
                if (isActive) {
                    //Slide up to close menu
                    menu.slideUp();
                    isActive = false;
                    btn.children(".fa-angle-down").first().removeClass("fa-angle-down").addClass("fa-angle-left");
                    btn.parent("li").removeClass("active");
                } else {
                    //Slide down to open menu
                    menu.slideDown();
                    isActive = true;
                    btn.children(".fa-angle-left").first().removeClass("fa-angle-left").addClass("fa-angle-down");
                    btn.parent("li").addClass("active");
                }
            });

            /* Add margins to submenu elements to give it a tree look */
            menu.find("li > a").each(function () {
                var pad = parseInt($(this).css("margin-left")) + 10;

                $(this).css({ "margin-left": pad + "px" });
            });

        });

    };


}(jQuery));





var RITUAL = RITUAL || {};
RITUAL.Core = RITUAL.Core || {};
RITUAL.Core.Locations = RITUAL.Core.Locations || {};

RITUAL.Core = {
    Init: function () {

    }
}

RITUAL.Core.Locations = {
    Listing: function () {
        RITUAL.Core.Locations.MapListing();
    },
    Edit: function () {

    },
    Add: function () {

    },
    Charts: function () {

        var locationId = $('#locationId').val();
        var options = {
            animation: true,
            tooltipTemplate: "<%if (label){%><%=label%>: <%}%><%= value %>%",
            //String - A legend template
            legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"></span><%if(segments[i].label){%><%=segments[i].label%><%}%></li><%}%></ul>"
        };

        this.CurrentMembersChart(locationId, options, '#locationCurrentMembers', '#locationCurrentMembersCanvas');
        this.CurrentMembersTerm(locationId, options, '#locationMembersTerm', '#locationMembersTermCanvas');
        this.CurrentMembersType(locationId, options, '#locationMembersType', '#locationMembersTypeCanvas');
        this.CurrentMembersPayment(locationId, options, '#locationMembersPayment', '#locationMembersPaymentCanvas');
    },
    CurrentMembersChart: function (locationId, options, canvasdiv, legenddiv) {
        
        

        var data = [{
            value: 30,
            color: "#F7464A",
            label: "Red"
        }, {
            value: 50,
            color: "#E2EAE9",
            label: "Orange"
        }
        ]

        var currentMembers = $(canvasdiv);
        var currentMembersCt = currentMembers.get(0).getContext('2d');
        currentMembersChart = new Chart(currentMembersCt).Doughnut(data, options);
        var legend = currentMembersChart.generateLegend();
        $(legenddiv).append(legend);
    },
    CurrentMembersTerm: function (locationId, options, canvasdiv, legenddiv) {

        var data = [{
            value: 30,
            color: "#F7464A",
            label: "Red"
        }, {
            value: 50,
            color: "#E2EAE9",
            label: "Orange"
        }
        ]

        var currentMembers = $(canvasdiv);
        var currentMembersCt = currentMembers.get(0).getContext('2d');
        currentMembersChart = new Chart(currentMembersCt).Doughnut(data, options);
        var legend = currentMembersChart.generateLegend();
        $(legenddiv).append(legend);
    },
    CurrentMembersType: function (locationId, options, canvasdiv, legenddiv) {

        var data = [{
            value: 30,
            color: "#F7464A",
            label: "Red"
        }, {
            value: 50,
            color: "#E2EAE9",
            label: "Orange"
        }
        ]

        var currentMembers = $(canvasdiv);
        var currentMembersCt = currentMembers.get(0).getContext('2d');
        currentMembersChart = new Chart(currentMembersCt).Doughnut(data, options);
        var legend = currentMembersChart.generateLegend();
        $(legenddiv).append(legend);
    },
    CurrentMembersPayment: function (locationId, options, canvasdiv, legenddiv) {
        $.ajax({
            type: "GET",
            url: '/Locations/GetLocationPaymentMethodChart',
            data: { "locationId": locationId },
            success: function (data) {

                var currentMembers = $(canvasdiv);
                var currentMembersCt = currentMembers.get(0).getContext('2d');
                currentMembersChart = new Chart(currentMembersCt).Doughnut(data, options);
                var legend = currentMembersChart.generateLegend();
                $(legenddiv).append(legend);
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    MapListing: function () {
        $.ajax({
            type: "GET",
            url: '/Locations/GetMapDataJson',
            success: function (locations) {
                var map;
                var bounds = new google.maps.LatLngBounds();
                var mapOptions = {
                    mapTypeId: 'roadmap'
                };

                // Display a map on the page
                map = new google.maps.Map(document.getElementById("ritualMap"), mapOptions);
                map.setTilt(45);
                
                // Display multiple markers on a map
                var infoWindow = new google.maps.InfoWindow(), marker, i;

                // Loop through our array of markers & place each one on the map  
                for (i = 0; i < locations.length; i++) {
                    var position = new google.maps.LatLng(locations[i].latitude, locations[i].longitude);
                    bounds.extend(position);
                    marker = new google.maps.Marker({
                        position: position,
                        map: map,
                        title: locations[i].name,
                        icon: '/Content/images/ritual_pushpin.png'
                    });
                    
                    // Automatically center the map fitting all markers on the screen
                    map.fitBounds(bounds);
                }

                // Override our map zoom level once our fitBounds function runs (Make sure it only runs once)
                var boundsListener = google.maps.event.addListener((map), 'bounds_changed', function (event) {
                    this.setZoom(1);
                    google.maps.event.removeListener(boundsListener);
                });

                $('.center-ritual-map').on('click', function () {
                    var lat = $(this).data('lat');
                    var long = $(this).data('long');
                    map.setZoom(17);      // This will trigger a zoom_changed on the map
                    map.setCenter(new google.maps.LatLng(lat, long));
                });

            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    }
}