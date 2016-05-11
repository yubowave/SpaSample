var eventViewModel = function () {
    var self = this;
    self.id = 0;
    self.title = ko.observable();
    self.description = ko.observable();
    self.startdate = ko.observable(new Date());
    self.enddate = ko.observable(new Date());
    self.owner = ko.observable();
    self.editEnabled = ko.observable(false);
    self.canEdit = ko.observable(true);

    self.submit = function () {
        $.ajax({
            url: '/api/event',
            type: 'POST',
            data: ko.toJSON(self),
            contentType: 'application/json;charset=utf-8',
            success: function () { location.href = '#/' },
            error: function (e) { console.log(e); }
        });
        return false;
    };

    self.update = function () {
        $.ajax({
            url: '/api/event',
            type: 'PUT',
            data: ko.toJSON(self),
            contentType: 'application/json;charset=utf-8',
            success: function () { location.href = '#/' },
            error: function (e) { console.log(e); }
        });
        return false;
    };

    self.enable = function () {
        self.editEnabled(true);
    };

    self.fromJS = function (data) {
        self.id = data.id;
        self.title(data.title);
        self.description(data.description);
        self.startdate(data.startDate);
        self.enddate(data.endDate);
        self.owner(data.owner);
        self.status = data.status;
        self.canEdit(self.status !== 'closed');
    }
};

var eventListViewModel = function (events) {
    var self = this;
    self.events = events;
    self.close = function (event) {
        $.ajax({
            url: '/api/event/'+event.id+'/close',
            type: 'PUT',
            success: function () { router.init('/') },
            error: function (e) { console.log(e); }
        });
        return false;
    }
};