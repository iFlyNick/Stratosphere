(function ($) {
    "use strict";

    //helper to handle grids across multiple areas. should help keep this to one grid at a time
    let grid;

    //namespace registration for global access
    window.Stratosphere = window.Stratosphere || {};

    //namespace public methods to be called from admin child pages
    window.Stratosphere.loadServiceTypeDataGrid = loadServiceTypeDataGrid;

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

    function adminSectionButtonBinding() {
        addNewServiceListener();
        addOffcanvasHelpers();
    };

    function addNewServiceListener() {
        $('#newServiceTypeSubmit').on('click', function () {
            var serviceTypeName = $('#serviceTypeModalName').val();

            var formData = {
                name: serviceTypeName
            };

            handleNewServiceTypeSubmit(formData);
        });
    };

    function addOffcanvasHelpers() {
        $('#adminCanvas').on('hide.bs.offcanvas', function () {
            $(this).addClass('d-none');
        });

        $('#adminCanvas').on('shown.bs.offcanvas', function () {
            $(this).removeClass('d-none').css("style", "");
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
                successAlert();
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    };

    function successAlert() {
        $('.adminHeaderRow').after('<div class="alert alert-success alert-dismissible fade show" role="alert">Service Type Added Successfully<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>');
    };

    function bindDataGridButtons() {
        $('td[data-column-id="actions"] button.btn-primary').on('click', function () {
            var element = $(this);
            var redirectUrl = '?name=' + $(element).closest('tr').find('td[data-column-id="name"]').text();
        });
    };

    function addRowButtons() {
        var tableRows = $('td[data-column-id="actions"]');

        for (let r = 0; r < tableRows.length; r++) {
            var activeRow = $(tableRows[r]);
            var rowName = $(activeRow).siblings('td[data-column-id="name"]').text();

            var buttonRowHtml = `<div class="d-flex justify-content-around"><button type="button" class="btn btn-primary"><i class="bi bi-pencil-fill"></i></button><button type="button" class="btn btn-secondary"><i class="bi bi-trash3"></i></button></div>`;

            $(activeRow).html(buttonRowHtml);
        };

        bindDataGridButtons();
    };

    function loadServiceTypeDataGrid(data) {
        console.log('loading service type data grid');

        grid = $("#mainDataTable").empty().Grid({
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
                var jsonData = data;

                var jsonFormatted = jsonData.map(item => [
                    item.name
                ]);

                return jsonFormatted;
            }
        });

        grid.on('ready', () => addRowButtons());
    };

    function init() {
        bindAdminSections();
    };

    init();
})(window.jQuery);