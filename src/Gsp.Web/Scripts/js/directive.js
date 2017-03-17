angular.module("starter.directives", [])
.directive("searchInput", ["$parse", function ($parse) {
    return {
        link: function (scope, element, attrs) {
            var model = $parse(attrs.searchInput);
            scope.$watch(model, function (value) {
                //console.log("value=", value);
                if (value === true) {
                    element[0].focus();
                }
            });
            element.bind("blur", function() {
                //console.log("blur")                
                //scope.$apply(model.assign(scope, false));
            });
        }
    };
}]);