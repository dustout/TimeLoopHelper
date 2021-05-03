/// <binding ProjectOpened='onOpen' />

var gulp = require('gulp');
var sass = require('gulp-sass');
sass.compiler = require('node-sass');

function compileSass() {
  return gulp.src('wwwroot/scss/**/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('wwwroot/css'));
}

exports.compileSass = compileSass;

exports.onOpen = function () {
  gulp.watch('wwwroot/scss/**/*.scss', compileSass);
};