const { body } = require('express-validator')
 
const rules = () => {
    return [
        body('user.name').exists().notEmpty().isString(),
        body('user.surname').exists().notEmpty().isString(),
        body('user.email').exists().isEmail(),
        body('user.role').exists().custom((value) => value !== "owner" || value !== "holder")
    ]
}
module.exports = rules;