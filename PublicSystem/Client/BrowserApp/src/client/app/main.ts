import { APP_BASE_HREF } from '@angular/common';
import { disableDeprecatedForms, provideForms } from '@angular/forms';
import { enableProdMode } from '@angular/core';
import { bootstrap } from '@angular/platform-browser-dynamic';

import { APP_ROUTER_PROVIDERS } from './app.routes';
import { AppComponent } from './app.component';

// This was giving an error in VSCode. The newer angular-seed uses String('<%= BUILD_TYPE %>') instead of '<%= ENV %>'
//if ('<%= ENV %>' === 'prod') { enableProdMode(); }

/**
 * Bootstraps the application and makes the ROUTER_PROVIDERS and the APP_BASE_HREF available to it.
 * @see https://angular.io/docs/ts/latest/api/platform-browser-dynamic/index/bootstrap-function.html
 */

// export function main(params) {
bootstrap(AppComponent, [
  disableDeprecatedForms(),
  provideForms(),
// provide('Name', {useValue: params.name}),
  APP_ROUTER_PROVIDERS,
  {
    provide: APP_BASE_HREF,
    useValue: '<%= APP_BASE %>'
  }
]);
// }

// The commented out code above is for injecting a variable "Name" into the Angular app.
// This is for the purpose of telling whether BrowserApp is running inside of the ASP.NET server
// or if it is running alone. IT would be running alone while developing within VsCode. When it is running
// alone, it will not call the Web Api to get data, but will instead use test data files. 

// // To use the Name provider in some component:
// export class SomeComponent {
//    constructor(@Inject('Name') public username: string) {
//    }
//
// The above code needs to go in backend.service.ts and talks.service.ts

// Notes from stackoverflow:
//
// This seems a soluton to passing a constant to the angular app with value "NotRunningInAspNet"
// http://stackoverflow.com/questions/37312018/pass-constant-values-to-angular-2-from-layout-cshtml/37384567#37384567
// or this:
// http://stackoverflow.com/questions/37337185/passing-asp-net-server-parameters-to-angular-2-app

// In order to start the Service Worker located at "./worker.js"
// uncomment this line. More about Service Workers here
// https://developer.mozilla.org/en-US/docs/Web/API/Service_Worker_API/Using_Service_Workers
//
// if ('serviceWorker' in navigator) {
//   (<any>navigator).serviceWorker.register('./worker.js').then((registration: any) =>
//       console.log('ServiceWorker registration successful with scope: ', registration.scope))
//     .catch((err: any) =>
//       console.log('ServiceWorker registration failed: ', err));
// }
