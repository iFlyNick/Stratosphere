//async function buildGrid(data) {
//    let grid;

//    async function loadDataGrid() {
//        grid = $("#mainDataTable").empty().Grid({
//            search: true,
//            pagination: {
//                limit: 25
//            },
//            sort: true,
//            autoWidth: false,
//            resizable: false,
//            width: '700px',
//            columns: [
//                {
//                    name: "Name",
//                    width: '400px'
//                },
//                {
//                    name: "Actions",
//                    width: '125px'
//                }
//            ],
//            data: () => {
//                var jsonData = data;

//                var jsonFormatted = jsonData.map(item => [
//                    item.name
//                ]);

//                return jsonFormatted;
//            }
//        });
//    }

//    function addRowButtons() {
//        var tableRows = $('td[data-column-id="actions"]');

//        for (let r = 0; r < tableRows.length; r++) {
//            var activeRow = $(tableRows[r]);
//            var rowName = $(activeRow).siblings('td[data-column-id="name"]').text();

//            var buttonRowHtml = `<div class="d-flex justify-content-around"><button type="button" class="btn btn-primary"><i class="bi bi-pencil-fill"></i></button><button type="button" class="btn btn-secondary"><i class="bi bi-trash3"></i></button></div>`;

//            $(activeRow).html(buttonRowHtml);
//        }

//        bindAlerts();
//    }

//    function bindAlerts() {
//        $('td[data-column-id="actions"] button.btn-primary').on('click', function () {
//            var element = $(this);
//            var redirectUrl = '?name=' + $(element).closest('tr').find('td[data-column-id="name"]').text();
//            alert(`Redirecting to: ${redirectUrl}`);
//        });
//    }

//    async function setupDataGrid() {
//        await loadDataGrid();
//        //calling this without the event leads to the grid data still being loaded so no records are found
//        grid.on('ready', () => addRowButtons());
//    }

//    await setupDataGrid();
//}