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

Templates.bookingdropdown = [
    "<select id='booking-slot-dates'>",
    "{{#each dates}}",
        "<option value='{{Date}}'>{{DateFriendly}}</option>",
    "{{/each}}",
    "</select>"
].join("\n");

Templates.bookingtimeslots = [
    "",
    "{{#each timeslots}}",
        "{{#if_eq Status 'Available'}}",
            "<div class='booking-slot available'>",
                "<h1>{{DayOfWeek}}</h1>",
                "<h2>{{StartTime}}</h2>",
                "<br />",
                "<span class='booking-slots-available'>{{AvailableSlots}}</span>",
                "<br />",
                "<a href='/trainingzone/Confirmbooking?TimeslotId={{TimeSlotId}}&LocationId={{LocationId}}&BookingDate={{BookingDay}}'>",
                    "<div class='button session-booking'>Book</div>",
                "</a>",
            "</div>",
        "{{else}}",
            "{{#if_eq Status 'Booked'}}",
                "<div class='booking-slot booked'>",
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
