define(function () {
    console.log('Person defining');
    var Person = function(name, age) {
        var self = this;
        self.name = name;
        self.arrayGetDistinctValues = age;
    };

    Person.prototype.getPersonInfo = function() {
        return "Name: " + this.name + ", Age: " + this.age;
    };

    return Person;
});
