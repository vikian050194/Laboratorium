$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    var isAscending = true;
    var orderBy = 'LastName';
    var page = 1;
    var isFilterChanged = false;
    var isPreviousEnabled = false;
    var previousPage = 0;
    var isNextEnabled = false;
    var nextPage = 0;

    function getData() {
        var filteringFirstName = $('#Filtering_FirstName').val();
        var filteringLastName = $('#Filtering_LastName').val();
        var filteringPatronymic = $('#Filtering_Patronymic').val();
        var filteringRole = $('#Filtering_Role').val();

        var body = {
            'Sorting.IsAscending': isAscending,
            'Sorting.OrderBy': orderBy,
            'Filtering.FirstName': filteringFirstName,
            'Filtering.LastName': filteringLastName,
            'Filtering.Patronymic': filteringPatronymic,
            'Filtering.Role': filteringRole,
            'CurrentPage': page,
            'IsFilterChanged': isFilterChanged
        };

        return body;
    }

    function updateTable(data) {
        var role = $('#Filtering_Role :selected').text();
        var tableBodyContent = '';

        data.Rows.forEach(function (item) {
            var button = '<a type="button" class="btn btn-default" href="ManageUserAccount/' + item.Id + '" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></a>';
            var line = '<tr><td>' + item.LastName + '</td><td>' + item.FirstName + '</td><td>' + item.Patronymic + '</td><td>' + role + '</td><td>' + button + '</td>' + '</td></tr>';
            tableBodyContent += line;
        });

        $('tbody').html(tableBodyContent);
    }

    function updatePaging(data) {
        previousPage = data.Paging.Pages[0] - 1;
        nextPage = data.Paging.Pages[data.Paging.Pages.length - 1] + 1;

        var listContent =
            '<li class="' + (data.Paging.IsPreviousEnabled === true ? '' : 'disabled') + '">' +
            '<a href="#" aria-label="Previous" page="' + previousPage + '">' +
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
            '<a href="#" aria-label="Next" page="' + nextPage + '">' +
            '<span aria-hidden="true">&raquo;</span>' +
            '</a></li>';

        $('ul[class="pagination"]').html(listContent);
    }

    function reload() {
        var data = getData();

        $.ajax({
            type: "POST",
            data: data,
            url: 'AccountsListPartial',
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

        if (page === previousPage && !isPreviousEnabled || page === nextPage && !isNextEnabled) {
            return;
        }

        reload();
    }

    function subscribe() {
        $('input[name*="Filtering"]').keyup(changeFilter);
        $('button[orderby]').click(changeOrder);
        $('select[name*="Filtering"]').change(reload);
    }

    reload();
    subscribe();
});