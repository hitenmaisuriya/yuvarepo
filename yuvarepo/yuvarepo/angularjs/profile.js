var app = angular.module('yuva', []);


app.controller('field', function ($scope, $http) {


   
    $scope.sectore = "";
    $scope.vk = "";
    $scope.grp = "";
    $scope.vk_list = [];
    $scope.grp_list = [];
    
    $http.get("http://localhost:9130/field/all_fields")
  .then(function (response) {
      $scope.field = response.data;
     
      $scope.fill_vk = function fill_vk() {
          for (var i = 0; i < $scope.field.length; i++) {
              
              if ($scope.field[i]["name"] == $scope.sectore) {
                
                  document.getElementById('ddl_vk').style.visibility = "visible";
                  $scope.vk_list = $scope.field[i]["vk_list"];
                  
              }

          }
      }

      $scope.fill_grp = function fill_grp() {
          for (var i = 0; i < $scope.vk_list.length; i++) {

              if ($scope.vk_list[i]["name"] == $scope.vk) {
                  
                  document.getElementById('ddl_grp').style.visibility = "visible";
                  $scope.grp_list = $scope.vk_list[i]["grp_list"];

              }

          }
      }
      $scope.fill_yk = function fill_yk() {
          for (var i = 0; i < $scope.grp_list.length; i++) {

              if ($scope.grp_list[i]["name"] == $scope.grp) {

                  document.getElementById('ddl_yk').style.visibility = "visible";
                  $scope.yk_list = $scope.grp_list[i]["yk_list"];

              }

          }
      }

      
  });
});