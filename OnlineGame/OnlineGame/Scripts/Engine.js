function Core(map) {
    this.CurrentState = "";
    this.States = { Start: "Start", End: "End", Paused: "Paused", Movement: "Movement", Combat: "Combat", Sleep: "Sleep" };
    this.Canvas = this.InitCanvas();
    this.Map = this.InitMap(map);
    this.InitStartState();
}

Core.prototype.InitStartState = function () {
    var currentState = this.States.Start;
    this.SetCurrentState(currentState);
};

Core.prototype.InitCanvas = function () {
    var canvas = oCanvas.create(
            {
                canvas: "#canvas",
                background: "#FF0000"
            });
    canvas.height = 600;
    canvas.width = 1000;

    return canvas;
};

Core.prototype.InitMap = function (map) {
    var map = new Map(this.Canvas, map);
    return map;
};

Core.prototype.PauseCurrentState = function () {
    
};

Core.prototype.GetCurrentState = function () {
    return this.CurrentState;
};

Core.prototype.SetCurrentState = function (state) {
    this.CurrentState = state;
};
