function ColorSearchFilterText(keyword,className) {
    var options = {
        "accuracy": {
            "value": "partially",
            "limiters": [",", "."]
        }
    };
    $("." + className).unmark({
        done: function () {
            $("." + className).mark(keyword, options);
        }
    });
}