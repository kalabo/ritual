/*-----------------------------------------------------------------------------------
	Filename: ritual.templates.js
	Owner: Ritual Gym - CheatDay PTE Ltd
	Description: Ritual Template Utilties
	Author: Chris Pettigrew
	Version: 1.1.1
	Copyright (c) 2015, All Rights Reserved, http://www.ritualgym.com
/*-----------------------------------------------------------------------------------*/

Templates = {};

/* ================================================== UTILITIES ================================================== */

Templates.Preloader = "<img src='/_layouts/15/ICS.Flex/Core/img/myflex-preloader.gif' class='preloader'/>";

Templates.error = [
	"<ul><li><div class='alert-box alert'><i class='fa fa-warning'></i>&nbsp;&nbsp;An error occured while performing the search.</div></li></ul>"
].join("\n");

/* ================================================== ANNOUNCEMENTS ================================================== */
Templates.announcements = [
    "{{#each News}}",
        "<li><a href='#' data-reveal-id='announcement-modal-{{@index}}'>Hello humans.....{{Title}}</a></li>",
    "{{/each}}",
].join("\n");

Templates.announcementsmodals = [
	"{{#each News}}",
		"<div id='announcement-modal-{{@index}}' class='reveal-modal' data-reveal>",
			"<a href='#' class='close-reveal-modal'><i class='fa fa-times'></i></a>",
			"<h1>{{Title}}</h1>",
			"<p>{{{Body}}}</p>",
		"</div>",
	"{{/each}}"
].join("\n");



Templates.announcements_noitems = [
    "<li><a href='#'>No Announcements found</a></li>"
].join("\n");

Templates.bookinglocationsdropdown = [
    "<select id='booking-slot-locations'>",
    "{{#each locations}}",
        "<option value='{{Id}}'>{{Name}} - {{LocalTime}}</option>",
    "{{/each}}",
    "</select>"
].join("\n");

Templates.bookingdatesdropdown = [
    "<select id='booking-slot-dates'>",
    "{{#each dates}}",
        "<option data-location='{{Location}}' value='{{Date}}'>{{DateFriendly}}</option>",
    "{{/each}}",
    "</select>"
].join("\n");

Templates.bookingrollupNoItems = [
     "<table class='table'>",
        "<tr>",
            "<th>Date</th>",
            "<th>Start Time</th>",
            "<th>Location</th>",
            "<th>State</th>",
        "</tr>",
        "<tr>",
            "<td colspan='4'><div class='alert-box'><i class='fa fa-info'></i>&nbsp;&nbsp;No Bookings Found.</div></td>",
        "</tr>",
    "</table>",
].join("\n");

Templates.bookingrollup = [
    "<table class='table'>",
        "<tr>",
            "<th>Date</th>",
            "<th>Start Time</th>",
            "<th>Location</th>",
            "<th>State</th>",
        "</tr>",
        "{{#each Bookings}}",
                "<tr>",
                    "<td>",
                        "{{DateFriendly}}",
                    "</td>",
                    "<td>",
                        "{{StartTime}}",
                    "</td>",
                    "<td>",
                        "{{Location}}",
                    "</td>",
                    "<td>",
                        "{{BookingState}}",
                    "</td>",
                "</tr>",
        "{{/each}}",
    "</table>",
].join("\n");

Templates.bookingtimeslots = [
    "",
    "{{#each timeslots}}",
        "{{#if_eq Status 'Available'}}",
            "<div class='booking-slot available {{BookingStatus}}'>",
                "<h1>{{DayOfWeek}}</h1>",
                "<h2>{{StartTime}}</h2>",
                "<br />",
                "<span class='booking-slots-available'>{{AvailableSlots}}</span>",
                "<br />",
                "{{#if AllowBooking}}",
                "<a href='/trainingzone/Confirmbooking?TimeslotId={{TimeSlotId}}&LocationId={{LocationId}}&BookingDate={{BookingDay}}'>",
                    "<div class='button session-booking'>Book</div>",
                "</a>",
                "{{else}}",
                    "<div class='button session-booking'>Not Available</div>",
                "{{/if}}",
            "</div>",
        "{{else}}",
            "{{#if_eq Status 'Booked'}}",
                "<div class='booking-slot booked {{BookingStatus}}'>",
                    "<h1>{{DayOfWeek}}</h1>",
                    "<h2>{{StartTime}}</h2>",
                    "<br />",
                    "<span class='booking-slots-available'>BOOKED</span>",
                    "<br />",
                    "<div class='button session-booking cancel-booking' data-timeslot='{{TimeSlotId}}' data-memberid='{{MemberId}}' data-locationid='{{LocationId}}' data-bookingdate='{{BookingDay}}'>Cancel Booking</div>",
                "</div>",
            "{{else}}",
                "<div class='booking-slot closed'>",
                    "<h1>{{DayOfWeek}}</h1>",
                    "{{StartTime}}<br />",
                    "{{ClosureReason}}",
                "</div>",
            "{{/if_eq}}",


        "{{/if_eq}}",

    "{{/each}}",
    ""
].join("\n");

Templates.nobookingslots = [
	"<div class='alert-box alert'><i class='fa fa-warning'></i>&nbsp;&nbsp;The Gym is currently closed.</div>"
].join("\n");
