$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    var isAscending = true;
    var orderBy = 'Title';
    var page = 1;
    var isFilterChanged = false;

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
            'CurrentPage': page,
            'IsFilterChanged': isFilterChanged
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
        var previous = data.Paging.Pages[0] - 1;
        var next = data.Paging.Pages[data.Paging.Pages.length - 1] + 1;

        var listContent =
            '<li class="' + (data.Paging.IsPreviousEnabled === true ? '' : 'disabled') + '">' +
            '<a href="#" aria-label="Previous" page="' + previous + '">' +
            '<span aria-hidden="true">&laquo;</span>' +
            '</a></li>';

        var pages = data.Paging.Pages;

        for (var i = 0; i < pages.length; i++) {
            listContent +=
                '<li class="' + (pages[i] === data.Paging.CurrentPage ? 'active' : '') + '">' +
                '<a href="#" page="' + pages[i] + '">' + pages[i] + '</a></li>';
        }

        listContent = listContent +
            '<li class="' + (data.Paging.IsNextEnabled === true ? '' : 'disabled') + '">' +
            '<a href="#" aria-label="Next" page="' + next + '">' +
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
                isFilterChanged = false;
                $('ul[class="pagination"] > li > a').click(changePage);
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

    function changeFilter() {
        isFilterChanged = true;

        reload();
    }

    function changePage() {
        var value = $(this).attr('page');
        page = parseInt(value);

        reload();
    }

    function subscribe() {
        $('input[name*="Filtering"]').keyup(changeFilter);
        $('button[orderby]').click(changeOrder);
    }

    reload();
    subscribe();
});