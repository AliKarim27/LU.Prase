(function ($) {
    var _machineService = abp.services.app.machine,
        l = abp.localization.getSource('Prase'),
        _$modal = $('#MachineCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#MachinesTable');


    var hasPermissionEdit = abp.auth.isGranted('Pages.Machines.Edit');
    var hasPermissionDelete = abp.auth.isGranted('Pages.Machines.Delete');
    var _$machinesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _machineService.getAll,
           
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$machinesTable.draw(false)
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
                data: 'notes',
                sortable: false
            },
            {
                targets: 3,
                data: 'section.name',
                sortable: false
            },
            {
                targets: 4,
                data: 'machineStates',
                sortable: false
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
                            `   <button type="button" class="btn btn-sm bg-secondary edit-machine" data-machine-id="${row.id}" data-toggle="modal" data-target="#MachineEditModal">` : '',
                        hasPermissionEdit ? `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}` : '',
                        hasPermissionEdit ? '   </button>' : '',
                        hasPermissionDelete ? `   <button type="button" class="btn btn-sm bg-danger delete-machine" data-machine-id="${row.id}" data-machine-name="${row.name}">` : '',
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
        var machine = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _machineService
            .create(machine)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$machinesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-machine', function () {
        var roleId = $(this).attr("data-machine-id");
        var roleName = $(this).attr('data-machine-name');
        deleteMachine(roleId, roleName);
    });

    $(document).on('click', '.edit-machine', function (e) {
        var machineId = $(this).attr("data-machine-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Machines/EditModal?machineId=' + machineId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#MachineEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('machine.edited', (data) => {
        _$machinesTable.ajax.reload();
    });

    function deleteMachine(machineId, machineName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                machineName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _machineService.delete({
                        id: machineId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$machinesTable.ajax.reload();
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
        $('#SectionId').empty();
        _machineService.getSections().done((sections) => {
            sections.forEach((section) => {
                console.log(section);
                addItemToSelect('SectionId', section.name, section.id);
            });
        })
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    //$('.btn-search').on('click', (e) => {
    //    _$machinesTable.ajax.reload();
    //});

    //$('.txt-search').on('keypress', (e) => {
    //    if (e.which == 13) {
    //        _$rolesTable.ajax.reload();
    //        return false;
    //    }
    //});
})(jQuery);
