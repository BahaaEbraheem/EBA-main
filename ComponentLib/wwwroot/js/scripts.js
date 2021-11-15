
/********************************************/
/************** Select 2*********************/

function Select2(selector, label = "") {

    $(selector).select2({
        placeholder: label,
        allowClear: true,
        width: 'resolve'
    });

}

function Select2OnChange(selector, dotnetHelper, funcName) {

    $(selector).on('select2:select', function (e) {
        dotnetHelper.invokeMethodAsync(funcName, $(selector).val());
    });

    $(selector).on("select2:clear", function (e) {
        dotnetHelper.invokeMethodAsync(funcName, "");
    });

}


/************** Select 2*********************/
/********************************************/

/************************************************/
/************** Sweet Alert *********************/

function Toast(message, icon = "success", ms = 3000) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: ms,
        //timerProgressBar: true,
        //didOpen: (toast) => {
        //    toast.addEventListener('mouseenter', Swal.stopTimer)
        //    toast.addEventListener('mouseleave', Swal.resumeTimer)
        //}
    })

    Toast.fire({
        icon: icon,
        title: message
    })
}

function Alert(msg, title = "", icon = "success", footer = "") {
    Swal.fire({
        icon: icon,
        title: title,
        text: msg,
        footer: footer
    })
}

/******************** Modal ********************************/
/***********************************************************/

function Modal(id, operation) {
    $("#" + id).modal(operation);
}


/******************* Fake *******************************/
/********************************************************/

//function SetFocusTo() {

//}


/***********************  Animated Tabs  *********************************/
/*************************************************************************/



var startAnimation = function ($panelContainer) {

	// Set .animating class (which triggers the CSS to start the animation)
	$panelContainer.addClass('animating');

};

var updatePanelNav = function ($panelNav, $panelContainer, $panelToSlideIn, numPanels) {

	// Find index of $panelToSlideIn in the $panelContainer
	var idx = $panelToSlideIn.index('#' + $panelContainer.attr('id') + ' > .panel');

	if (idx === 0) {
		$panelNav.find('a[href="#prev"]').addClass('inactive');
	} else {
		$panelNav.find('a[href="#prev"]').removeClass('inactive');
	}

	if (idx == numPanels - 1) {
		$panelNav.find('a[href="#next"]').addClass('inactive');
	} else {
		$panelNav.find('a[href="#next"]').removeClass('inactive');
	}

};

var stopAnimation = function ($panelContainer, $panels, $panelToSlideIn) {

	// Fix for browsers who fire this handler for both prefixed and unprefixed events (looking at you, Chrome): remove any listeners
	$panelToSlideIn.off('transitionend webkitTransitionEnd	MSTransitionEnd');

	// An optional extra class (or set of classes) that might be set on the panels
	var extraClass = $panelContainer.data('extraclass') || '';

	// set slid in panel as the current one
	$panelToSlideIn.removeClass().addClass('panel current ' + extraClass);

	// reset all other panels
	$panels.filter(':not(#' + $panelToSlideIn.attr('id') + ')').removeClass().addClass('panel ' + extraClass);

	// Allow a new animation
	$panelContainer.removeClass('animating');

};

var setExitPanel = function ($panelToSlideOut, exitAnimation) {

	$panelToSlideOut
		.addClass('exit ' + exitAnimation)
		.removeClass('current');

};

var setEnterPanel = function ($panelContainer, $panels, $panelToSlideIn, enterAnimation) {

	$panelToSlideIn
		.addClass('enter ' + enterAnimation)

		// When sliding in is done,
		// .one('transitionend webkitTransitionEnd MSTransitionEnd', function(e) {

		// moved to a setTimeout in the click handling logic itself because Firefox doesn't always fire this!!!
		// stopAnimation($panelContainer, $panels, $panelToSlideIn)

		// })
		;

};

var SetActiveTab = function(activeTab)
{
	for (var i = 0; i < $panelNavItems.length; i++) {
		var tab = $panelNavItems[i];
		if (tab != activeTab)
			tab.className = "";
	}
	activeTab.addClass("active");
}

var $panelNav, $panelNavItems, $panelContainer, $panels, numPanels, animationDuration

