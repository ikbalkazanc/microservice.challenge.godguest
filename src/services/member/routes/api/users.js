var mongoose = require("mongoose");
var router = require("express").Router();
var passport = require("passport");
var User = mongoose.model("User");
var auth = require("../auth");
var assert = require("assert");
var { validate } = require("../validator");
var rules = require("../validations/user_validation");

var statusJson = {
  status: null,
  data: null,
  error: [
    {
      code: null,
      message: null,
    },
  ],
};

function response(error, data) {
  return {
    status: error ? "error" : "success",
    data: data ? data : null,
    error: error ? error : null,
  };
}

// Get(int id)
router.get("/user/:id", function (req, res, next) {
  var id = req.params.id;
  User.findById(id)
    .then((data) => {
      if (!data) {
        return res
          .status(400)
          .json(response({ code: 400, message: "User not found" }, null));
      }
      return res.status(200).json(response(null, data));
    })
    .catch((err) => {
      return res
        .status(500)
        .json(response({ code: 500, message: "Internal error" }, null));
    });
});

// Get(int[] id)
router.post("/user/", function (req, res, next) {
  var ids = req.body.ids;

  assert.notEqual(typeof ids, "undefined", "ids is undefined");

  User.find({ _id: { $in: ids } })
    .then((data) => {
      if (!data) {
        return res
          .status(400)
          .json(response({ code: 400, message: "Users not found" }, null));
      }
      return res.status(200).json(response(null, data));
    })
    .catch((err) => {
      return res
        .status(500)
        .json(response({ code: 500, message: "Internal error" }, null));
    });
});

/* Update() */
router.put("/user/:id", rules(), validate, function (req, res, next) {
  var id = req.params.id;
  var updatedUser = {
    name: req.body.user.name,
    surname: req.body.user.surname,
    email: req.body.user.email,
    role: req.body.user.role,
  };

  User.findByIdAndUpdate(id, updatedUser)
    .then((data) => {
      if (!data) {
        return res
          .status(400)
          .json(response({ code: 400, message: "Users not found" }, null));
      }
      return res.status(200).json(response(null, data));
    })
    .catch((err) => {
      return res
        .status(500)
        .json(response({ code: 500, message: "Internal error" }, null));
    });
});

/* Create */
router.post("/users", rules(), validate, function (req, res, next) {
  var user = new User();

/*   assert.notEqual(typeof req.body.user, "undefined", "body is undefined");
 */
  user.name = req.body.user.name;
  user.surname = req.body.user.surname;
  user.email = req.body.user.email;
  user.role = req.body.user.role;

  return user
    .save()
    .then((user) =>
      res
        .status(200)
        .json(response(null, { code: 200, message: "OK", user: user }))
    )
    .catch((err) =>
      res
        .status(500)
        .json(response({ code: 500, message: "Internal error", err: err}, null))
    );
});

// Delete(int id) - delete
router.delete("/user/:id", function (req, res, next) {
  var id = req.params.id;

  User.findByIdAndRemove(id)
  .then((data) => {
    if (!data) {
      return res
        .status(400)
        .json(response({ code: 400, message: "Members not found" }, null));
    }
    return res.status(200).json(response(null, data));
  })
  .catch((err) => {
    return res
      .status(500)
      .json(response({ code: 500, message: "Internal error" }, null));
  });


});

/* login */
router.post("/users/login", function (req, res, next) {
  // TODO: Validation Dynamic

  if (!req.body.user.email) {
    return res.status(422).json({ errors: { email: "can't be blank" } });
  }

  if (!req.body.user.password) {
    return res.status(422).json({ errors: { password: "can't be blank" } });
  }

  passport.authenticate(
    "local",
    { session: false },
    function (err, user, info) {
      if (err) {
        return next(err);
      }

      if (user) {
        user.token = user.generateJWT();
        return res.json({ user: user.toAuthJSON() });
      } else {
        return res.status(422).json(info);
      }
    }
  )(req, res, next);
});

module.exports = router;
