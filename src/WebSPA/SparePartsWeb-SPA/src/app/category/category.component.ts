import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  category: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCategory();
  }

  getCategory() {
    this.http.get('http://localhost:62464/api/category').subscribe(response => {
      this.category = response;
    }, error => {
      console.log(error);
    });
  }

}
