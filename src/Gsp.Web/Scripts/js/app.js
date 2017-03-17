angular.module("starter", ["ui.router", "oc.lazyLoad", "ngAnimate", "starter.services", "starter.directives", "starter.controllers"])
    .config([
        "$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state("app", {
                    url: "/",
                    views: {
                        "header": {
                            templateUrl: "/templates/partials/header.html",
                            controller: "HeaderCtrl"
                        },
                        "leftside": {
                            templateUrl: "/templates/partials/leftside.html",
                            controller: "LeftSideCtrl"
                        },
                        "content": {
                            templateUrl: "/templates/partials/content.html",
                            controller: "ContentCtrl"
                        },
                        "footer": {
                            templateUrl: "/templates/partials/footer.html",
                            controller: "FooterCtrl"

                        },
                        "controlsidebar": {
                            templateUrl: "/templates/partials/controlsidebar.html",
                            controller: "ControlSidebarCtrl",
                            //resolve: {
                            //    store: function($ocLazyLoad) {
                            //        return $ocLazyLoad.load(
                            //            {
                            //                name: "ControlSidebarCtrl",
                            //                files: [
                            //                    "AdminLTE/plugins/jQuery/jquery-2.2.3.min.js",
                            //                    "Scripts/bootstrap.min.js",
                            //                    "AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js",
                            //                    "AdminLTE/plugins/fastclick/fastclick.js",
                            //                    "AdminLTE/dist/js/app.min.js",
                            //                    "AdminLTE/dist/js/demo.js"
                            //                ]
                            //            }
                            //        );
                            //    }
                            //}
                        }

                    },
                    //resolve: {
                    //    ControlSidebarCtrl: [
                    //        "$ocLazyLoad", function($ocLazyLoad) {
                    //            return $ocLazyLoad.load("AdminLTE/plugins/jQuery/jquery-2.2.3.min.js").then(
                    //                function() {
                    //                    $ocLazyLoad.load("Scripts/bootstrap.min.js").then(function() {
                    //                        $ocLazyLoad.load("AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js").then(
                    //                            function() {
                    //                                $ocLazyLoad.load("AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js").then(function () {
                    //                                    $ocLazyLoad.load("AdminLTE/dist/js/app.min.js").then(function() {
                    //                                        $ocLazyLoad.load("AdminLTE/dist/js/demo.js");
                    //                                    });

                    //                                });
                    //                            }
                    //                        );
                    //                    });
                    //                }
                    //            );
                    //        }
                    //    ]
                    //}
                });
            // if none of the above states are matched, use this as the fallback
            $urlRouterProvider.otherwise("/");
        }
    ]);


