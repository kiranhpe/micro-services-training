import { NgModule } from '@angular/core';
import { RouterModule, Routes, withHashLocation } from '@angular/router';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  {
    path:'products',
    component: ProductsComponent
  },
  {
    path: '', redirectTo: 'products', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
