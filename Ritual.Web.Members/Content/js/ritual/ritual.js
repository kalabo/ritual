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


/*-----------------------------------------------------------------------------------
	Filename: ritual.js
	Owner: Ritual Gym - CheatDay PTE Ltd
	Description: Ritual Template Utilties
	Author: Chris Pettigrew
	Version: 1.1.1
	Copyright (c) 2015, All Rights Reserved, http://www.ritualgym.com
/*-----------------------------------------------------------------------------------*/

var RITUAL = RITUAL || {};
RITUAL.Core = RITUAL.Core || {};
RITUAL.Core.Utilties = RITUAL.Core.Utilties || {};
RITUAL.Core.TrainingZone = RITUAL.Core.TrainingZone || {};
RITUAL.Core.Locations = RITUAL.Core.Locations || {};

RITUAL.Core = {
    Init: function () {

    }
}
RITUAL.Core.Utilties = {
    TicksToDateTime: function (date, ticks) {

        var sec_num = parseInt(ticks, 10); // don't forget the second param
        var hours = Math.floor(sec_num / 3600);
        var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
        var seconds = sec_num - (hours * 3600) - (minutes * 60);

        if (hours < 10) { hours = "0" + hours; }
        if (minutes < 10) { minutes = "0" + minutes; }
        if (seconds < 10) { seconds = "0" + seconds; }

        date.setMinutes(minutes);
        date.setHours(hours);
        date.setSeconds(seconds);
        return date;
    }
}

