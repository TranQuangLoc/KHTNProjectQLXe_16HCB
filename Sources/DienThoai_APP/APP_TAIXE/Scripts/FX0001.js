var app = angular.module('myApp', []);

app.controller('myCtrl', function ($scope, $interval) {
    $scope.manv = sessionStorage.manv;
    $scope.tennv = sessionStorage.tennv;
    $scope.thongtinxe = sessionStorage.xe;
    $scope.trangthai = sessionStorage.mota;
    $scope.lat = sessionStorage.lat;
    $scope.lng = sessionStorage.lng;
    $scope.id_xe = sessionStorage.idXe;

    $scope.SDT = 'Không có thông tin';
    $scope.DC = 'Không có thông tin';

    $scope.f_setPoints = function (sdt, dc) {
        $scope.SDT = sdt;
        $scope.DC = dc;
    }
})