angular.module("starter.services", [])
    .service("indexService", [
        "$http", "$q", function($http, $q) {
            //获取list
            this.getEmployeeInstitutions = function() {
                var deferred = $q.defer(); //申明deferred对象
                $http({
                    method: "get",
                    url: "/api/EmployeeInstitution"
                }).success(function(data) {
                    deferred.resolve(data); // 声明执行成功，即http请求数据成功，可以返回数据了
                }).error(function() {
                    deferred.reject("There was an error");
                });
                return deferred.promise; // 返回承诺，这里并不是最终数据，而是访问最终数据的API
            }
        }
    ]);
