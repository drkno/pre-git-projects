const app = angular.module("upcomingApp", []);
app.controller("upcomingCtrl", function($scope, $http) {
	$scope.data = [];
	$http.get('http://makereti.co.nz/tests/api.php').then(resp => {
		$scope.data = resp.data;
	});

	$scope.getBanner = ep => {
		const img = ep.series.images.find(i => i.coverType === 'banner');
		return img ? img.url : '';
	};

	$scope.pad = num => {
		let nums = num.toString();
		if (nums.length === 1) {
			nums = '0' + nums;
		}
		return nums;
	};
});
