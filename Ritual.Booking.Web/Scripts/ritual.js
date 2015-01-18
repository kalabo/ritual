$(document).ready(function () {
    $('.jqueryui-datetimepicker').datetimepicker();
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
}