function enableShortcuts() {
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
    $('#myModal').modal('show');
}

function hideDialog() {
    $('.progress-bar').html('готово');
    setTimeout(function () {
        var tabIndex = $('#error').children().length === 0 ? 1 : 2;
        $('#form-tabs li:eq(' + tabIndex + ') a').tab('show');
        $('#myModal').modal('hide');

        enableShortcuts();
    }, 1000);
}