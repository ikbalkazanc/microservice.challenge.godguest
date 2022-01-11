const { validationResult } = require('express-validator')
 

function response(error, data) {
    return {
      status: error ? "error" : "success",
      data: data ? data : null,
      error: error ? error : null
    };
  }

const validate = (req, res, next) => {
    const errors = validationResult(req)
    if (errors.isEmpty()) {
        return next()
    }
    
    var extractedErrors = response({ code: 422, message: "keys are not valid" }, null);
    errors.array().map(err => Object.assign(extractedErrors.error, { [err.param]: err.msg }))

    return res.status(422).json({
        errors: extractedErrors,
    })

}
 
module.exports = {
    validate
}