function InitTabs(panelNavId) {
	$panelNav = $("#" + panelNavId);
	console.log("$panelNav");
	console.log($panelNav);

	$panelNavItems = $panelNav.find('a');
	console.log("$panelNavItems");
	console.log($panelNavItems);

	$panelContainer = $('#' + $panelNav.data('panelwrapper'));
	console.log("$panelContainer");
	console.log($panelContainer);

	$panels = $panelContainer.find('> .panel');
	console.log("$panels");
	console.log($panels);

	numPanels = $panels.length;
	console.log("numPanels");
	console.log(numPanels);

	animationDuration = ($panelContainer.data('sequential') == 'yes') ? 1200 : 600;
	console.log("animationDuration");
	console.log(animationDuration);

	if (numPanels > 1) {
		$panelNav.find('a[href="#next"]').removeClass('inactive');
	}
}

function OnTabClick(tabId) {

	var tab = $("#" + tabId);

	var $panelToSlideIn, $panelToSlideOut, enterAnimation, exitAnimation;

	// Don't do anything if we are currently animating
	if ($panelContainer.is('.animating')) return false;

	// Define the panel to slideOut
	$panelToSlideOut = $panels.filter('.current');

	// Define the the panel to slide in
	if (tab.attr('href') == '#next') {
		$panelToSlideIn = $panels.filter('.current').next('.panel');
	}
	else if (tab.attr('href') == '#prev') {
		$panelToSlideIn = $panels.filter('.current').prev('.panel');
	}
	else {
		$panelToSlideIn = /* $panels.filter('#' + */ $(tab.attr('href')) /* .attr('id')) */;
	}

	// Don't do anything if there is no new panel
	if ($panelToSlideIn == null) return;

	// Don't do anything if the new panel equals the current panel
	if ($panelToSlideOut.attr('id') == $panelToSlideIn.attr('id')) return;

	// Define animations to use
	enterAnimation = $panelContainer.data('enter');
	exitAnimation = $panelContainer.data('exit');

	// Set the exit panel
	setExitPanel($panelToSlideOut, exitAnimation);

	// Set the enter panel
	setEnterPanel($panelContainer, $panels, $panelToSlideIn, enterAnimation);

	// Start the animation (immediately)
	// @note: using a setTimeout because "it solves everything", dixit @rem
	setTimeout(function () {
		startAnimation($panelContainer);
	}, 0);

	// Update next/prev buttons
	updatePanelNav($panelNav, $panelContainer, $panelToSlideIn, numPanels);

	SetActiveTab(tab);

	// Stop the animation after a while
	setTimeout(function () {
		stopAnimation($panelContainer, $panels, $panelToSlideIn);
	}, animationDuration);

}


/************************************* CKEditor **************************************/
/*************************************************************************************/

//CKEditorInterop = (() => {
//	const editors = {};

//	return {
//		init(id, dotNetReference) {
//			ClassicEditor
//				.create(document.getElementById(id), {
//					alignment: {
//						options: ['left', 'right', 'center']
//					}
//				})
//				.then(editor => {
//					editors[id] = editor;
//					editor.model.document.on('change:data', () => {
//						let data = editor.getData();

//						const el = document.createElement('div');
//						el.innerHTML = data;
//						if (el.innerText.trim() == '')
//							data = null;

//						dotNetReference.invokeMethodAsync('EditorDataChanged', data);
//					});
//				})
//				.catch(error => console.error(error));
//		},
//		destroy(id) {
//			editors[id].destroy()
//				.then(() => delete editors[id])
//				.catch(error => console.log(error));
//		}
//	};
//})();

CKEditorInterop = (() => {
	const editors = {};

	return {
		init(id, dotNetReference, initData = "") {
			DecoupledEditor
				.create(document.querySelector('#' + id), {
					language: {
						// The UI will be English.
						ui: 'en',

						// But the content will be edited in Arabic.
						content: 'ar'
					}
				})
				.then(editor => {
					const toolbarContainer = document.querySelector('#toolbar_container_'+ id);
					toolbarContainer.appendChild(editor.ui.view.toolbar.element);

					//test init
					editor.setData(initData)

					editors[id] = editor;
					editor.model.document.on('change:data', () => {
						let data = editor.getData();

						const el = document.createElement('div');
						el.innerHTML = data;
						//if (el.innerText.trim() == '')
						//	data = null;

						dotNetReference.invokeMethodAsync('EditorDataChanged', data);
					});
				})
				.catch(error => console.log(error));
		},
		destroy(id) {
			editors[id].destroy()
				.then(() => delete editors[id])
				.catch(error => console.log(error));
		},
		getData(id) {
			return editors[id].getData();
        }
	};
})();


