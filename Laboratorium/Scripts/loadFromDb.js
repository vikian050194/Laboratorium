$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    var isAscending = true;
    var orderBy = 'Title';
    var page = 1;
    var isFilterChanged = false;
    var isPreviousEnabled = false;
    var previousPage = 0;
    var isNextEnabled = false;
    var nextPage = 0;

    function getData() {
        var filteringScript = $('#Filtering_Script').val();
        var filteringTitle = $('#Filtering_Title').val();
        var filteringAuthor = $('#Filtering_Author').val();
        var filteringIsPublic = $('#Filtering_IsPublic').val();
        var filteringIsReusable = $('#Filtering_IsReusable').val();

        var body = {
            'Sorting.IsAscending': isAscending,
            'Sorting.OrderBy': orderBy,
            'Filtering.Script': filteringScript,
            'Filtering.Title': filteringTitle,
            'Filtering.Author': filteringAuthor,
            'Filtering.IsPublic': filteringIsPublic,
            'Filtering.IsReusable': filteringIsReusable,
            'CurrentPage': page,
            'IsFilterChanged': isFilterChanged
        };

        return body;
    }

    function updateTable(data) {
        var isPublic = $('#Filtering_IsPublic :selected').text();
        var isReusable = $('#Filtering_IsReusable :selected').text();
        var tableBodyContent = '';

        data.Rows.forEach(function (item) {
            var buttonRun = '<a title="Открыть и выполнить" type="button" class="btn btn-default" href="Index/' + item.Id + '" > <span class="glyphicon glyphicon-play" aria-hidden="true"></span></a>';
            var buttonShow = '<a  target="_blank" title="Просмотреть" type="button" class="btn btn-default" href="ShowFullPacket/' + item.Id + '" > <span class="glyphicon glyphicon-text-color" aria-hidden="true"></span></a>';
            var line = '<tr><td>' + item.Title + '</td><td>' + item.Script + '</td><td>' + item.Author + '</td><td>' + isPublic + '</td><td>' + isReusable + '</td><td>' + buttonShow + '</td><td>' + buttonRun + '</td>' + '</td></tr>';
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

        if (page === previousPage && !isPreviousEnabled || page === nextPage && !isNextEnabled) {
            return;
        }

        reload();
    }

    function subscribe() {
        $('input[name*="Filtering"]').keyup(changeFilter);
        $('select[name*="Filtering"]').change(changeFilter);
        $('button[orderby]').click(changeOrder);
    }

    reload();
    subscribe();
});