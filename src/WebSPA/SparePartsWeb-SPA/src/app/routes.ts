import { AuthGuard } from './_guards/auth.guard';
import { CategoryComponent } from './category/category.component';
import { OrderComponent } from './order/order.component';
import { HomeComponent } from './home/home.component';
import { Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'products', component: ProductsComponent, canActivate: [AuthGuard]},
            { path: 'order', component: OrderComponent},
            { path: 'category', component: CategoryComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];


