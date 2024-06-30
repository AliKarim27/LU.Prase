(function ($) {
    var _departementService = abp.services.app.departement,
        l = abp.localization.getSource('Prase'),
        _$modal = $('#DepartementEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var departement = _$form.serializeFormToObject();
        departement.Responsibles = [];
        var _$responsibleSelected = $('#Responsibles-Edit').find('option:selected');
        if (_$responsibleSelected) {
            for (var responsibleIndex = 0; responsibleIndex < _$responsibleSelected.length; responsibleIndex++) {
                var responsible = $(_$responsibleSelected[responsibleIndex]);
                departement.Responsibles.push({ id: responsible.val() });
            }
        }
        console.log(departement.Responsibles)

        abp.ui.setBusy(_$form);
        _departementService.update(departement).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('departement.edited', departement);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
