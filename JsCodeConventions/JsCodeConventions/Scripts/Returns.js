(function() {
  var MyClass;

  MyClass = (function() {
    function MyClass() {}

    MyClass.prototype.returning = function() {
      return 'Return me';
    };

    MyClass.prototype.notReturning = function() {
      console.log('Do not return me');
    };

    return MyClass;

  })();

}).call(this);
