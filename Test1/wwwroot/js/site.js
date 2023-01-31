namespace Test1.wwwroot.js
{
    document.getElementById("selectEngineersButton").addEventListener("click", selectEngineers);

    function selectEngineers() {
        // Retrieve list of engineers from back-end API
        fetch('/api/engineers')
            .then(response => response.json())
            .then(engineers => {
                // Apply business logic to select two engineers
                // ...
            });
    }
    //no clue on this
    document.addEventListener('DOMContentLoaded', function () { 
        var calendarEl = document.getElementById('calendar');
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            events: [
                {
                    title: 'Engineer 1',
                    start: '2023-01-28'
                },
                {
                    title: 'Engineer 2',
                    start: '2023-01-29'
                },
                {
                    title: 'Engineer 3',
                    start: '2023-01-28'
                },
                {
                    title: 'Engineer 4',
                    start: '2023-01-29'
                },
                // Add more events as needed
            ]
        });
        calendar.render();
    });

    function randomizeEngineers() {
        // Code to randomly select two engineers and update the events on the calendar
 
        $.ajax({
            url: '/api/engineers',
            success: function (engineers) {
                var engineer1 = engineers[Math.floor(Math.random() * engineers.length)];
                var engineer2 = engineers[Math.floor(Math.random() * engineers.length)];
                calendar.addEvent({
                    title: engineer1.name,
                    start: '2023-02-01'
                });
                calendar.addEvent({
                    title: engineer2.name,
                    start: '2023-02-02'
                });
            }
        });
    }

    $(document).ready(function () {
        $("#generateCalendar").click(function () {
            generateCalendar();
        });
    });

    function generateCalendar() {
        // Call the API to retrieve the list of engineers
        $.ajax({
            type: "GET",
            url: "api/engineers",
            success: function (engineers) {
                // Call the API to generate the schedule
                $.ajax({
                    type: "POST",
                    url: "api/schedule",
                    data: JSON.stringify(engineers),
                    contentType: "application/json",
                    success: function (schedule) {
                        // Render the calendar with the schedule
                        $("#calendar").fullCalendar({
                            events: schedule
                        });
                    }
                });
            }
        });
    }

}
