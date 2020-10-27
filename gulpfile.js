let gulp = require('gulp');
let sass = require('gulp-sass');
let browserSync = require('browser-sync');
let uglify = require('gulp-uglify');
let concat = require('gulp-concat');
let rename = require('gulp-rename');
let del = require('del');
let autoprefixer = require('gulp-autoprefixer')

gulp.task('scss', function() {
  return gulp.src('ETrainerWeb/wwwroot/scss/**/*.scss')
    .pipe(sass({outputStyle: "compressed"}))
    .pipe(autoprefixer({
      browsers: ['last 8 versions']
    }))
    .pipe(rename({
      suffix: '.min'
    }))
    .pipe(gulp.dest('ETrainerWeb/wwwroot/css'))
    .pipe(browserSync.reload({stream: true}))
});

gulp.task('css', function() {
  return gulp.src([
    'node_modules/normalize.css/normalize.css',
    'node_modules/slick-carousel/slick/slick.css',
  ])
  .pipe(concat('_libs.scss'))
  .pipe(gulp.dest('ETrainerWeb/wwwroot/scss'))
  .pipe(browserSync.reload({stream: true}))
})

gulp.task('html', function() {
  return gulp.src('ETrainerWeb/wwwroot/*.html')
  .pipe(browserSync.reload({stream: true}))
})

gulp.task('script', function() {
  return gulp.src('ETrainerWeb/wwwroot/js/*.js')
  .pipe(browserSync.reload({stream: true}))
})

gulp.task('js', function() {
  return gulp.src([
    'node_modules/slick-carousel/slick/slick.js',
  ])
  .pipe(concat('libs.min.js'))
  .pipe(uglify())
  .pipe(gulp.dest('ETrainerWeb/wwwroot/js'))
  .pipe(browserSync.reload({stream: true}))
})

gulp.task('browser-sync', function() {
  browserSync.init({
      server: {
          baseDir: "ETrainerWeb/wwwroot/"
      }
  });
});

gulp.task('export', async function() {
  let buildHtml = gulp.src('ETrainerWeb/wwwroot/**/*.html')
    .pipe(gulp.dest('dist'))

  let buildCss = gulp.src('ETrainerWeb/wwwroot/css/**/*.css')
    .pipe(gulp.dest('dist/css'))

  let buildJs = gulp.src('ETrainerWeb/wwwroot/js/**/*.js')
    .pipe(gulp.dest('dist/js'))

  let buildFonts = gulp.src('ETrainerWeb/wwwroot/fonts/**/*.*')
    .pipe(gulp.dest('dist/fonts'))

  let buildImg = gulp.src('ETrainerWeb/wwwroot/img/**/*.*')
    .pipe(gulp.dest('dist/img'))
})

gulp.task('watch', function(){
  gulp.watch('ETrainerWeb/wwwroot/scss/**/*.scss', gulp.parallel('scss'))
  gulp.watch('ETrainerWeb/wwwroot/*.html', gulp.parallel('html'))
  gulp.watch('ETrainerWeb/wwwroot/js/*.js', gulp.parallel('script'))
});

gulp.task('clean', async function() {
  del.sync('dist')
})

gulp.task('build', gulp.series('clean', 'export'))

gulp.task('default', gulp.parallel('css', 'scss', 'js', 'browser-sync', 'watch'));