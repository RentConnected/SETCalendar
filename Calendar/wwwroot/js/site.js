function share_fb(url, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    return window.open('https://www.facebook.com/sharer/sharer.php?u=' + url, 'facebook-share-dialog', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

function copyToClipboard(text) {
    if (window.clipboardData && window.clipboardData.setData) {
        // Internet Explorer-specific code path to prevent textarea being shown while dialog is visible.
        return clipboardData.setData("Text", text);
    }
    else if (document.queryCommandSupported && document.queryCommandSupported("copy")) {
        try {
            var textarea = document.createElement("textarea");
            textarea.textContent = text;
            textarea.style.position = "fixed";  // Prevent scrolling to bottom of page in Microsoft Edge.
            document.body.appendChild(textarea);

            $('.copylinkpopup').popover('show');

            textarea.select();
            textarea.focus();

            return document.execCommand("copy");  // Security exception may be thrown by some browsers.
        }
        catch (ex) {
            $('.copylinkpopup').popover('hide');
            console.warn("Copy to clipboard failed.", ex);
            return false;
        }
        finally {
            setTimeout(function () {
                $('.copylinkpopup').popover('hide');
            }, 2000);

            document.body.removeChild(textarea);

            if (document.selection) {
                document.selection.empty();
            }
            else if (window.getSelection) {
                window.getSelection().removeAllRanges();
            }
        }
    }
}


var image = document.createElement('img');
image.src = getBgUrl(document.getElementById('cover'));
image.onload = function () {
    coverLoaded();
};

function getBgUrl(el) {
    var bg = "";
    if (el.currentStyle) { // IE
        bg = el.currentStyle.backgroundImage;
    } else if (document.defaultView && document.defaultView.getComputedStyle) { // Firefox
        bg = document.defaultView.getComputedStyle(el, "").backgroundImage;
    } else { // try and get inline style
        bg = el.style.backgroundImage;
    }
    return bg.replace(/url\(['"]?(.*?)['"]?\)/i, "$1");
}

function coverLoaded() {
    document.getElementById("navdialog").style.display = "block";
} 
