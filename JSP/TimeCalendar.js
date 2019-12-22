/*

Copyright (c) 2010 Yart Pty Ltd
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:
The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

TimeCalendar version 0.204 (5th Oct 2010)

*/


$(document).ready(function () {

  $(".TimeCalendar").each(function (index) {

    //determine if the elements have an id
    var id = $(this).attr("id");

    if (id.length == 0) {
      //if not, create an id for them
      id = new Date();
      id = id.getTime().toString();
      $(this).attr("id", id);
    }

    //make the TimeCalendar and append it to the html
    var idTimeCalendar = "dt_" + index.toString() + "_" + id.toString();
    var control = '<div class="DateTimeCalendar" id="' + idTimeCalendar + '"><table border="1"><tbody><tr><td colspan="7" align="center"><table class="tblMonthYear" border="0"><tbody><tr><td class="yb"><a ><img src="YearBefore.gif" border="0" alt="year before"/></a></td><td class="mb"><a ><img src="MonthBefore.gif" alt="month before" border="0"/></a></td><td width="100%"><input type="text" class="dt"/></td><td class="ma"><a ><img src="MonthAfter.gif" border="0" alt="month after"/></a></td><td class="ya"><a ><img src="YearAfter.gif" border="0" alt="year after"/></a></td></tr></tbody></table></td></tr><tr class="trDayOfWeek"><td>M</td><td>T</td><td>W</td><td>T</td><td>F</td><td class="weekend">S</td><td class="weekend">S</td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trDate"><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr class="trTime"><td colspan="7"><input type="text" maxlength="2" class="dthr"/><span class="colon">:</span><input type="text" maxlength="2" class="dtmi"/><a><div class="dtampm"></div></a></td></tr></tbody></table><a class="dtclose">close</a></div>';

    $(control).appendTo('body');

    //position it under the div that has the date
    var pos = $(this).offset();
    var height = $(this).height();

    $("#" + idTimeCalendar).css({ "left": pos.left + "px", "top": pos.top + height + 5 + "px" });


    //get the date from the html element assuming its a div
    var dt = new Date(Date.parse($(this).text()));

    if (isNaN(dt)) {
      //if no value, this may be an input
      dt = new Date(Date.parse($(this).val()));
    }

    if (isNaN(dt) && $(this).text().length == 0 && $(this).val().length == 0) {
      // Textbox is blank, default to Now
      dt = new Date();
    }

    if (isNaN(dt)) {
      var error = "Make sure your date is in a format like this:\n\n1 Apr 2011 1:00 pm\n\nNote the spaces, particularly the single space between the minutes and the am/pm!";
      alert(error);

      $(this).hover(function () {
        alert(error);
      }, function () {
      });

    }
    else {

      //create the class that controls the TimeCalendar
      var yartDateTime = new TimeCalendar(dt, idTimeCalendar, id);

      //$(this).val(yartDateTime.FriendlyDateTime(dt));deleted 27 Septmber 2010 P Surna, doesn't seem to do anything as date is already written
      //also causes a bug by adding time when its set to false

      yartDateTime.DrawTable(); //complete the calender styles

      HoverEvent(this, idTimeCalendar);

      //close the calendar explicitly
      $(this).click(function () {

        $("#" + idTimeCalendar).attr("displayed", "true");
        $("#" + idTimeCalendar).attr("hide", "false"); //remind the TimeCalendar not to hide itself
        ShowDateTimeCalendar(idTimeCalendar);

      });

      $(".dtclose").css("cursor", "pointer");

      //close the calendar explicitly
      $(".dtclose").click(function () {

        $("#" + idTimeCalendar).attr("hide", "true");
        window.setTimeout("CloseTimeCalendar('" + idTimeCalendar + "')", 100); //but only if we hover back over the html

      });
    }
  });
}
);


