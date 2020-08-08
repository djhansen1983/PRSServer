import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoreHomeComponent } from './core/core-home/core-home.component';
import { CoreAboutComponent } from './core/core-about/core-about.component';
import { CoreE404Component } from './core/core-e404/core-e404.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserCreateComponent } from './user/user-create/user-create.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { VendorListComponent } from './vendor/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './vendor/vendor-detail/vendor-detail.component';
import { VendorCreateComponent } from './vendor/vendor-create/vendor-create.component';
import { VendorEditComponent } from './vendor/vendor-edit/vendor-edit.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductCreateComponent } from './product/product-create/product-create.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { RequestListComponent } from './request/request-list/request-list.component';
import { RequestDetailComponent } from './request/request-detail/request-detail.component';
import { RequestCreateComponent } from './request/request-create/request-create.component';
import { RequestEditComponent } from './request/request-edit/request-edit.component';
import { RequestLinesComponent } from './request/request-lines/request-lines.component';
import { RequestReviewsComponent } from './request/request-reviews/request-reviews.component';
import { RequestReviewItemComponent } from './request/request-review-item/request-review-item.component';
import { combineLatest } from 'rxjs';



const routes: Routes = [
  { path: '', redirectTo: '/user/login', pathMatch: 'full' },
  { path: 'core/home', component: CoreHomeComponent },
  { path: 'core/about', component: CoreAboutComponent },
  { path: 'core/e404', component: CoreE404Component },
  { path: 'user/list', component: UserListComponent },
  { path: 'user/detail', component: UserDetailComponent },
  { path: 'user/create', component: UserCreateComponent },
  { path: 'user/login', component: UserLoginComponent },
  { path: 'vendor/list', component: VendorListComponent },
  { path: 'vendor/detail', component: VendorDetailComponent },
  { path: 'vendor/create', component: VendorCreateComponent },
  { path: 'vendor/edit', component: VendorEditComponent },
  { path: 'product/list', component: ProductListComponent },
  { path: 'product/detail', component: ProductDetailComponent },
  { path: 'product/create', component: ProductCreateComponent },
  { path: 'product/edit', component: ProductEditComponent },
  { path: 'request/list', component: RequestListComponent },
  { path: 'request/detail', component: RequestDetailComponent },
  { path: 'request/create', component: RequestCreateComponent },
  { path: 'request/edit', component: RequestEditComponent },
  { path: 'request/lines', component: RequestLinesComponent },
  { path: 'request/reviews', component: RequestReviewsComponent },
  { path: 'request/reviewitem', component: RequestReviewItemComponent },
  { path: '**', component: UserLoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