RITUAL.Core.Registration = {
    Locations: function (divName) {
        RITUAL.Core.Registration.RegisterHandlers();
        $.ajax({
            type: "GET",
            url: '/Account/GetLocations',
            success: function (data) {
                if (data.length > 0) {
                    for (i = 0; i < data.length; i++) {
                        $(divName).append($('<option>', { value: data[i].id }).text(data[i].name));
                    }
                    var val = $(divName).find(":selected").val();
                    RITUAL.Core.Registration.TrialDates("#TrialDate", val, 10);
                }
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    RegisterHandlers: function () {
        $('#TrialDate').on("change", function () {
            var date = $(this).val();
            var locationId = $(this).find(":selected").data('location');
            RITUAL.Core.Registration.TrialTimes("#TrialTimes", locationId, date);
        });

        $('#LocationId').on("change", function () {
            RITUAL.Core.Registration.TrialDates("#TrialDate", $(this).val(), 10);
        });
    },
    TrialDates: function (divName, locationId, numDays) {
        $.ajax({
            type: "GET",
            url: '/Account/GetNextOpenDays',
            data: { "numberofdays": numDays, "locationId": locationId },
            success: function (data) {
                if (data.length > 0) {
                    $(divName).find('option').remove().end();
                    for (i = 0; i < data.length; i++) {
                        var date = new Date(parseInt(data[i].substring(6)));
                        var friendlyDate = moment(date).format("ddd, MMMM Do YYYY");
                        var sqlDate = moment(date).format("MM/DD/YYYY");
                        $(divName).append($('<option value="' + sqlDate + '" data-location="' + locationId + '">').text(friendlyDate));
                    }

                    var startDate = moment(new Date(parseInt(data[1].substring(6)))).format("MM/DD/YYYY");
                    RITUAL.Core.Registration.TrialTimes("#TrialTimes", locationId, startDate);
                }
            }
        });
    },
    TrialTimes: function (divName, locationId, date) {
        $.ajax({
            type: "GET",
            url: '/Account/GetTrialSlotsByDate',
            data: { "date": date, "locationId": locationId },
            success: function (data) {
                $(divName).find('option').remove().end();
                if (data.length > 0) {
                    for (i = 0; i < data.length; i++) {
                        var time = moment().startOf('day').seconds(data[i].StartTime.TotalSeconds).format('H:mm A');
                        $(divName).append($('<option>', { value: data[i].TimeSlotId }).text(time));
                    }
                } else {
                    $(divName).append($('<option>', { value: "" }).text("No Available Slots for this date and location"));
                }
            }
        });
    }
}
RITUAL.Core.TrainingZone = {
    Init: function () {

    },
    UpcomingBookings: function (divName) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetUpcomingBookings',
            data: { "rowcount": 5 },
            success: function (data) {
                var bookings = [];
                var html = "";
                if (data.length > 0) {
                    for (i = 0; i < data.length; i++) {
                        var date = new Date(parseInt(data[i].Date.substring(6)));
                        bookings.push({
                            Title: data[i].Title,
                            StartTime: moment().startOf('day').seconds(data[i].StartTime.TotalSeconds).format('H:mm A'),
                            Date: moment(date).format("MM/DD/YYYY"),
                            DateFriendly: moment(date).format("dddd Do MMM"),
                            Location: data[i].Location,
                            BookingState: data[i].BookingState
                        });
                    }
                    var template = "";
                    template = Handlebars.compile(Templates.bookingrollup);
                    html += template(JSON.parse("{\"Bookings\":" + JSON.stringify(bookings) + "}"));
                }
                else {
                    var template = "";
                    template = Handlebars.compile(Templates.bookingrollupNoItems);
                    html += template();
                }
                $(divName).html(html);
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    PastBookings: function (divName) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetPastBookings',
            data: { "rowcount": 5 },
            success: function (data) {
                var bookings = [];
                var html = "";
                if (data.length > 0) {
                    for (i = 0; i < data.length; i++) {
                        var date = new Date(parseInt(data[i].Date.substring(6)));
                        bookings.push({
                            Title: data[i].Title,
                            StartTime: moment().startOf('day').seconds(data[i].StartTime.TotalSeconds).format('H:mm A'),
                            Date: moment(date).format("MM/DD/YYYY"),
                            DateFriendly: moment(date).format("dddd Do MMM"),
                            Location: data[i].Location,
                            BookingState: data[i].BookingState
                        });
                    }
                    var template = "";
                    template = Handlebars.compile(Templates.bookingrollup);
                    html += template(JSON.parse("{\"Bookings\":" + JSON.stringify(bookings) + "}"));
                }
                else {
                    var template = "";
                    template = Handlebars.compile(Templates.bookingrollupNoItems);
                    html += template();
                }
                $(divName).html(html);
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    News: function (divName, rowlimit) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetHomeLocationNews',
            data: { "rowcount": rowlimit },
            success: function (data) {
                var news = [];
                var html = "";
                for (i = 0; i < data.length; i++) {
                    news.push({
                        Title: data[i].Title,
                        Body: data[i].Body
                    });
                }
                var template = "";
                template = Handlebars.compile(Templates.announcements);
                html += template(JSON.parse("{\"News\":" + JSON.stringify(news) + "}"));
                $(divName).html(html);
                var nt_example1 = $(divName).newsTicker({
                    row_height: 80,
                    max_rows: 1,
                    duration: 10000,
                    prevButton: $('#nt-example1-prev'),
                    nextButton: $('#nt-example1-next')
                });
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    BookingListingHandlers: function () {
        $('#booking-slot-dates').on('change', function () {
            var value = $(this).val();
            RITUAL.Core.TrainingZone.BookingsListing("#ritual-bookings", value);
        });

        $('#booking-slot-locations').on('change', function () {
            var value = $(this).val();
            RITUAL.Core.TrainingZone.BookingDates("#ritual-dates", value);
        });

        

        $('.cancel-booking').on('click', function () {

            var timeslotid = $(this).data('timeslot');
            var locationid = $(this).data('locationid');
            var bookingdate = moment(new Date($(this).data('bookingdate'))).format("MM/DD/YYYY");

            var r = confirm("Are you sure you would like to cancel this booking?");
            if (r == true) {
                $.ajax({
                    type: "GET",
                    url: '/TrainingZone/CancelBookingJSON',
                    data: { "timeslotId": timeslotid, "locationId": locationid, "date": bookingdate },
                    success: function (data) {
                        alert("Delete Booking Successful");
                        var value = $('#booking-slot-dates').val();
                        RITUAL.Core.TrainingZone.BookingsListing("#ritual-bookings", value);
                    },
                    error: function (xhr) {
                        //debugger;  
                        console.log(xhr.responseText);
                        alert("Error has occurred..");
                    }
                });
            }
        });
    },
    Bookings: function (divName) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetMemberAvailableLocations',
            success: function (data) {
                var locations = [];
                var html = "";
                for (i = 0; i < data.length; i++) {
                    locations.push({
                        Id: data[i].id,
                        Name: data[i].name,
                        LocalTime: data[i].localtime
                    });
                }
                var template = "";
                template = Handlebars.compile(Templates.bookinglocationsdropdown);
                html += template(JSON.parse("{\"locations\":" + JSON.stringify(locations) + "}"));
                $(divName).html(html);
                RITUAL.Core.TrainingZone.BookingDates("#ritual-dates", locations[0].Id);

            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },
    BookingDates: function (divName, locationId) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetNextOpenDays',
            data: { "numberofdays": 3, "locationid": locationId },
            success: function (data) {
                var dates = [];
                var html = "";
                for (i = 0; i < data.length; i++) {
                    var date = new Date(parseInt(data[i].substring(6)));
                    dates.push({
                        Date: moment(date).format("MM/DD/YYYY"),
                        DateFriendly: moment(date).format("dddd Do MMM")
                    });
                }
                var template = "";
                template = Handlebars.compile(Templates.bookingdatesdropdown);
                html += template(JSON.parse("{\"dates\":" + JSON.stringify(dates) + "}"));
                $(divName).html(html);
                RITUAL.Core.TrainingZone.BookingsListing("#ritual-bookings", dates[0].Date);

            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    },

    BookingsListing: function (divName, startDate) {
        $.ajax({
            type: "GET",
            url: '/TrainingZone/GetBookingsByDate',
            data: { "date": startDate },
            success: function (data) {

                var timeslots = [];
                var html = "";
                var template = "";
                if (data.AvailableBookingSlots.length > 0) {
                    for (i = 0; i < data.AvailableBookingSlots.length; i++) {
                        var bookingday = new Date(parseInt(data.AvailableBookingSlots[i].BookingDay.substring(6)));
                        var allowBooking = true;
                        if (data.MemberType === "Off-Peak") {
                            if (data.MemberType === data.AvailableBookingSlots[i].BookingStatus) {
                                allowBooking = true;
                            } else {
                                allowBooking = false;
                            }
                        }
                        timeslots.push({
                            StartTime: moment().startOf('day').seconds(data.AvailableBookingSlots[i].StartTime.TotalSeconds).format('H:mm A'),
                            EndTime: moment().startOf('day').seconds(data.AvailableBookingSlots[i].EndTime.TotalSeconds).format('H:mm A'),
                            BookingDay: bookingday,
                            TotalSlots: data.AvailableBookingSlots[i].AvailableSlots,
                            AvailableSlots: (data.AvailableBookingSlots[i].AvailableSlots - data.AvailableBookingSlots[i].BookingCount),
                            BookingCount: data.AvailableBookingSlots[i].BookingCount,
                            Status: data.AvailableBookingSlots[i].Status,
                            TimeSlotId: data.AvailableBookingSlots[i].TimeSlotId,
                            LocationId: data.AvailableBookingSlots[i].LocationId,
                            MemberId: data.AvailableBookingSlots[i].MemberId,
                            DayOfWeek: data.AvailableBookingSlots[i].DayOfWeek,
                            BookingStatus: data.AvailableBookingSlots[i].BookingStatus,
                            ClosureReason: data.AvailableBookingSlots[i].ClosureReason,
                            AllowBooking: allowBooking
                        });
                    }
                    template = Handlebars.compile(Templates.bookingtimeslots);
                    html += template(JSON.parse("{\"timeslots\":" + JSON.stringify(timeslots) + "}"));
                } else {

                    template = Handlebars.compile(Templates.nobookingslots);
                    html += template();
                }
                $(divName).html(html);
                RITUAL.Core.TrainingZone.BookingListingHandlers();
            },
            error: function (xhr) {
                //debugger;  
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
    }
}

