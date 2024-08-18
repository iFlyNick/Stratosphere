(function ($) {
    "use strict";

    //helper to handle grids across multiple areas. should help keep this to one grid at a time
    let grid;
    let subpage;

    //namespace registration for global access
    window.Stratosphere = window.Stratosphere || {};

    //namespace public methods to be called from admin child pages
    window.Stratosphere.loadServicesDataGrid = loadServicesDataGrid;
    window.Stratosphere.loadServiceTypesDataGrid = loadServiceTypesDataGrid;

    function bindAdminSections() {
        $('.adminAreaButton').on('click', function () {
            setupAdminSection($(this));
        });
    };

    function setupAdminSection(element) {
        element.addClass('active').parent().siblings().find('.adminAreaButton').removeClass('active');
        var target = element.parent().attr('id');
        $('#adminObjectContainer').html('');
        loadAdminSection(target);
    };

    function loadAdminSection(section) {
        var targetElement = "adminObjectContainer";
        var url = `Administration/${section}/Index?handler=${section}`;
        subpage = section;

        grid = undefined;

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                $(`#${targetElement}`).html(data);
                adminSectionButtonBinding();
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function addNewServiceTypeListener() {
        //submit button on the offcanvas
        $('#newServiceTypeSubmit').on('click', function () {
            var serviceTypeName = $('#serviceTypeModalName').val();

            var formData = {
                name: serviceTypeName
            };

            handleNewServiceTypeSubmit(formData);
        });
    };

    function addNewServiceListener() {
        //submit button on the offcanvas
        $('#newServiceSubmit').on('click', function () {
            var serviceName = $('#serviceModalName').val();
            var serviceDescription = $('#serviceModalDescription').val();
            var serviceType = $('#serviceModalType').val();

            var formData = {
                name: serviceName,
                description: serviceDescription,
                type: serviceType
            };

            handleNewServiceSubmit(formData);
        });
    };

    function addOffcanvasSubmitListeners() {
        addNewServiceTypeListener();
        addNewServiceListener();
    };

    function clearOffcanvasForm() {
        $('.offcanvas-body').find('form')[0].reset();
    };

    function addOffcanvasHelpers() {
        $('#adminCanvas').on('hide.bs.offcanvas', function () {
            $(this).addClass('d-none');
            clearOffcanvasForm();
        });

        $('#adminCanvas').on('shown.bs.offcanvas', function () {
            $(this).removeClass('d-none').css("style", "");
        });
    };

    function adminSectionButtonBinding() {
        addOffcanvasSubmitListeners();
        addOffcanvasHelpers();
        bindRefreshGridButton();
    };

    function bindRefreshGridButton() {
        $('#adminRefreshGridButton').on('click', function () {
            refreshGrid($(this), true); //allow spinner to show loading status when user requests a refresh
        });
    };

    function handleNewServiceTypeSubmit(data) {
        $.ajax({
            type: 'POST',
            url: `Administration/ServiceTypes/Index?handler=ServiceType`,
            contentType: 'application/json',
            data: JSON.stringify(data),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                $('#adminCanvas').addClass('d-none');
                clearOffcanvasForm();
                refreshGrid($('#adminRefreshGridButton'));
                successAlert("Successfully created Service Type");
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function handleNewServiceSubmit(data) {
        $.ajax({
            type: 'POST',
            url: `Administration/Services/Index?handler=Service`,
            contentType: 'application/json',
            data: JSON.stringify(data),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                $('#adminCanvas').addClass('d-none');
                clearOffcanvasForm();
                refreshGrid($('#adminRefreshGridButton'));
                successAlert("Successfully created Service");
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function successAlert(message) {
        $('.adminHeaderRow').after(`<div class="alert alert-success alert-dismissible fade show" role="alert">${message}<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>`);
    };

    function handleAdminDataResponse(jsonData) {
        //idk something here
        console.table(jsonData);
    };

    function getAdminData(url) {
        $.ajax({
            type: 'GET',
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                handleAdminDataResponse(data);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function deleteAdminData(url) {
        $.ajax({
            type: 'DELETE',
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                refreshGrid($('#adminRefreshGridButton'));
                successAlert("Successfully removed Service Type");
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function bindEditButtons(url) {
        $('td[data-column-id="actions"] button.btn-primary').on('click', function () {
            var element = $(this);
            var redirectUrl = url + '&name=' + encodeURIComponent($(element).closest('tr').find('td[data-column-id="name"]').text());
            getAdminData(redirectUrl);
        });
    };

    function bindDeleteButtons(url) {
        $('td[data-column-id="actions"] button.btn-secondary').on('click', function () {
            var element = $(this);
            var redirectUrl = url + '&name=' + encodeURIComponent($(element).closest('tr').find('td[data-column-id="name"]').text());
            deleteAdminData(redirectUrl);
        });
    };

    function bindDataGridButtons(url) {
        bindEditButtons(url);
        bindDeleteButtons(url);
    };

    function addRowButtons(url) {
        var tableRows = $('td[data-column-id="actions"]');

        for (let r = 0; r < tableRows.length; r++) {
            var activeRow = $(tableRows[r]);
            var rowName = $(activeRow).siblings('td[data-column-id="name"]').text();

            var buttonRowHtml = `<div class="d-flex justify-content-around"><button type="button" class="btn btn-primary"><i class="bi bi-pencil-fill"></i></button><button type="button" class="btn btn-secondary"><i class="bi bi-trash3"></i></button></div>`;

            $(activeRow).html(buttonRowHtml);
        };

        bindDataGridButtons(url);
    };

    function loadServicesDataGrid(data) {
        console.log('load services data grid fired');
        var gridConfig = {
            search: true,
            pagination: {
                limit: 25
            },
            sort: true,
            autoWidth: false,
            resizable: false,
            width: '1400px',
            columns: [
                {
                    name: "Name",
                    width: '300px'
                },
                {
                    name: "Description",
                    width: '300px'
                },
                {
                    name: "Type",
                    width: '200px'
                },
                {
                    name: "Actions",
                    width: '125px'
                }
            ],
            data: () => {
                if (data === undefined || data === null) {
                    return [];
                };

                var jsonData = data;

                var jsonFormatted = jsonData.map(item => [
                    item.name,
                    item.description,
                    item.type
                ]);

                return jsonFormatted;
            }
        };

        if (grid === undefined) {
            console.log('spinning up new grid');
            grid = $("#mainDataTable").empty().Grid(gridConfig);
        }
        else {
            console.log('rendering updated grid');
            grid.updateConfig(gridConfig).forceRender();
        }

        grid.on('ready', () => addRowButtons("Administration/Services/Index?handler=Service"));
    };

    function loadServiceTypesDataGrid(data) {
        console.log('load service types data grid fired');

        var gridConfig = {
            search: true,
            pagination: {
                limit: 25
            },
            sort: true,
            autoWidth: false,
            resizable: false,
            width: '700px',
            columns: [
                {
                    name: "Name",
                    width: '400px'
                },
                {
                    name: "Actions",
                    width: '125px'
                }
            ],
            data: () => {
                if (data === undefined || data === null) {
                    return [];
                };

                var jsonData = data;

                var jsonFormatted = jsonData.map(item => [
                    item.name
                ]);

                return jsonFormatted;
            }
        };

        if (grid === undefined) {
            console.log('spinning up new grid');
            grid = $("#mainDataTable").empty().Grid(gridConfig);
        }
        else {
            console.log('rendering updated grid');
            grid.updateConfig(gridConfig).forceRender();
        }

        grid.on('ready', () => addRowButtons("Administration/ServiceTypes/Index?handler=ServiceType"));
    };

    function buttonSpinnerHtml() {
        return `<span class="spinner-border spinner-border-sm me-2" role="status"></span><span class="sr-only">Loading...</span>`;
    }

    function refreshGrid(element, allowSpinner) {
        //expect the url to call to be based on the id of the reload grid button parent element
        var target = element.parent().attr('id');
        var url = `Administration/${subpage}/Index?handler=${target}`;
        $(element).attr('disabled', true);
        var buttonHtml = $(element).html();

        if (allowSpinner !== undefined || allowSpinner !== null) {
            var replaceHtml = buttonSpinnerHtml();
            $(element).html(replaceHtml);
        }

        $.ajax({
            type: 'GET',
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                if (allowSpinner !== undefined || allowSpinner !== null) {
                    $(element).html(buttonHtml);
                };

                $(element).attr('disabled', false);

                if (data.dataList === undefined) {
                    console.log('no data returned from refresh call');
                    return;
                }

                var method = `load${subpage}DataGrid`;
                window.Stratosphere[method](data.dataList);
            },
            error: function (xhr, status, error) {
                if (allowSpinner !== undefined || allowSpinner !== null) {
                    $(element).html(buttonHtml);
                };

                $(element).attr('disabled', false);

                console.error(xhr.responseText);
            }
        });
    };

    function init() {
        bindAdminSections();
    };

    init();

})(window.jQuery);