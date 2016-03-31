function DisplayImage(inputFile, imageTagName, width, height) {
    if (inputFile.files && inputFile.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(imageTagName).attr('src', e.target.result)
                           .width(width)
                           .height(height);
        };

        reader.readAsDataURL(inputFile.files[0]);
    }
}