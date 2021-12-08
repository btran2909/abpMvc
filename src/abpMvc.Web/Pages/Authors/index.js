$(function () {
    var l = abp.localization.getResource("AbpMvc");
	
	var authorService = window.abpMvc.authors.authors;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Authors/CreateModal",
        scriptUrl: "/Pages/Authors/createModal.js",
        modalClass: "authorCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Authors/EditModal",
        scriptUrl: "/Pages/Authors/editModal.js",
        modalClass: "authorEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val(),
			birthDateMin: $("#BirthDateFilterMin").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			birthDateMax: $("#BirthDateFilterMax").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			shortBio: $("#ShortBioFilter").val()
        };
    };

    var dataTable = $("#AuthorsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(authorService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('AbpMvc.Authors.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('AbpMvc.Authors.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    authorService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" },
            {
                data: "birthDate",
                render: function (birthDate) {
                    if (!birthDate) {
                        return "";
                    }
                    
					var date = Date.parse(birthDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "shortBio" }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewAuthorButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});
