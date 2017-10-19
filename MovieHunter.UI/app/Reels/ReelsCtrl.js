(function () {
    "use strict";

    angular
        .module("Reels")
        .controller("ReelsCtrl",
                    ["$scope",
                     "$http",
                        ReelsCtrl]);

    function ReelsCtrl($scope, $http) {

        $scope.clips = [];

        $scope.myReel = [];

        $scope.myReelName = '';
        $scope.isEditing = true;

        $scope.myReelDefinition = null;
        $scope.myReelStandard = null;
        $scope.myReelCurrentFrameRate = null;
        
        $scope.updateReel = function(clip) {
            if (!clip.isSelected) {
                clip.isSelected = true;
                //clip.isDisabled = true;
                $scope.myReel.push(clip);
            } else {
                clip.isSelected = false;
                //clip.isDisabled = false;
                let index = $scope.myReel.indexOf(clip);
                $scope.myReel.splice(index, 1);
            }

            let firstClip = $scope.myReel[0];
            if (firstClip) {
                $scope.myReelDefinition = firstClip.Definition;
                $scope.myReelStandard = firstClip.Standard;
                $scope.myReelCurrentFrameRate = firstClip.TimeCode.FrameRate;

                $scope.clips.forEach(function(r) {
                    if (r.Definition != firstClip.Definition)
                        r.isDisabled = true;
                    if (r.Standard != firstClip.Standard)
                        r.isDisabled = true;
                });
            } else {
                $scope.myReelDefinition = null;
                $scope.myReelStandard = null;
                $scope.myReelCurrentFrameRate = null;

                $scope.clips.forEach(function (r) {
                    r.isDisabled = false;
                });
            }

        };

        $scope.myReelTimeCode = function () {
            var that = this;
            if ($scope.myReel.length == 0) {
                return '00:00:00:00';
            } else {
                let total = 0;
                $scope.myReel.forEach(function (clip) {
                    total += clip.TimeCode.TotalFrames;
                });

                //return total.toString();
                return displayTimeCode(total, $scope.myReelCurrentFrameRate);
            }
        }

        function displayTimeCode(totalFrames, frameRate) {
            let framesPerSecond = frameRate;
            let framesPerDay = framesPerSecond * 60 * 60 * 24;

            let Frames = Math.floor(totalFrames % frameRate);
            let Seconds = Math.floor(totalFrames / frameRate % 60);
            let Minutes = Math.floor(totalFrames / frameRate / 60 % 60);
            let Hours = Math.floor(totalFrames / frameRate / 60 / 60);

            return `${padDigits(Hours, 2)}:${padDigits(Minutes, 2)}:${padDigits(Seconds, 2)}:${padDigits(Frames, 2)}`;
        }

        function padDigits(number, digits) {
            return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
        }

        var onMovieRetrieveComplete = function (response) {
            $scope.clips = response.data;
        };

        var onError = function (reason) {
            $scope.errorText = "Could not display the movie list: " +
                        (reason.statusText ? reason.statusText : reason.description);
        };

        $http.get("http://localhost:1561/api/reels/")
            .then(onMovieRetrieveComplete, onError);
    }
}());