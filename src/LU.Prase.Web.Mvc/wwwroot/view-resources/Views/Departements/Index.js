
(function ($) {
    var _departementService = abp.services.app.departement,
        l = abp.localization.getSource('Prase'),
        _$modal = $('#DepartementCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#DepartementsTable');


    var hasPermissionEdit = abp.auth.isGranted('Pages.Departements.Edit');
    var hasPermissionDelete = abp.auth.isGranted('Pages.Departements.Delete');
    var _$departementsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _departementService.getAll,
            //inputFilter: function () {
            //    return $('#RolesSearchForm').serializeFormToObject(true);
            //}
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$departementsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'address',
                sortable: false
            },
            {
                targets: 4,
                sortable: false,
                render: function (data, type, row, meta) {
                    let ul = [`<ul>`];
                    row.responsibles.forEach((responsible) => {
                        ul.push(`<li>${responsible.userName}</li>`);
                    });
                    ul.push(`</ul>`);
                    return ul.join("");
                }
            },
            (hasPermissionEdit || hasPermissionDelete) ?
                {
                    targets: 5,
                    data: null,
                    sortable: false,
                    autoWidth: false,
                    defaultContent: '',
                    render: (data, type, row, meta) => {
                        return [hasPermissionEdit ?
                            `   <button type="button" class="btn btn-sm bg-secondary edit-departement" data-departement-id="${row.id}" data-toggle="modal" data-target="#DepartementEditModal">` : '',
                        hasPermissionEdit ? `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}` : '',
                        hasPermissionEdit ? '   </button>' : '',
                        hasPermissionDelete ? `   <button type="button" class="btn btn-sm bg-danger delete-departement" data-departement-id="${row.id}" data-departement-name="${row.name}">` : '',
                        hasPermissionDelete ? `       <i class="fas fa-trash"></i> ${l('Delete')}` : '',
                        hasPermissionDelete ? '   </button>' : '',
                        ].join('');
                    }
                } : {}
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        if (!_$form.valid()) {
            return;
        }
        var departement = _$form.serializeFormToObject();
        departement.Responsibles = [];
        var _$responsibleSelected = $('#Responsibles').find('option:selected');
        if (_$responsibleSelected) {
            for (var responsibleIndex = 0; responsibleIndex < _$responsibleSelected.length; responsibleIndex++) {
                var responsible = $(_$responsibleSelected[responsibleIndex]);
                departement.Responsibles.push({id :responsible.val()});
            }
        }
        abp.ui.setBusy(_$modal);
        _departementService
            .create(departement)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$departementsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-departement', function () {
        var roleId = $(this).attr("data-departement-id");
        var roleName = $(this).attr('data-departement-name');
        deleteDepartement(roleId, roleName);
    });

    $(document).on('click', '.edit-departement', function (e) {
        var departementId = $(this).attr("data-departement-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Departements/EditModal?departementId=' + departementId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#DepartementEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('departement.edited', (data) => {
        _$departementsTable.ajax.reload();
    });

    function deleteDepartement(departementId, departementName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                departementName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _departementService.delete({
                        id: departementId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$departementsTable.ajax.reload();
                    });
                }
            }
        );
    }
    function addItemToSelect(selectId, itemText, itemValue) {
        // Get the select element by its ID and empty it
        var $selectElement = $('#' + selectId);

        // Create a new option element
        var $newOption = $('<option></option>')
            .text(itemText)
            .val(itemValue);

        // Add the new option to the select element
        $selectElement.append($newOption);
    }
    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
        _departementService.getAllResponsibles().done((responsibles) => {
            responsibles.forEach((responsible) => {
                console.log(responsible);
                addItemToSelect('Responsibles', responsible.userName, responsible.id);
            });
        })
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    //$('.btn-search').on('click', (e) => {
    //    _$departementsTable.ajax.reload();
    //});

    //$('.txt-search').on('keypress', (e) => {
    //    if (e.which == 13) {
    //        _$rolesTable.ajax.reload();
    //        return false;
    //    }
    //});
})(jQuery);