function HoverEvent(TimeCalendar, idTimeCalendar) {

  //show the calendar when we hover over the html input element
  $(TimeCalendar).hover(function () {

    $("#" + idTimeCalendar).attr("displayed", "true");
    $("#" + idTimeCalendar).attr("hide", "false"); //remind the TimeCalendar not to hide itself
    setTimeout(function () { ShowDateTimeCalendar(idTimeCalendar); }, 500); //dont show the calendar for 600 milliseconds, if the user does not hover for this long, the user won't see it

  }, function () {

    $("#" + idTimeCalendar).attr("hide", "true");
    window.setTimeout("CloseTimeCalendar('" + idTimeCalendar + "')", 300);

  });


  //keep showing the calendar if we hover over it
  $("#" + idTimeCalendar).hover(function () {
    $("#" + idTimeCalendar).attr("hide", "false"); //remind the TimeCalendar not to hide itself
  }, function () {
    $("#" + idTimeCalendar).attr("hide", "true"); //tell the TimeCalendar to hide itself
    window.setTimeout("CloseTimeCalendar('" + idTimeCalendar + "')", 600); //but only if we hover back over the html
  });

}


function ShowDateTimeCalendar(idTimeCalendar) {

  if ($("#" + idTimeCalendar).attr("displayed") == "true") {
    $("#" + idTimeCalendar).show(600);
  }

}


function CloseTimeCalendar(idTimeCalendar) {

  var timeCalendar = $("#" + idTimeCalendar);

  $("#" + idTimeCalendar).attr("displayed", "false"); //tell the TimeCalendar to not show itself in case ShowDateTimeCalendar is called after this method

  //if a mouse over the calendar hasn't set hide to false
  if (timeCalendar.attr("hide") == "true") {
    $(timeCalendar).hide(400);
  }
}


