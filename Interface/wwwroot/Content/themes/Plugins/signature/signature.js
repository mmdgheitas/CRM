(function (ns) {
    "use strict";

    ns.SignatureControl = function (options) {
        var containerId = options && options.canvasId || "container",
            callback = options && options.callback || {},
            label = options && options.label || "Signature",
            cWidth = options && options.width || "300px",
            cHeight = options && options.height || "300px",
            btnClearId,
            btnAcceptId,
            canvas,
            ctx;
        
        function initCotnrol() {
            createControlElements();
            wireButtonEvents();
            canvas = document.getElementById("signatureCanvas");
            canvas.addEventListener("mousedown", pointerDown, false);
            canvas.addEventListener("mouseup", pointerUp, false);
            ctx = canvas.getContext("2d");
            alert("initCotnrol");
        }

        function createControlElements() {            
            var signatureArea = document.createElement("div"),
                labelDiv = document.createElement("div"),
                canvasDiv = document.createElement("div"),
                canvasElement = document.createElement("canvas"),
                buttonsContainer = document.createElement("div"),
                buttonClear = document.createElement("div"),
                buttonAccept = document.createElement("div");

            labelDiv.className = "signatureLabel";
            labelDiv.textContent = label;

            canvasElement.id = "signatureCanvas";
          //  canvasElement.clientWidth = cWidth;
          //  canvasElement.clientHeight = cHeight;
            canvasElement.style.border = "solid 2px black";

            buttonClear.id = "btnClear";
            buttonClear.textContent = "Clear";

            buttonAccept.id = "btnAccept";
            buttonAccept.textContent = "Accept";

            canvasDiv.appendChild(canvasElement);
            buttonsContainer.appendChild(buttonClear);
            buttonsContainer.appendChild(buttonAccept);

            signatureArea.className = "signatureArea";
            signatureArea.appendChild(labelDiv);
            signatureArea.appendChild(canvasDiv);
            signatureArea.appendChild(buttonsContainer);

            document.getElementById(containerId).appendChild(signatureArea);
        }

        function pointerDown(evt) {
            ctx.beginPath();
            ctx.moveTo(evt.offsetX, evt.offsetY);
            canvas.addEventListener("mousemove", paint, false);

            canvas.addEventListener("touchend", function (e) {
                var mouseEvent = new MouseEvent("mouseup", {});
                canvas.dispatchEvent(mouseEvent);
            }, false);
            canvas.addEventListener("touchmove", function (e) {
                var touch = e.touches[0];
                var mouseEvent = new MouseEvent("mousemove", {
                    clientX: touch.clientX,
                    clientY: touch.clientY
                });
                canvas.dispatchEvent(mouseEvent);
            }, false);


         //   alert("mousemove/Down");
        }

        function pointerUp(evt) {
            canvas.removeEventListener("mousemove", paint);
            paint(evt);
          
        }

        function paint(evt) {
            ctx.lineTo(evt.offsetX, evt.offsetY);
            ctx.stroke();
        }

        function wireButtonEvents() {
            var btnClear = document.getElementById("btnClear"),
                btnAccept = document.getElementById("btnAccept");
            btnClear.addEventListener("click", function () {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                sign = false;
            }, false);
            btnAccept.addEventListener("click", function () {
                callback();
            }, false);
        }
        
        function getSignatureImage() {
            var image = canvas.toDataURL("image/png");
            image = image.replace('data:image/png;base64,', '');
            return image;
            //return ctx.getImageData(0, 0, canvas.width, canvas.height).data;
        }

        return {
            init: initCotnrol,
            getSignatureImage: getSignatureImage
        };
    }
})(this.ns = this.ns || {});
