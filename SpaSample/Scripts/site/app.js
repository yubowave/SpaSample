// Template
var HtmlTemplateManager = (function () {
    var instance,
        baseUrl = '/Content/template/',
        templates = {
            'eventList': { url: 'eventList.html' },
            'createEvent': { url: 'createEvent.html' },
            'eventDetail': { url: 'eventDetail.html' },
        };

    function createInstance() {
        var object = new Object();
        object.templates = new Array();
        object.load = function (name, callback) {
            if (object.templates[name] != undefined) {
                callback(object.templates[name]);
            };
            if (templates[name] == undefined) {
                throw new ExceptionInformation('Error template name.');
            };
            require(['text!' + baseUrl + templates[name].url], function (content) {
                object.templates[name] = content;
                callback(object.templates[name]);
            });
        };
        return object;
    }

    return {
        getInstance: function () {
            if (!instance)
                instance = createInstance();
            return instance;
        }
    };
})();
var templateManager = HtmlTemplateManager.getInstance();

// error
$(document).ajaxError(function (event, request, settings) {
    if (typeof (request.responseJSON) === 'object') {
        var data = request.responseJSON;
        if (typeof (data.modelState) === 'object') {
            $('#validaitonSummary').remove('li');
            var validationSummary = $('#validaitonSummary').get(0);
            var viewModel = { title: data.message, validation: new Array() };
            ko.cleanNode(validationSummary);

            for (var prop in data.modelState) {
                $.each(data.modelState[prop], function () {
                    viewModel.validation.push(this.toString());
                });
            }
            $('#validaitonSummary').alert();
            ko.applyBindings(viewModel, validationSummary);
        }
    }
});

// event list
var setEventList = function(category) {
    templateManager.load('eventList', function (template) {
        $.getJSON('api/event', { 'category': category }, function (events) {
            var viewModel = new eventListViewModel(events);
            $('#main').replaceWith(template);
            ko.applyBindings(viewModel, $('#main').get(0));
        })
    });
};

// Router
var router = Router({
    '/': function () { setEventList('all'); },
    '/event/all': function () { setEventList('all'); },
    '/event/opening': function () { setEventList('opening'); },
    '/event/closed': function () { setEventList('closed'); },
    '/event/create': function () {
        templateManager.load('createEvent', function (template) {
            $('#main').fadeOut(200, function () {
                $(this).replaceWith(template);
                initDatePicker();
                ko.applyBindings(new eventViewModel(), $('#main').get(0));
            });
        });
    },
    '/event/:id': function (id) {
        templateManager.load('eventDetail', function (template) {
            $.getJSON('api/event/'+id, function(data) {
                $('#main').fadeOut(200, function () {
                    $(this).replaceWith(template);
                    initDatePicker();
                    var viewModel = new eventViewModel();
                    viewModel.fromJS(data);
                    ko.applyBindings(viewModel, $('#main').get(0));
                });
            });
        });
    },
});
router.init('/');