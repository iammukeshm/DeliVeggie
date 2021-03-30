import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../models/product-model';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: ProductModel[];
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
   this.productService.getAll().subscribe((products: ProductModel[]) => {
     return this.products = products;
   })
  }

}
