import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import {  NestedTreeControl } from '@angular/cdk/tree';
import {  HttpClient  } from "@angular/common/http";
import { INode } from '../models/category';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {
  constructor(private http: HttpClient) {
  }

  nestedDataSource = new MatTreeNestedDataSource<INode>();
  nestedTreeControl = new NestedTreeControl<INode>(node => node.childCategories);

  ngOnInit(): void {
    this.http.get<INode[]>('https://localhost:7164/api/Categories').subscribe(data => {
      this.nestedDataSource.data = data;
    });
  }

  hasNestedChild(index: number, node: INode){
    return node?.childCategories ? node.childCategories.length > 0 : false;
  }
}