//dateTime - The Date of the TimeCalendar
function TimeCalendar(dateTime, idTimeDateCalendar, idParentControl) {

  this._dateTime = dateTime;
  this._idParentControl = idParentControl;
  this._idTimeDateCalendar = idTimeDateCalendar; //the id of the table that contains the Calendar
  this._showTime = true;
  this._cells;
  this._startDayOfWeek;

  this._parentControl = $("#" + idParentControl);
  this._timeDateCalendar = $("#" + idTimeDateCalendar);

  //image path
  this._imagePath = GetStyleAttribute(this._parentControl, "imagePath", "");

  //validation
  this._minimumDate = GetStyleAttributeDate(this._parentControl, "minimumDate");
  this._maximumDate = GetStyleAttributeDate(this._parentControl, "maximumDate");

  //properties of the time row
  this._showTime = GetStyleAttributeBool(this._parentControl, "showTime", true);

  //variables to keep in memory so when we draw the calendar we take the least amount of time possible
  this._row7 = $("#" + this._idTimeDateCalendar + " tr:nth-child(7)");
  this._row8 = $("#" + this._idTimeDateCalendar + " tr:nth-child(8)");
  this._dthr = $("#" + this._idTimeDateCalendar + " .dthr");
  this._dtmi = $("#" + this._idTimeDateCalendar + " .dtmi");
  this._dtampm = $("#" + this._idTimeDateCalendar + " .dtampm");


  this.CompleteCalendar = function () {

    var backGroundColor, cell, cells, colno, i, rowno, selector, textColor;
    var startMonth = new Date(this._dateTime.getFullYear(), this._dateTime.getMonth(), 1, 0, 0, 0, 0);
    this._startDayOfWeek = startMonth.getDay();
    var daysInMonth = this.DaysInMonth(this._dateTime.getMonth(), this._dateTime.getFullYear());

    var now = new Date();
    var isThisMonth = (this._dateTime.getFullYear() == now.getFullYear()) && (this._dateTime.getMonth() == now.getMonth());

    //get all the possible td cells we could be writing a day in
    selector = "#" + this._idTimeDateCalendar + " tr:gt(2) td";
    this._cells = $(selector);
    this._cells.length -= 1; //don't alter the time field

    //$(this._cells).empty().append(" ").css("background-color", this._backGroundColor);
    $(this._cells).empty().append(" ");

    this._startDayOfWeek = this._startDayOfWeek == 0 ? 6 : this._startDayOfWeek - 1;

    // Reset classes
    $(selector).removeClass('weekend today selected');

    for (i = 0; i < daysInMonth; ) {

      row_no = Math.floor((i + this._startDayOfWeek) / 7);
      col_no = (i + this._startDayOfWeek) - row_no * 7;

      cell = this._cells[col_no + row_no * 7];

      var isWeekend = false;
      if (col_no >= 5)
        isWeekend = true;

      var isSelected = false;
      if (i == this._dateTime.getDate() - 1) {
        backGroundColor = this._selectedBackGroundColor;
        textColor = this._selectedTextColor;
        isSelected = true;
      }
      else {
        backGroundColor = this._backGroundColor;
        textColor = this._textColor;
      }

      var isToday = false;
      if (isThisMonth && (now.getDate() == i + 1))
        isToday = true;

      var text = (i + 1).toString();
      if (isToday)
        text = "<b>" + text + "</b>";

      $(cell).empty()
             .removeClass()
             .append("<a>" + text + "</a>")
             .data("TimeCalendar", this)
             .data("selectedDay", i + 1)
             .click(TimeCalendarDayClicked);

      if (isWeekend)
        $(cell).addClass('weekend');
      if (isToday)
        $(cell).addClass('today');
      if (isSelected)
        $(cell).addClass('selected');

      i++;
    }

    row_no = Math.ceil((i + this._startDayOfWeek) / 7);

    //determine which of the last two rows to show
    if (row_no <= 4) {
      $(this._row7).hide();
      $(this._row8).hide();
    }
    else if (row_no <= 5) {
      $(this._row7).show();
      $(this._row8).hide();
    }
    else {
      $(this._row7).show();
      $(this._row8).show();
    }
  }


  function DateChanged() {

    var originalObject = $(this).data("TimeCalendar");

    var val = $("#" + originalObject._idTimeDateCalendar + " .dt").val();

    var dt = new Date(Date.parse(val));

    if (isNaN(dt)) {
      //the date format could not be parsed

      //reset the date to the original date
      originalObject.DisplayDate();
    }
    else {
      //reassign the date object making sure we keep the time
      originalObject._dateTime = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate(), originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

      originalObject.DisplayDate();
      originalObject.CompleteCalendar();
      originalObject.DisplayDateTime();
    }
  }


  //check if the date dt is valid according to validation
  function DateValid(dt, originalObject) {
    var dterror, error, valid = true;

    if (originalObject._minimumDate != null) {
      if (dt.valueOf() < originalObject._minimumDate.valueOf()) {
        valid = false;

        if (originalObject._showTime)
          error = "The date cannot be before " + this.FriendlyDateTime(originalObject._minimumDate);
        else
          error = "The date cannot be before " + FriendlyDate(originalObject._minimumDate);
      }
    }

    if (valid) {
      if (originalObject._maximumDate != null) {
        if (dt.valueOf() > originalObject._maximumDate.valueOf()) {
          valid = false;

          if (originalObject._showTime)
            error = "The date cannot be after " + this.FriendlyDateTime(originalObject._maximumDate);
          else
            error = "The date cannot be after " + FriendlyDate(originalObject._maximumDate);
        }
      }
    }

    if (!valid) {
      dterror = $("#dterror");

      if (dterror.length == 0) {
        var control = '<div id="dterror"></div>';
        $(control).appendTo('body');

        dterror = $("#dterror");
      }

      var offset = $("#" + originalObject._idParentControl).offset();

      dterror.css("left", offset.left)
             .css("top", offset.top)
             .text(error)
             .fadeIn("fast", function () {
               setTimeout("$('#dterror').fadeOut('slow')", 4000);
             });
    }

    return valid;
  }


  this.DaysInMonth = function (month, year) {
    return 32 - new Date(year, month, 32).getDate();
  }


  //display the date at the top of the calendar
  this.DisplayDate = function () {

    $("#" + this._idTimeDateCalendar + " > table td:first .dt").val(FriendlyDate(this._dateTime))
    .css("font", this._font);

  }


  //display the date in the parent html control that this calendar is attached to
  this.DisplayDateTime = function () {

    var ampm, str;
    var dt = this._dateTime;

    var hour = dt.getHours();

    if (hour > 12) {
      hour -= 12;
      ampm = "pm";
    }
    else if (hour == 12) {
      ampm = "am";
    }
    else if (hour == 0) {
      hour = 12;
      ampm = "pm";
    }
    else
      ampm = "am";

    var minutes = dt.getMinutes();

    if (this._showTime)
      str = dt.getDate() + " " + FriendlyMonth(this._dateTime.getMonth()) + " " + dt.getFullYear().toString() + " " + hour.toString() + ":" + FriendlyMinute(minutes) + " " + ampm;
    else
      str = dt.getDate() + " " + FriendlyMonth(this._dateTime.getMonth()) + " " + dt.getFullYear().toString();

    $("#" + this._idParentControl).val(str);
  }


  //display the time at the bottom of the calendar
  this.DisplayTime = function () {
    if (this._showTime) {

      $("#" + this._idTimeDateCalendar + " .dtampm").empty();

      var dthr = this._dateTime.getHours();

      if (dthr > 12) {
        $("#" + this._idTimeDateCalendar + " .dtampm").append("pm");
        dthr -= 12;
      }
      else if (dthr == 0) {
        dthr = 12;
        $("#" + this._idTimeDateCalendar + " .dtampm").append("am");
      }
      else
        $("#" + this._idTimeDateCalendar + " .dtampm").append("am");

      $(this._dthr).attr("value", dthr);

      dtmi = FriendlyMinute(this._dateTime.getMinutes());

      $(this._dtmi).attr("value", dtmi);

      //add events to the time fields
      $(this._dthr).data("TimeCalendar", this);
      $(this._dtmi).data("TimeCalendar", this);
      $("#" + this._idTimeDateCalendar + " .dtampm").data("TimeCalendar", this);

    }
  }


  this.DrawTable = function () {
    this.InitialiseStyles();
    this.DrawTimeCalendar();
  }


  this.DrawTimeCalendar = function () {
    this.DisplayDate();
    this.DisplayTime();
    this.CompleteCalendar();
    this.InitialiseFastMonthYear();
    this.InitialiseDateTimeInputChange();
    this.ImagePaths();
  }


  //the selected date in a readable format
  function FriendlyDate(dt) {
    var str;

    str = dt.getDate().toString() + " " + FriendlyMonth(dt.getMonth()) + " " + dt.getFullYear().toString();

    return str;
  }


  this.FriendlyDateTime = function (dt) {

    var ampm, hour = dt.getHours();

    if (hour > 12) {
      hour -= 12;
      ampm = "am";
    }
    else if (hour == 0) {
      hour = 12;
      ampm = "pm";
    }
    else
      ampm = "pm";

    var minutes = dt.getMinutes();

    var str = FriendlyDate(dt) + " " + hour.toString() + ":" + FriendlyMinute(minutes) + " " + ampm;

    return str;
  }


  function FriendlyHour(hour) {
    value = parseInt(hour);

    if (value >= 12)
      value -= 12;

    return value;
  }


  function FriendlyMinute(value) {

    value = parseInt(value);

    if (value <= 9)
      value = "0" + value.toString();
    else
      value = value.toString();

    return value;
  }


  //the selected month as a readable string
  function FriendlyMonth(month) {
    var month_str;

    switch (month) {
      case 0: month_str = "Jan"; break;
      case 1: month_str = "Feb"; break;
      case 2: month_str = "Mar"; break;
      case 3: month_str = "Apr"; break;
      case 4: month_str = "May"; break;
      case 5: month_str = "Jun"; break;
      case 6: month_str = "Jul"; break;
      case 7: month_str = "Aug"; break;
      case 8: month_str = "Sep"; break;
      case 9: month_str = "Oct"; break;
      case 10: month_str = "Nov"; break;
      case 11: month_str = "Dec"; break;
    }

    return month_str;
  }


  function GetStyleAttribute(parentControl, attribute, default_value) {

    var style, value;

    value = parentControl.attr(attribute);

    if (typeof (value) == "undefined" || value.length == 0)
      style = default_value;
    else
      style = value;

    return style;
  }


  function GetStyleAttributeBool(parentControl, attribute, default_value) {

    var style, value;

    value = parentControl.attr(attribute);

    if (typeof (value) == "undefined" || value.length == 0)
      style = default_value;
    else {
      if ((/^true$/i).test(value))
        style = true;
      else if ((/^false$/i).test(value))
        style = false;
      else
        style = default_value;
    }

    return style;
  }


  function GetStyleAttributeDate(parentControl, attribute) {

    var dt, value;

    value = parentControl.attr(attribute);

    if (typeof (value) == "undefined" || value.length == 0)
      dt = null;
    else {

      dt = new Date(value);

      if (isNaN(dt))
        dt = null;
    }

    return dt;
  }


  //returns the integer value in the text box
  this.GetValue = function (id) {
    var value;
    value = $("#" + id).attr("value");

    value = parseInt(value);

    return value;
  }


  function IncrementNumber(value, min, max, step) {
    result = parseInt(value) + step;
    if (result > max)
      result = min;
    else if (result < min)
      result = max;
    return result;
  }

  //allow the date time to be directly edited in the parent control
  this.InitialiseDateTimeInputChange = function () {

    $(this._parentControl).data("TimeCalendar", this);

    $(this._parentControl).change(function () {

      originalObject = $(this).data("TimeCalendar");
      RefreshDateTime(originalObject, this);

    });

    $(this._parentControl).keypress(function (event) {
      if (event.keyCode == '13') {
        originalObject = $(this).data("TimeCalendar");
        event.preventDefault();
        RefreshDateTime(originalObject, this);
        $(originalObject._timeDateCalendar).hide();
      }
    });

    // Handle keypress up/down on time textboxes
    $(this._dthr).keypress(function (event) {
      if (event.keyCode == '38')
        $(this).val(IncrementNumber($(this).val(), 1, 12, 1));
      else if (event.keyCode == '40')
        $(this).val(IncrementNumber($(this).val(), 1, 12, -1));
    });
    $(this._dtmi).keypress(function (event) {
      if (event.keyCode == '38')
        $(this).val(FriendlyMinute(IncrementNumber($(this).val(), 0, 59, 1)));
      if (event.keyCode == '40')
        $(this).val(FriendlyMinute(IncrementNumber($(this).val(), 0, 59, -1)));
    });

    $(this._dthr).bind('mouseleave change', function () {

      var originalObject, ok, restore, value;

      originalObject = $(this).data("TimeCalendar");
      //value = originalObject.GetValue(originalObject._idTimeDateCalendar + " .dthr");
      value = $(originalObject._dthr).val();
      value = GetInt(value);

      restore = false;

      var dt = new Date(originalObject._dateTime.getFullYear(), originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), value, originalObject._dateTime.getMinutes(), 0, 0);

      //don't allow hours over 12
      if (value > 12 || value < 1) {
        restore = true;
      }
      else if (!isNaN(dt) && DateValid(dt, originalObject)) {
        restore = false;
      }

      if (restore) {
        $(this).val(FriendlyHour(originalObject._dateTime.getHours()));
      }
      else {
        originalObject._dateTime = dt;
        $(originalObject._dthr).val(dt.getHours());
        originalObject.DisplayDateTime();
      }



    });


    $(this._dtmi).bind('mouseleave change', function () {

      var originalObject, ok, value;

      originalObject = $(this).data("TimeCalendar");
      //value = originalObject.GetValue(originalObject._idTimeDateCalendar + " .dtmi");
      value = $(originalObject._dtmi).val();

      var dt = new Date(originalObject._dateTime.getFullYear(), originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), originalObject._dateTime.getHours(), value, 0, 0);

      if (!isNaN(dt) && DateValid(dt, originalObject)) {
        originalObject._dateTime = dt;
        $(originalObject._dtmi).val(FriendlyMinute(value));
        originalObject.DisplayDateTime();
      }
      else {
        $(this).val(FriendlyMinute(originalObject._dateTime.getMinutes()));
      }

    });


    $("#" + this._idTimeDateCalendar + " .dtampm").click(function () {

      var dt;
      originalObject = $(this).data("TimeCalendar");

      if ($(this).text() == "am") {
        dt = new Date(originalObject._dateTime.getFullYear(), originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), originalObject._dateTime.getHours() + 12, originalObject._dateTime.getMinutes(), 0, 0);
        $(this).text("pm");
      }
      else {
        dt = new Date(originalObject._dateTime.getFullYear(), originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), originalObject._dateTime.getHours() - 12, originalObject._dateTime.getMinutes(), 0, 0);
        $(this).text("am");
      }

      originalObject._dateTime = dt;
      originalObject.DisplayDateTime();

    });

  }


  function GetInt(val) {

    var int_val = parseInt(val);

    if (isNaN(int_val))
      int_val = -1;

    return int_val;
  }


  function RefreshDateTime(originalObject, parentInput) {

    var dt = new Date(Date.parse($(parentInput).val()));

    if (!isNaN(dt) && DateValid(dt, originalObject)) {
      originalObject._dateTime = dt;

      originalObject.DisplayDate();
      originalObject.DisplayTime();
      originalObject.CompleteCalendar();

    }
    else
      $(parentInput).val(this.FriendlyDateTime(originalObject._dateTime));
  }


  this.InitialiseFastMonthYear = function () {

    //alow the date to be edited directly
    $("#" + this._idTimeDateCalendar + " .dt").bind('mouseleave change', DateChanged);
    $("#" + this._idTimeDateCalendar + " .dt").data("TimeCalendar", this);

    //decrease the year
    $("#" + this._idTimeDateCalendar + " .yb").click(YearBefore)
    $("#" + this._idTimeDateCalendar + " .yb").data("TimeCalendar", this);

    //increase the year
    $("#" + this._idTimeDateCalendar + " .ya").click(YearAfter)
    $("#" + this._idTimeDateCalendar + " .ya").data("TimeCalendar", this);

    //decrease the month
    $("#" + this._idTimeDateCalendar + " .mb").click(MonthBefore)
    $("#" + this._idTimeDateCalendar + " .mb").data("TimeCalendar", this);

    //increase the month
    $("#" + this._idTimeDateCalendar + " .ma").click(MonthAfter)
    $("#" + this._idTimeDateCalendar + " .ma").data("TimeCalendar", this);
  }


  this.InitialiseStyles = function () {

    //add the table border
    //$("#" + this._idTimeDateCalendar + " table").first().attr("style", this._tableBorder);
    //$("#" + this._idTimeDateCalendar + " tr:gt(1) td").css("padding", this._cellPadding);
    //$("#" + this._idTimeDateCalendar + " tr:nth-child(1) td table tr td").attr("padding", this._cellPadding);
    //$("#" + this._idTimeDateCalendar + " tr:nth-child(1) td table tr td").css("vertical-align", "middle");
    //$("#" + this._idTimeDateCalendar + " tr td").css("border", this._cellBorder);
    //$("#" + this._idTimeDateCalendar + " table table tr td").css("border", "0");

    //align text in the center of the td's
    //$("#" + this._idTimeDateCalendar + " tr td").attr("align", "center");

    //color the top row showing the date
    //$("#" + this._idTimeDateCalendar + " tr:nth-child(1) td").css("background-color", this._dateBackGroundColor).css("color", this._dateTextColor);

    //color the row showing the headings
    //$("#" + this._idTimeDateCalendar + " tr:nth-child(2) td").css("background-color", this._headingBackGroundColor).css("color", this._headingTextColor).css("font", this._font);

    //put a color in the cells so empty cells have colour
    //$("#" + this._idTimeDateCalendar + " tr:gt(2) td").css("background-color", this._backGroundColor);

    //color the time row
    if (this._showTime) {
      //$("#" + this._idTimeDateCalendar + " td").last().css("background-color", this._timeRowBackgroundColor);
      //$("#" + this._idTimeDateCalendar + " td").last().children("a").css("color", this._ampmColor);
    }
    else {
      //var last = $("#" + this._idTimeDateCalendar + " tr td").last().children().not(".dtclose").hide();

      //prior to the close link being added this code hid the bottom row if the time was set to not display
      $("#" + this._idTimeDateCalendar + " td").last().hide();
      $("#" + this._idTimeDateCalendar + " tr").last().hide();
    }
  }


  this.ImagePaths = function () {

    var img_path = this._imagePath;

    $("#" + this._idTimeDateCalendar + " img").each(function (i, o) {
      //alert('index: ' + i + ' object id: ' + o.id);

      var src = $(o).attr("src");
      var index = src.lastIndexOf('/');

      var file = src.substr(index + 1);
      var path = src.substr(0, index + 1);

      file = path + img_path + file;

      $(this).attr("src", file);

    });

  }


  function MonthBefore() {

    var dt, originalObject = $(this).data("TimeCalendar"), month, year;

    month = originalObject._dateTime.getMonth();
    year = originalObject._dateTime.getFullYear()

    if (month == 0) {
      month = 11;
      year--;
    }
    else
      month--;

    dt = new Date(year, month, originalObject._dateTime.getDate(), originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

    if (DateValid(dt, originalObject)) {
      originalObject._dateTime = dt;
      originalObject.DisplayDate();
      originalObject.CompleteCalendar();
      originalObject.DisplayDateTime();
    }
  }


  function MonthAfter() {

    var originalObject = $(this).data("TimeCalendar");

    month = originalObject._dateTime.getMonth();
    year = originalObject._dateTime.getFullYear();

    if (month == 11) {
      month = 0;
      year++;
    }
    else
      month++;

    var dt = new Date(year, month, originalObject._dateTime.getDate(), originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

    if (DateValid(dt, originalObject)) {
      originalObject._dateTime = dt;
      originalObject.DisplayDate();
      originalObject.CompleteCalendar();
      originalObject.DisplayDateTime();
    }
  }


  function TimeCalendarDayClicked() {

    var originalObject = $(this).data("TimeCalendar");
    var previousDayOfMonth = originalObject._dateTime.getDate() + originalObject._startDayOfWeek - 1;
    var selectedDay = $(this).data("selectedDay");
    var dayOfMonth = selectedDay + originalObject._startDayOfWeek - 1;

    var dt = new Date(originalObject._dateTime.getFullYear(), originalObject._dateTime.getMonth(), selectedDay, originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

    if (DateValid(dt, originalObject)) {

      //change the colours of the previously selected date
      //$(originalObject._cells[previousDayOfMonth]).css("background-color", originalObject._backGroundColor);
      //$(originalObject._cells[previousDayOfMonth]).children("a").css("background-color", originalObject._backGroundColor).css("color", originalObject._textColor);
      $(originalObject._cells[previousDayOfMonth]).removeClass('selected');

      //highlight the newly selected date
      //$(originalObject._cells[dayOfMonth]).css("background-color", originalObject._selectedBackGroundColor);
      //$(originalObject._cells[dayOfMonth]).children("a").css("background-color", originalObject._selectedBackGroundColor).css("color", originalObject._selectedTextColor);
      $(originalObject._cells[dayOfMonth]).addClass('selected');

      //change the date at the top of the control
      originalObject._dateTime = dt;
      originalObject.DisplayDate();
      originalObject.DisplayDateTime();
    }
  }


  function YearBefore() {

    var originalObject = $(this).data("TimeCalendar");

    var dt = new Date(originalObject._dateTime.getFullYear() - 1, originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

    if (DateValid(dt, originalObject)) {
      originalObject._dateTime = dt;
      originalObject.DisplayDate();
      originalObject.CompleteCalendar();
      originalObject.DisplayDateTime();
    }
  }


  function YearAfter() {

    var originalObject = $(this).data("TimeCalendar");

    dt = new Date(originalObject._dateTime.getFullYear() + 1, originalObject._dateTime.getMonth(), originalObject._dateTime.getDate(), originalObject._dateTime.getHours(), originalObject._dateTime.getMinutes(), 0, 0);

    if (DateValid(dt, originalObject)) {
      originalObject._dateTime = dt;
      originalObject.DisplayDate();
      originalObject.CompleteCalendar();
      originalObject.DisplayDateTime();
    }
  }

}