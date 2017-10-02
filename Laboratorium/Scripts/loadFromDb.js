function showDialog() {
    console.log("showDialog");
}

$('#Search_TitleSearch').keyup(function () {
    console.log("submit");
    $('#form').submit();
});

function hideDialog() {
    console.log("hideDialog");
    $('#Search_TitleSearch').keyup(function () {
        console.log("submit");
        $('#form').submit();
    });

    $('#Search_TitleSearch').focus();
}

console.log("loadFromDb is loaded");