
(function ($) {
    var _sectionService = abp.services.app.section,
        l = abp.localization.getSource('Prase'),
        _$modal = $('#SectionCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#SectionsTable');


    var hasPermissionEdit = abp.auth.isGranted('Pages.Sections.Edit');
    var hasPermissionDelete = abp.auth.isGranted('Pages.Sections.Delete');
    var _$sectionsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _sectionService.getAll,
            //inputFilter: function () {
            //    return $('#RolesSearchForm').serializeFormToObject(true);
            //}
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$sectionsTable.draw(false)
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
                data: 'departement.name',
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
                            `   <button type="button" class="btn btn-sm bg-secondary edit-section" data-section-id="${row.id}" data-toggle="modal" data-target="#SectionEditModal">` : '',
                        hasPermissionEdit ? `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}` : '',
                        hasPermissionEdit ? '   </button>' : '',
                        hasPermissionDelete ? `   <button type="button" class="btn btn-sm bg-danger delete-section" data-section-id="${row.id}" data-section-name="${row.name}">` : '',
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
        var section = _$form.serializeFormToObject();
        section.Responsibles = [];
        var _$responsibleSelected = $('#Responsibles').find('option:selected');
        if (_$responsibleSelected) {
            for (var responsibleIndex = 0; responsibleIndex < _$responsibleSelected.length; responsibleIndex++) {
                var responsible = $(_$responsibleSelected[responsibleIndex]);
                section.Responsibles.push({id :responsible.val()});
            }
        }
        abp.ui.setBusy(_$modal);
        _sectionService
            .create(section)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$sectionsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-section', function () {
        var roleId = $(this).attr("data-section-id");
        var roleName = $(this).attr('data-section-name');
        deleteSection(roleId, roleName);
    });

    $(document).on('click', '.edit-section', function (e) {
        var sectionId = $(this).attr("data-section-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Sections/EditModal?sectionId=' + sectionId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#SectionEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('section.edited', (data) => {
        _$sectionsTable.ajax.reload();
    });

    function deleteSection(sectionId, sectionName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                sectionName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _sectionService.delete({
                        id: sectionId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$sectionsTable.ajax.reload();
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
        _sectionService.getDepartements().done((departements) => {
            departements.forEach((departement) => {
                console.log(departement);
                addItemToSelect('DepartementId', departement.name, departement.id);
            });
        })
        _sectionService.getAllResponsibles().done((responsibles) => {
            responsibles.forEach((responsible) => {
                console.log(responsible);
                addItemToSelect('Responsibles', responsible.userName, responsible.id);
            });
        })
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    //$('.btn-search').on('click', (e) => {
    //    _$sectionsTable.ajax.reload();
    //});

    //$('.txt-search').on('keypress', (e) => {
    //    if (e.which == 13) {
    //        _$rolesTable.ajax.reload();
    //        return false;
    //    }
    //});
})(jQuery);
