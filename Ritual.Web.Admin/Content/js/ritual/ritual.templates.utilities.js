/*-----------------------------------------------------------------------------------
	Filename: ritual.templates.utilities.js
	Owner: Ritual Gym - CheatDay PTE Ltd
	Description: Ritual Template Utilties
	Author: Chris Pettigrew
	Version: 1.1.1
	Copyright (c) 2015, All Rights Reserved, http://www.ritualgym.com
/*-----------------------------------------------------------------------------------*/

Handlebars.registerHelper('timefromnow', function (rawdate) {
    return moment(rawdate).fromNow();
});

Handlebars.registerHelper('renderimgfromurlfield', function (data) {
    return data.url;
});

Handlebars.registerHelper('ritualdateformat', function (rawdate) {
    return moment(rawdate).format("DD/MM/YYYY");
});

Handlebars.registerHelper('ritualtimeformat', function (rawdate) {
    return moment(rawdate).format("LT");
});

Handlebars.registerHelper('ritualdatebox', function (rawdate) {
    var html = "<figure class='date'><div class='month'>" + moment(rawdate).format("MMM") + "</div><div class='day'>" + moment(rawdate).format("DD") + "</div></figure>";
    return html;
});

Handlebars.registerHelper('if_eq', function (a, b, opts) {
    if (a == b) // Or === depending on your needs
        return opts.fn(this);
    else
        return opts.inverse(this);
});

Handlebars.registerHelper('upattr', function (attribute) {
    return attribute.split(";").join(" | ");
});

Handlebars.registerHelper('calendartime', function (rawdate) {

    moment.locale('en', {
        calendar: {
            lastDay: '[Yesterday at] LT',
            sameDay: '[Today at] LT',
            nextDay: '[Tomorrow at] LT',
            lastWeek: '[last] dddd [at] LT',
            nextWeek: 'dddd [at] LT',
            sameElse: 'MMMM DD'
        }
    });

    return moment(rawdate).calendar();
});


Handlebars.registerHelper('namenoextension', function (name) {
    return name.replace(/\.[^/.]+$/, "")
});


Handlebars.registerHelper("debug", function (optionalValue) {
    console.log("Current Context");
    console.log("====================");
    console.log(this);

    if (optionalValue) {
        console.log("Value");
        console.log("====================");
        console.log(optionalValue);
    }
});



