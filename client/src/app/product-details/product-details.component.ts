import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDetailModel } from '../models/product-detail';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
 product: ProductDetailModel;
 productId: string | null;
 constructor(private route: ActivatedRoute,private productService: ProductService) { }

 ngOnInit(): void {
  this.productId = this.route.snapshot.paramMap.get('id');
  this.productService.getById(this.productId as string).subscribe((product: ProductDetailModel) => {
    return this.product = product;
  })
}

}
