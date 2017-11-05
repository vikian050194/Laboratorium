function enableShortcuts() {
    $('textarea').on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode === 9) {
            var val = this.value,
                start = this.selectionStart,
                end = this.selectionEnd;
            this.value = val.substring(0, start) + '    ' + val.substring(end);
            this.selectionStart = this.selectionEnd = start + 4;
            e.preventDefault();
            return;
        }
        if (e.altKey && keyCode === 13) {
            $('button[value="Execute"]').click();
        }
    });
}

enableShortcuts();