angular.module('platformWebApp').controller('platformWebApp.newAccountWizardController',
    ['$scope', 'platformWebApp.bladeNavigationService', 'platformWebApp.accounts', 'platformWebApp.roles', 'platformWebApp.passwordValidationService', 'platformWebApp.settings',
        function ($scope, bladeNavigationService, accounts, roles, passwordValidationService, settings) {
            var blade = $scope.blade;
            blade.headIcon = 'fas fa-key';

            var promise = roles.search({ takeCount: 10000 }).$promise;

            function initializeBlade(data) {
                promise.then(function (promiseData) {
                    blade.isLoading = false;
                    blade.currentEntities = promiseData.results;
                });

                // Load default account status
                settings.get({ id: 'VirtoCommerce.Platform.Security.DefaultAccountStatus' }, function (setting) {
                    blade.currentEntity.status = setting.defaultValue;
                });

                // Load default account type
                settings.get({ id: 'VirtoCommerce.Platform.Security.AccountTypes' }, function (setting) {
                    blade.currentEntity.userType = setting.defaultValue;
                });
            }

            blade.selectNode = function (node) {
                $scope.selectedNodeId = node.id;

                var newBlade = {
                    id: 'roleDetails',
                    data: node,
                    title: node.name,
                    subtitle: 'platform.blades.role-detail.subtitle',
                    controller: 'platformWebApp.roleDetailController',
                    template: '$(Platform)/Scripts/app/security/blades/role-detail.tpl.html'
                };

                bladeNavigationService.showBlade(newBlade, blade);
            };

            $scope.validatePasswordAsync = function (value) {
                return passwordValidationService.validateUserPasswordAsync(blade.currentEntity.userName, value);
            }

            $scope.saveChanges = function () {
                if (blade.currentEntity.password !== blade.currentEntity.newPassword2) {
                    blade.error = 'Error: passwords don\'t match!';
                    return;
                }

                blade.isLoading = true;
                blade.error = undefined;
                var postData = angular.copy(blade.currentEntity);
                postData.newPassword2 = undefined;
                postData.roles = _.where(blade.currentEntities, { $selected: true });

                accounts.save(postData, function (result) {
                    if (result.succeeded) {
                        blade.parentBlade.refresh();
                        blade.parentBlade.selectNode(postData);
                    }
                    else {
                        bladeNavigationService.setError(result.errors.join(), blade);
                    }
                });
            };

            // actions on load
            initializeBlade(blade.currentEntity);
        }]);
