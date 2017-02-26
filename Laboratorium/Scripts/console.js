﻿function enableShortcuts() {
    $('textarea').on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode === 9) {
            var val = this.value,
                start = this.selectionStart,
                end = this.selectionEnd;
            this.value = val.substring(0, start) + '    ' + val.substring(end);
            this.selectionStart = this.selectionEnd = start + 4;
            return false;
        }
        if (e.altKey && keyCode === 13) {
            $('#form').submit();
        }
    });
}

enableShortcuts();

function showDialog() {
    $('.progress-bar').html('ожидайте');
    $('.progress-bar').removeClass('progress-bar-success progress-bar-danger').addClass('progress-bar-primary');
    $('#script-execution-modal').modal('show');
}

function hideDialog() {
    var tabIndex;
    var status;
    var barClass;
    $('.progress-bar').removeClass('progress-bar-primary');
    if ($('#error').children().length === 0) {
        tabIndex = 1;
        status = 'готово';
        barClass = 'progress-bar-success';
    } else {
        tabIndex = 2;
        status = 'ошибка';
        barClass = 'progress-bar-danger';
    }
    $('.progress-bar').html(status);
    $('.progress-bar').addClass(barClass);
    $('#form-tabs li:eq(' + tabIndex + ') a').tab('show');
    enableShortcuts();
    setTimeout(function () {
        $('#script-execution-modal').modal('hide');
    }, 1000);
}