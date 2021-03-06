$(function () {
    var l = abp.localization.getResource("AbpMvc");
	
	var bookService = window.abpMvc.books.books;
	
        var lastNpIdId = '';
        var lastNpDisplayNameId = '';

        var _lookupModal = new abp.ModalManager({
            viewUrl: abp.appPath + "Shared/LookupModal",
            scriptUrl: "/Pages/Shared/lookupModal.js",
            modalClass: "navigationPropertyLookup"
        });

        $('.lookupCleanButton').on('click', '', function () {
            $(this).parent().parent().find('input').val('');
        });

        _lookupModal.onClose(function () {
            var modal = $(_lookupModal.getModal());
            $('#' + lastNpIdId).val(modal.find('#CurrentLookupId').val());
            $('#' + lastNpDisplayNameId).val(modal.find('#CurrentLookupDisplayName').val());
        });
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Books/CreateModal",
        scriptUrl: "/Pages/Books/createModal.js",
        modalClass: "bookCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Books/EditModal",
        scriptUrl: "/Pages/Books/editModal.js",
        modalClass: "bookEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val(),
			typeMin: $("#TypeFilterMin").val(),
			typeMax: $("#TypeFilterMax").val(),
			publishDateMin: $("#PublishDateFilterMin").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			publishDateMax: $("#PublishDateFilterMax").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			priceMin: $("#PriceFilterMin").val(),
			priceMax: $("#PriceFilterMax").val(),
			authorId: $("#AuthorIdFilter").val()
        };
    };

    var dataTable = $("#BooksTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(bookService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('AbpMvc.Books.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.book.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('AbpMvc.Books.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    bookService.delete(data.record.book.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "book.name" },
			{ data: "book.type" },
            {
                data: "book.publishDate",
                render: function (publishDate) {
                    if (!publishDate) {
                        return "";
                    }
                    
					var date = Date.parse(publishDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "book.price" },
            {
                data: "author.name",
                defaultContent : ""
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewBookButton").click(function (e) {
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
