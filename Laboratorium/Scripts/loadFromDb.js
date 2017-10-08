$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    var isAscending = true;
    var orderBy = 'Title';
    var page = 1;

    function getData() {
        var filteringCode = $('#Filtering_Code').val();
        var filteringTitle = $('#Filtering_Title').val();
        var filteringAuthor = $('#Filtering_Author').val();

        var body = {
            'Sorting.IsAscending': isAscending,
            'Sorting.OrderBy': orderBy,
            'Filtering.Code': filteringCode,
            'Filtering.Title': filteringTitle,
            'Filtering.Author': filteringAuthor,
            'Paging.CurrentPage': page
        };

        return body;
    }

    function updateTable(data) {
        var tableBodyContent = '';

        data.Rows.forEach(function (item) {
            var button = '<a type="button" class="btn btn-default" href="Index/' + item.Id + '" > <span class="glyphicon glyphicon-play" aria-hidden="true"></span></a>';
            var line = '<tr><td>' + item.Title + '</td><td>' + item.Code + '</td><td>' + item.Author + '</td><td>' + button + '</td>' + '</td></tr>'
            tableBodyContent += line;
        });

        $('tbody').html(tableBodyContent);
    }

    function updatePaging(data) {
        var listContent =
            '<li class="' + (data.Paging.IsPreviousEnabled === true ? '' : 'disabled') + '">' +
            '<a href="#" aria-label="Previous">' +
            '<span aria-hidden="true">&laquo;</span>' +
            '</a></li>';

        var pages = data.Paging.Pages;

        for (var i = 0; i < pages.length; i++) {
            listContent +=
                '<li class="' + (pages[i] === data.Paging.CurrentPage ? 'active' : '') + '">' +
                '<a href="#">' + pages[i] + '</a></li>';
        }

        listContent = listContent +
            '<li class="' + (data.Paging.IsNextEnabled === true ? '' : 'disabled') + '">' +
            '<a href="#" aria-label="Previous">' +
            '<span aria-hidden="true">&raquo;</span>' +
            '</a></li>';

        $('ul[class="pagination"]').html(listContent);
    }

    function reload() {
        var data = getData();

        $.ajax({
            type: "POST",
            data: data,
            url: 'LoadFromDbPartial',
            success: function (result) {
                updateTable(result);
                updatePaging(result);
            }
        });
    }

    function changeOrder() {
        $('button[orderby=' + orderBy + ']').removeClass('active');
        $('button[orderby=' + orderBy + '] > span').removeClass('glyphicon-sort-by-attributes glyphicon-sort-by-attributes-alt').addClass('glyphicon-sort-by-attributes');

        $(this).addClass('active');
        var newValue = $(this).attr('orderby');
        isAscending = newValue !== orderBy ? true : !isAscending;
        $('button[orderby=' + newValue + '] > span').removeClass('glyphicon-sort-by-attributes glyphicon-sort-by-attributes-alt').addClass(isAscending ? 'glyphicon-sort-by-attributes' : 'glyphicon-sort-by-attributes-alt');
        orderBy = newValue;

        reload();
    }

    function subscribe() {
        $('input[name*="Filtering"]').keyup(reload);
        $('button[orderby]').click(changeOrder);
    }

    subscribe();

    reload();
});